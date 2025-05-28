using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBookStoreManage.Data;
using WebBookStoreManage.Models;

namespace WebBookStoreManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DialogflowController : ControllerBase
    {
        private readonly WebBookStoreManageContext _context;
        private readonly CompareInfo _compareInfo;

        // Các mẫu trả lời cho thêm phần tự nhiên
        private static readonly string[] WelcomeResponses = new[] {
            "Chào bạn! Mình có thể giúp bạn tìm sách gì hôm nay?",
            "Xin chào! Hôm nay bạn muốn đọc thể loại nào?",
            "Hi! Mình ở đây để hỗ trợ bạn về thông tin sách."
        };

        private static readonly string[] FallbackResponses = new[] {
            "Xin lỗi, mình chưa hiểu. Bạn có thể diễn đạt khác không?",
            "Mình chưa rõ ý bạn. Bạn thử hỏi lại nhé.",
            "Rất tiếc, mình không tìm được thông tin phù hợp."
        };

        public DialogflowController(WebBookStoreManageContext context)
        {
            _context = context;
            _compareInfo = CultureInfo.CurrentCulture.CompareInfo;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] dynamic request)
        {
            try
            {
                var processingTask = ProcessRequestAsync(request);
                var timeoutTask = Task.Delay(TimeSpan.FromSeconds(5)); // Rút ngắn timeout còn 5 giây

                var completed = await Task.WhenAny(processingTask, timeoutTask);
                if (completed == timeoutTask)
                {
                    return Ok(new { fulfillmentText = "Xin lỗi, hệ thống đang bận. Vui lòng thử lại trong giây lát." });
                }
                return await processingTask;
            }
            catch (Exception ex)
            {
                // Log chi tiết exception
                Console.Error.WriteLine(ex);
                return Ok(new { fulfillmentText = "Đã xảy ra lỗi. Vui lòng thử lại sau." });
            }
        }

        private async Task<IActionResult> ProcessRequestAsync(dynamic request)
        {
            var obj = JObject.Parse(request.ToString());
            string intent = (string)obj["queryResult"]?["intent"]?["displayName"];
            var parameters = obj["queryResult"]?["parameters"];

            switch (intent)
            {
                case "Default Welcome Intent":
                    // Chọn ngẫu nhiên một mẫu
                    var welcome = WelcomeResponses[new Random().Next(WelcomeResponses.Length)];
                    return Ok(new { fulfillmentText = welcome });
                case "Ibookinformation":
                    return await HandleBookInfoAsync(parameters);
                case "Iauthorinformation":
                    return await HandleAuthorInfoAsync(parameters);
                default:
                    var fallback = FallbackResponses[new Random().Next(FallbackResponses.Length)];
                    return Ok(new { fulfillmentText = fallback });
            }
        }

        private async Task<IActionResult> HandleBookInfoAsync(JToken p)
        {
            // 1. Lấy tên sách
            string rawName = p?["book_name"]?.ToString()?.Trim();
            if (string.IsNullOrWhiteSpace(rawName))
                return Ok(new { fulfillmentText = "Bạn vui lòng cho mình biết tên cuốn sách nhé!" });

            // 2. Đọc info_type và chuẩn hóa
            var infoToken = p?["info_type"];
            string info = ExtractInfoType(infoToken).ToLower();    // e.g. "gia", "mo ta", "tac gia"

            // 3. Tìm sách trong DB
            string name = Normalize(rawName);
            var book = await _context.SANPHAM
                .Include(s => s.SanPhamTacGias)
                    .ThenInclude(st => st.TacGia)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => EF.Functions.Like(s.TenSanPham, $"%{name}%"));

            if (book == null)
                return Ok(new { fulfillmentText = $"Mình không tìm thấy sách '{rawName}' trong hệ thống." });

            // 4. Nếu user hỏi về tác giả
            if (info.Contains("tac gia") || info.Contains("tác giả") || info.Contains("author"))
            {
                var authors = book.SanPhamTacGias
                    .Select(x => x.TacGia.TenTacGia)
                    .Distinct()
                    .ToList();

                if (authors.Any())
                {
                    string listAuthors = string.Join(", ", authors);
                    string text = $"Cuốn '{book.TenSanPham}' có tác giả: {listAuthors}.";
                    return Ok(new { fulfillmentText = text });
                }
                else
                {
                    return Ok(new { fulfillmentText = $"Chưa có thông tin tác giả cho '{book.TenSanPham}'." });
                }
            }

            // 5. Các nhánh còn lại: giá, mô tả, tồn kho...
            return Ok(new { fulfillmentText = BuildBookResponse(book, info) });
        }


        private async Task<IActionResult> HandleAuthorInfoAsync(JToken p)
        {
            string raw = p?["author_name"]?.ToString().Trim();
            if (string.IsNullOrEmpty(raw))
                return Ok(new { fulfillmentText = "Bạn vui lòng cho mình biết tên tác giả nhé!" });

            var author = await FindBestAuthorAsync(raw);
            if (author == null)
                return Ok(new { fulfillmentText = $"Không tìm thấy tác giả '{raw}'." });

            var books = await _context.SANPHAM_TACGIA
                .Where(x => x.IdTacGia == author.IdTacGia)
                .Select(x => x.SanPham.TenSanPham)
                .ToListAsync();

            string text = books.Any()
                ? $"Tác giả '{author.TenTacGia}' có các sách: {string.Join(", ", books)}."
                : $"Tác giả '{author.TenTacGia}' hiện chưa có sách nào trong hệ thống.";

            return Ok(new { fulfillmentText = text });
        }

        // Hỗ trợ phân tích info_type
        private string ExtractInfoType(JToken token)
        {
            if (token == null) return string.Empty;
            if (token is JArray arr) return string.Join(" ", arr.Select(x => x.ToString())).ToLower();
            return token.ToString().ToLower();
        }

        // Xây dựng câu trả lời sách
        private string BuildBookResponse(SANPHAM b, string info)
        {
            info = RemoveDiacritics(info);
            if (string.IsNullOrEmpty(info))
                return $"Cuốn '{b.TenSanPham}' có giá {b.GiaGoc:N0}đ, giảm {b.GiamGia:N0}% và còn {b.SoLuongCon} cuốn trong kho.";

            if (info.Contains("gia"))
                return $"Giá của '{b.TenSanPham}' hiện là {b.GiaGoc:N0}đ, ưu đãi giảm {b.GiamGia:N0}%!";
            if (info.Contains("mo ta") || info.Contains("noi dung"))
                return string.IsNullOrEmpty(b.MoTaChiTiet)
                    ? $"Chưa có mô tả cho '{b.TenSanPham}'."
                    : $"Mô tả '{b.TenSanPham}': {b.MoTaChiTiet}";
            if (info.Contains("trang thai") || info.Contains("con hang"))
                return $"'{b.TenSanPham}' hiện {b.TrangThai}. Số lượng: {b.SoLuongCon}.";
            if (info.Contains("ngay xuat ban"))
                return b.NgayXuatBan.HasValue
                    ? $"'{b.TenSanPham}' xuất bản vào ngày {b.NgayXuatBan:dd/MM/yyyy}."
                    : $"Chưa cập nhật ngày xuất bản cho '{b.TenSanPham}'.";

            // Mặc định
            return $"Cuốn '{b.TenSanPham}' có giá {b.GiaGoc:N0}đ và {b.TrangThai}. Bạn cần thêm gì khác?";
        }

        private string Normalize(string raw)
        {
            string s = raw.ToLower().Trim();
            foreach (var suffix in new[] { " giá", " mô tả", " còn không" })
                if (s.EndsWith(suffix)) s = s[..^suffix.Length].Trim();
            return s;
        }

        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            var normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var c in normalized)
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        private async Task<TACGIA> FindBestAuthorAsync(string input)
        {
            input = input.ToLower();
            var list = await _context.TACGIA
                .Where(a => a.TenTacGia.ToLower().Contains(input))
                .ToListAsync();
            return list.FirstOrDefault();
        }
    }
}
