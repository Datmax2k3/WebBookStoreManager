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
    public class SANPHAM_TACGIAController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public SANPHAM_TACGIAController(WebBookStoreManageContext context)
        {
            _context = context;
        }

        // GET: SANPHAM_TACGIA
        public async Task<IActionResult> Index()
        {
            var webBookStoreManageContext = _context.SANPHAM_TACGIA.Include(s => s.SanPham).Include(s => s.TacGia);
            return View(await webBookStoreManageContext.ToListAsync());
        }

        // GET: SANPHAM_TACGIA/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sANPHAM_TACGIA = await _context.SANPHAM_TACGIA
                .Include(s => s.SanPham)
                .Include(s => s.TacGia)
                .FirstOrDefaultAsync(m => m.IdSanPham == id);
            if (sANPHAM_TACGIA == null)
            {
                return NotFound();
            }

            return View(sANPHAM_TACGIA);
        }

        // GET: SANPHAM_TACGIA/Create
        public IActionResult Create()
        {
            ViewData["IdSanPham"] = new SelectList(_context.SANPHAM, "IdSanPham", "IdSanPham");
            ViewData["IdTacGia"] = new SelectList(_context.TACGIA, "IdTacGia", "IdTacGia");
            return View();
        }

        // POST: SANPHAM_TACGIA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSanPham,IdTacGia")] SANPHAM_TACGIA sANPHAM_TACGIA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sANPHAM_TACGIA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSanPham"] = new SelectList(_context.SANPHAM, "IdSanPham", "IdSanPham", sANPHAM_TACGIA.IdSanPham);
            ViewData["IdTacGia"] = new SelectList(_context.TACGIA, "IdTacGia", "IdTacGia", sANPHAM_TACGIA.IdTacGia);
            return View(sANPHAM_TACGIA);
        }

        // GET: SANPHAM_TACGIA/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sANPHAM_TACGIA = await _context.SANPHAM_TACGIA.FindAsync(id);
            if (sANPHAM_TACGIA == null)
            {
                return NotFound();
            }
            ViewData["IdSanPham"] = new SelectList(_context.SANPHAM, "IdSanPham", "IdSanPham", sANPHAM_TACGIA.IdSanPham);
            ViewData["IdTacGia"] = new SelectList(_context.TACGIA, "IdTacGia", "IdTacGia", sANPHAM_TACGIA.IdTacGia);
            return View(sANPHAM_TACGIA);
        }

        // POST: SANPHAM_TACGIA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdSanPham,IdTacGia")] SANPHAM_TACGIA sANPHAM_TACGIA)
        {
            if (id != sANPHAM_TACGIA.IdSanPham)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sANPHAM_TACGIA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SANPHAM_TACGIAExists(sANPHAM_TACGIA.IdSanPham))
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
            ViewData["IdSanPham"] = new SelectList(_context.SANPHAM, "IdSanPham", "IdSanPham", sANPHAM_TACGIA.IdSanPham);
            ViewData["IdTacGia"] = new SelectList(_context.TACGIA, "IdTacGia", "IdTacGia", sANPHAM_TACGIA.IdTacGia);
            return View(sANPHAM_TACGIA);
        }

        // GET: SANPHAM_TACGIA/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sANPHAM_TACGIA = await _context.SANPHAM_TACGIA
                .Include(s => s.SanPham)
                .Include(s => s.TacGia)
                .FirstOrDefaultAsync(m => m.IdSanPham == id);
            if (sANPHAM_TACGIA == null)
            {
                return NotFound();
            }

            return View(sANPHAM_TACGIA);
        }

        // POST: SANPHAM_TACGIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sANPHAM_TACGIA = await _context.SANPHAM_TACGIA.FindAsync(id);
            _context.SANPHAM_TACGIA.Remove(sANPHAM_TACGIA);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SANPHAM_TACGIAExists(string id)
        {
            return _context.SANPHAM_TACGIA.Any(e => e.IdSanPham == id);
        }

        // GET: SANPHAM_TACGIA/AddToExcel
        [HttpGet]
        public IActionResult AddToExcel()
        {
            return View();
        }

        // POST: SANPHAM_TACGIA/AddToExcel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToExcel(IFormFile excelFile)
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                TempData["Error"] = "Bạn chưa chọn file Excel.";
                return View();
            }

            var newRecords = new List<SANPHAM_TACGIA>();

            try
            {
                // EPPlus yêu cầu khai báo LicenseContext từ phiên bản 5.x trở lên
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (var stream = new MemoryStream())
                {
                    await excelFile.CopyToAsync(stream);
                    stream.Position = 0;

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
                            var idSanPham = worksheet.Cells[row, 1].Value?.ToString().Trim();
                            var idTacGia = worksheet.Cells[row, 2].Value?.ToString().Trim();

                            // Nếu idSanPham hoặc idTacGia rỗng, bỏ qua dòng này
                            if (string.IsNullOrEmpty(idSanPham) || string.IsNullOrEmpty(idTacGia))
                            {
                                continue;
                            }

                            // Kiểm tra nếu bản ghi đã tồn tại trong DB thì bỏ qua
                            bool exists = await _context.SANPHAM_TACGIA
                                .AnyAsync(x => x.IdSanPham == idSanPham && x.IdTacGia == idTacGia);
                            if (exists)
                            {
                                continue;
                            }

                            // Kiểm tra xem idTacGia có tồn tại trong bảng TACGIA không
                            bool tacGiaExists = await _context.TACGIA
                                .AnyAsync(t => t.IdTacGia == idTacGia);
                            if (!tacGiaExists)
                            {
                                // Nếu không tồn tại, bỏ qua dòng này (hoặc log lại nếu cần)
                                System.Diagnostics.Debug.WriteLine($"Bỏ qua: Tác giả với Id '{idTacGia}' không tồn tại.");
                                continue;
                            }

                            // Nếu thỏa mãn tất cả điều kiện, thêm bản ghi mới vào danh sách
                            newRecords.Add(new SANPHAM_TACGIA
                            {
                                IdSanPham = idSanPham,
                                IdTacGia = idTacGia
                            });
                        }
                    }
                }

                // Nếu có bản ghi mới, thêm vào DB
                if (newRecords.Any())
                {
                    foreach (var record in newRecords)
                    {
                        try
                        {
                            _context.SANPHAM_TACGIA.Add(record);
                            await _context.SaveChangesAsync();
                        }
                        catch (Exception ex)
                        {
                            // Log lỗi và tiếp tục với các bản ghi khác
                            System.Diagnostics.Debug.WriteLine($"Lỗi khi thêm bản ghi (IdSanPham: {record.IdSanPham}, IdTacGia: {record.IdTacGia}): {ex.Message}");
                        }
                    }
                    TempData["Success"] = $"Đã xử lý xong file Excel. Số bản ghi mới thêm được: {newRecords.Count}";
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

            return RedirectToAction("Index");
        }


    }
}
