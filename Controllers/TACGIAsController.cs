using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using WebBookStoreManage.Data;
using WebBookStoreManage.Models;

namespace WebBookStoreManage.Controllers
{
    public class TACGIAsController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public TACGIAsController(WebBookStoreManageContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 15)
        {
            // Đảm bảo page và pageSize là hợp lệ
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            // Lấy danh sách tác giả dưới dạng IQueryable để áp dụng phân trang
            var tacGias = _context.TACGIA.AsQueryable();

            // Tính tổng số bản ghi
            var totalItems = await tacGias.CountAsync();

            // Tính tổng số trang
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            // Đảm bảo page không vượt quá tổng số trang (nếu có bản ghi)
            if (page > totalPages && totalPages > 0) page = totalPages;

            // Lấy danh sách tác giả cho trang hiện tại
            var items = await tacGias.Skip((page - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            // Truyền thông tin phân trang vào ViewBag
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;

            return View(items);
        }

        // GET: TACGIAs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tACGIA = await _context.TACGIA
                .FirstOrDefaultAsync(m => m.IdTacGia == id);
            if (tACGIA == null)
            {
                return NotFound();
            }

            return View(tACGIA);
        }

        // GET: TACGIAs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TACGIAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTacGia,TenTacGia")] TACGIA tACGIA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tACGIA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tACGIA);
        }

        // GET: TACGIAs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tACGIA = await _context.TACGIA.FindAsync(id);
            if (tACGIA == null)
            {
                return NotFound();
            }
            return View(tACGIA);
        }

        // POST: TACGIAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdTacGia,TenTacGia")] TACGIA tACGIA)
        {
            if (id != tACGIA.IdTacGia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tACGIA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TACGIAExists(tACGIA.IdTacGia))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tACGIA);
        }

        // GET: TACGIAs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tACGIA = await _context.TACGIA
                .FirstOrDefaultAsync(m => m.IdTacGia == id);
            if (tACGIA == null)
            {
                return NotFound();
            }

            return View(tACGIA);
        }

        // POST: TACGIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tACGIA = await _context.TACGIA.FindAsync(id);
            _context.TACGIA.Remove(tACGIA);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TACGIAExists(string id)
        {
            return _context.TACGIA.Any(e => e.IdTacGia == id);
        }

        // GET: /TACGIA/AddToExcel
        [HttpGet]
        public IActionResult AddToExcel()
        {
            return View();
        }

        // POST: /TACGIA/AddToExcel
        [HttpPost]
        public async Task<IActionResult> AddToExcel(IFormFile excelFile)
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                TempData["Error"] = "Bạn chưa chọn file Excel.";
                return View();
            }

            // Danh sách chứa dữ liệu cần thêm
            var authors = new List<TACGIA>();

            try
            {
                // EPPlus yêu cầu khai báo LicenseContext từ phiên bản 5.x
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (var stream = new MemoryStream())
                {
                    await excelFile.CopyToAsync(stream);
                    stream.Position = 0; // Reset vị trí stream

                    using (var package = new ExcelPackage(stream))
                    {
                        var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                        if (worksheet == null)
                        {
                            TempData["Error"] = "Không tìm thấy worksheet nào trong file Excel.";
                            return View();
                        }

                        int rowCount = worksheet.Dimension.Rows;
                        // Giả sử dòng đầu tiên là header, dữ liệu bắt đầu từ dòng 2
                        for (int row = 2; row <= rowCount; row++)
                        {
                            var idTacGia = worksheet.Cells[row, 1].Value?.ToString().Trim();
                            var tenTacGia = worksheet.Cells[row, 2].Value?.ToString().Trim();

                            if (!string.IsNullOrEmpty(idTacGia) && !string.IsNullOrEmpty(tenTacGia))
                            {
                                // Kiểm tra nếu dữ liệu đã tồn tại trong DB thì không thêm
                                if (!_context.TACGIA.Any(t => t.IdTacGia == idTacGia))
                                {
                                    authors.Add(new TACGIA
                                    {
                                        IdTacGia = idTacGia,
                                        TenTacGia = tenTacGia
                                    });
                                }
                            }
                        }
                    }
                }

                if (authors.Any())
                {
                    _context.TACGIA.AddRange(authors);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = $"Thêm thành công {authors.Count} tác giả.";
                }
                else
                {
                    TempData["Error"] = "Không có dữ liệu hợp lệ để thêm hoặc dữ liệu đã tồn tại.";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Có lỗi xảy ra khi xử lý file Excel: " + ex.Message;
            }

            // Sau khi xử lý, chuyển hướng về trang danh sách hoặc trang upload lại
            return RedirectToAction("Index"); // Hoặc thay bằng action phù hợp
        }
    }
}
