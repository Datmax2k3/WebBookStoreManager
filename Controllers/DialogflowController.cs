using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
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
                // Đặt timeout tối đa 20 giây
                var processingTask = ProcessRequestAsync(request);
                var timeoutTask = Task.Delay(TimeSpan.FromSeconds(20));

                var completedTask = await Task.WhenAny(processingTask, timeoutTask);
                if (completedTask == timeoutTask)
                {
                    return Ok(new { fulfillmentText = "Xin lỗi, hệ thống đang bận. Vui lòng thử lại sau." });
                }
                else
                {
                    return await processingTask;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
                return BadRequest("Lỗi trong quá trình xử lý request.");
            }
        }

        private async Task<IActionResult> ProcessRequestAsync(dynamic request)
        {
            JObject obj = JObject.Parse(request.ToString());
            string intentName = (string)obj["queryResult"]?["intent"]?["displayName"];
            var parameters = obj["queryResult"]?["parameters"];

            System.Diagnostics.Debug.WriteLine($"Received intent: {intentName}");
            System.Diagnostics.Debug.WriteLine($"Parameters: {parameters?.ToString()}");

            switch (intentName)
            {
                case "Default Welcome Intent":
                    return Ok(new { fulfillmentText = "Chào bạn, tôi có thể giúp gì về sách?" });
                case "Ibookinformation":
                    return await HandleBookInfoAsync(parameters);
                case "Iauthorinformation":
                    return await HandleAuthorInfoAsync(parameters);
                default:
                    return Ok(new { fulfillmentText = "Xin lỗi, tôi chưa hiểu yêu cầu của bạn." });
            }
        }

        private async Task<IActionResult> HandleBookInfoAsync(JToken parameters)
        {
            // Lấy raw book name và info_type (nếu info_type là mảng -> nối thành chuỗi)
            string rawBookName = parameters?["book_name"]?.ToString()?.Trim();
            var infoTypeToken = parameters?["info_type"];
            string infoType = "";
            if (infoTypeToken != null)
            {
                if (infoTypeToken is JArray arr && arr.HasValues)
                    infoType = string.Join(" ", arr.ToObject<string[]>()).ToLower();
                else if (infoTypeToken.Type != Newtonsoft.Json.Linq.JTokenType.Array)
                    infoType = infoTypeToken.ToString().Trim().ToLower();
            }

            System.Diagnostics.Debug.WriteLine($"Book Name (raw): {rawBookName}");
            System.Diagnostics.Debug.WriteLine($"Info Type: {infoType}");

            // Chuẩn hoá tên sách (bỏ các từ dư như "giá", "mô tả", v.v.)
            string bookName = NormalizeBookName(rawBookName);

            if (string.IsNullOrEmpty(bookName))
                return Ok(new { fulfillmentText = "Bạn chưa cung cấp tên sách." });

            // Tìm sách theo tên bằng truy vấn bất đồng bộ và EF.Functions.Like để hỗ trợ fuzzy search
            var matchedBook = await _context.SANPHAM
                .FirstOrDefaultAsync(s => EF.Functions.Like(s.TenSanPham, $"%{bookName}%"));

            if (matchedBook == null)
                return Ok(new { fulfillmentText = $"Không tìm thấy sách tên '{rawBookName}' trong hệ thống." });
            else
                System.Diagnostics.Debug.WriteLine($"Found Book: {matchedBook.TenSanPham}");

            // Chuẩn hoá info_type (loại bỏ dấu)
            string normalizedInfoType = RemoveDiacritics(infoType);

            // Nếu info_type rỗng, trả về đầy đủ thông tin
            if (string.IsNullOrEmpty(normalizedInfoType))
            {
                return Ok(new
                {
                    fulfillmentText = $"Có phải ý bạn là: Cuốn '{matchedBook.TenSanPham}' có giá {matchedBook.GiaGoc:N0} đồng, trạng thái {matchedBook.TrangThai}."
                });
            }
            else
            {
                // Nếu info_type chứa "bao nhiêu" mà không chứa "mô tả"/"nội dung", quy về "giá"
                if (normalizedInfoType.Contains("bao nhieu") && !normalizedInfoType.Contains("mo ta") && !normalizedInfoType.Contains("noi dung"))
                    normalizedInfoType = "gia";

                if (normalizedInfoType.Contains("gia"))
                {
                    return Ok(new { fulfillmentText = $"Giá của cuốn '{matchedBook.TenSanPham}' là {matchedBook.GiaGoc:N0} đồng, hiện tại đang được giảm {matchedBook.GiamGia:N0}%." });
                }
                else if (normalizedInfoType.Contains("mo ta") || normalizedInfoType.Contains("noi dung"))
                {
                    if (string.IsNullOrEmpty(matchedBook.MoTaChiTiet))
                        return Ok(new { fulfillmentText = $"Hiện chưa có mô tả cho cuốn '{matchedBook.TenSanPham}'." });
                    return Ok(new { fulfillmentText = $"Mô tả cuốn '{matchedBook.TenSanPham}': {matchedBook.MoTaChiTiet}" });
                }
                else if (normalizedInfoType.Contains("trang thai") || normalizedInfoType.Contains("con hang"))
                {
                    return Ok(new { fulfillmentText = $"Trạng thái cuốn '{matchedBook.TenSanPham}' là {matchedBook.TrangThai}." });
                }
                else if (normalizedInfoType.Contains("ngay xuat ban"))
                {
                    if (matchedBook.NgayXuatBan != null)
                        return Ok(new { fulfillmentText = $"Ngày xuất bản của cuốn '{matchedBook.TenSanPham}' dự kiến: {matchedBook.NgayXuatBan:yyyy-MM-dd}" });
                    else
                        return Ok(new { fulfillmentText = $"Thông tin ngày xuất bản của cuốn '{matchedBook.TenSanPham}' chưa được cập nhật." });
                }
                else
                {
                    return Ok(new { fulfillmentText = $"Thông tin bạn cần không rõ. Cuốn '{matchedBook.TenSanPham}' có giá {matchedBook.GiaGoc:N0} đồng và trạng thái {matchedBook.TrangThai}." });
                }
            }
        }

        private async Task<IActionResult> HandleAuthorInfoAsync(JToken parameters)
        {
            string authorName = parameters?["author_name"]?.ToString()?.Trim();
            if (string.IsNullOrEmpty(authorName))
                return Ok(new { fulfillmentText = "Bạn chưa cung cấp tên tác giả." });

            System.Diagnostics.Debug.WriteLine($"Author Name: {authorName}");

            var author = await FindBestMatchAuthorNameAsync(authorName);
            if (author == null)
                return Ok(new { fulfillmentText = $"Không tìm thấy tác giả '{authorName}'." });
            System.Diagnostics.Debug.WriteLine($"Found Author: {author.TenTacGia}");

            var bookIds = await _context.SANPHAM_TACGIA
                .Where(x => x.IdTacGia == author.IdTacGia)
                .Select(x => x.IdSanPham)
                .ToListAsync();

            var books = await _context.SANPHAM
                .Where(s => bookIds.Contains(s.IdSanPham))
                .Select(s => s.TenSanPham)
                .ToListAsync();

            if (!books.Any())
                return Ok(new { fulfillmentText = $"Tác giả '{author.TenTacGia}' chưa có sách trong hệ thống." });
            else
            {
                string listBook = string.Join(", ", books);
                return Ok(new { fulfillmentText = $"Tác giả '{author.TenTacGia}' có các sách: {listBook}." });
            }
        }

        // Tìm sách gần đúng nhất dựa trên tên bằng EF.Functions.Like (có thể mở rộng sang fuzzy search nếu cần)
        private async Task<SANPHAM> FindBestMatchBookNameAsync(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;
            return await _context.SANPHAM
                .FirstOrDefaultAsync(s => EF.Functions.Like(s.TenSanPham, $"%{input}%"));
        }

        // Hàm tính độ tương đồng giữa 2 chuỗi dựa trên LCS (nếu cần cho fuzzy search)
        private double CalculateSimilarity(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2)) return 0;
            s1 = s1.ToLower();
            s2 = s2.ToLower();
            int lcs = LongestCommonSubsequence(s1, s2);
            return (2.0 * lcs) / (s1.Length + s2.Length);
        }

        private int LongestCommonSubsequence(string s1, string s2)
        {
            int m = s1.Length, n = s2.Length;
            int[,] dp = new int[m + 1, n + 1];
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    dp[i, j] = s1[i - 1] == s2[j - 1] ? dp[i - 1, j - 1] + 1 : Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
            return dp[m, n];
        }

        // Hàm loại bỏ các từ thừa khỏi tên sách (ví dụ: " giá", " mô tả")
        private string NormalizeBookName(string raw)
        {
            if (string.IsNullOrEmpty(raw)) return raw;
            string lower = raw.ToLower();
            if (lower.EndsWith(" giá"))
                raw = raw.Substring(0, raw.Length - " giá".Length).Trim();
            if (lower.EndsWith(" mô tả"))
                raw = raw.Substring(0, raw.Length - " mô tả".Length).Trim();
            return raw.Trim();
        }

        // Hàm loại bỏ dấu tiếng Việt để so sánh (RemoveDiacritics)
        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();
            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        // Tìm tác giả gần đúng nhất dựa trên tên
        private async Task<TACGIA> FindBestMatchAuthorNameAsync(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;
            var possibleAuthors = await _context.TACGIA
                .Where(a => a.TenTacGia.ToLower().Contains(input.ToLower()))
                .ToListAsync();

            if (!possibleAuthors.Any())
            {
                var allAuthors = await _context.TACGIA.ToListAsync();
                double bestScore = 0.0;
                TACGIA bestA = null;
                foreach (var a in allAuthors)
                {
                    double sc = CalculateSimilarity(input, a.TenTacGia);
                    if (sc > bestScore)
                    {
                        bestScore = sc;
                        bestA = a;
                    }
                }
                return bestScore < 0.3 ? null : bestA;
            }
            else
            {
                return possibleAuthors.First();
            }
        }
    }

    public class ChatRequest
    {
        public string Message { get; set; }
    }
}
