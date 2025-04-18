﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using WebBookStoreManage.Data;
using WebBookStoreManage.Models;

namespace WebBookStoreManage.Controllers
{
    public class SANPHAMsController : Controller
    {
        private readonly WebBookStoreManageContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public SANPHAMsController(WebBookStoreManageContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: SANPHAMs
        public async Task<IActionResult> Index(
            string searchKeyword = "",
            int? categoryId = null,
            string status = "",
            string sortBy = "newest",
            int page = 1,
            int pageSize = 10)
        {
            // Đảm bảo page và pageSize hợp lệ
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            // Lấy danh sách sản phẩm dưới dạng IQueryable để áp dụng lọc và phân trang
            var products = _context.SANPHAM
                .Include(s => s.DanhMucChiTiet)
                .ThenInclude(d => d.DanhMuc)
                .AsQueryable();

            // Lọc theo từ khóa (tên sản phẩm hoặc mã sản phẩm)
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                products = products.Where(p =>
                    p.TenSanPham.Contains(searchKeyword) ||
                    p.IdSanPham.Contains(searchKeyword));
            }

            // Lọc theo danh mục
            if (categoryId.HasValue && categoryId > 0)
            {
                products = products.Where(p => p.IdDanhMucCT == categoryId);
            }

            // Lọc theo trạng thái
            if (!string.IsNullOrEmpty(status))
            {
                products = products.Where(p => p.TrangThai == status);
            }

            // Sắp xếp sản phẩm
            products = sortBy switch
            {
                "priceAsc" => products.OrderBy(p => p.GiaBan ?? p.GiaGoc),
                "priceDesc" => products.OrderByDescending(p => p.GiaBan ?? p.GiaGoc),
                "nameAsc" => products.OrderBy(p => p.TenSanPham),
                "nameDesc" => products.OrderByDescending(p => p.TenSanPham),
                "bestSeller" => products.OrderByDescending(p => p.SoLuongDaBan),
                _ => products.OrderByDescending(p => p.IdSanPham) // newest by default
            };

            // Tính tổng số bản ghi sau khi áp dụng các điều kiện lọc
            var totalItems = await products.CountAsync();

            // Tính tổng số trang
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            // Đảm bảo page không vượt quá tổng số trang (nếu có bản ghi)
            if (page > totalPages && totalPages > 0)
                page = totalPages;

            // Lấy danh sách sản phẩm cho trang hiện tại
            var items = await products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Chuẩn bị danh sách danh mục để hiển thị trong dropdown
            var categories = await _context.DANHMUCCHITIET
                .Include(d => d.DanhMuc)
                .OrderBy(d => d.DanhMuc.ThuTu)
                .ThenBy(d => d.TenDanhMucCT)
                .ToListAsync();

            // Truyền dữ liệu vào ViewBag để sử dụng trong view
            ViewBag.TotalItems = totalItems;
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.SearchKeyword = searchKeyword;
            ViewBag.CategoryId = categoryId;
            ViewBag.Status = status;
            ViewBag.SortBy = sortBy;
            ViewBag.Categories = new SelectList(categories, "IdDanhMucCT", "TenDanhMucCT", categoryId);

            return View(items);
        }


        // GET: SANPHAMs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sANPHAM = await _context.SANPHAM
                .Include(s => s.DanhMucChiTiet)
                .FirstOrDefaultAsync(m => m.IdSanPham == id);
            if (sANPHAM == null)
            {
                return NotFound();
            }

            return View(sANPHAM);
        }

        // GET: SANPHAMs/Create
        public IActionResult Create()
        {
            // Thêm dòng này để truyền danh mục vào ViewBag
            ViewBag.Categories = _context.DANHMUCCHITIET
                .Select(d => new {
                    Id = d.IdDanhMucCT,
                    TenDanhMuc = d.TenDanhMucCT
                })
                .ToList();

            // Giữ nguyên dòng này
            ViewData["IdDanhMucCT"] = new SelectList(_context.DANHMUCCHITIET, "IdDanhMucCT", "TenDanhMucCT");

            return View();
        }

        // POST: SANPHAMs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SANPHAM sANPHAM, IFormFile hinhAnh)
        {
            // Kiểm tra dữ liệu đầu vào
            if (ModelState.IsValid)
            {
                // Xử lý upload hình ảnh
                if (hinhAnh != null && hinhAnh.Length > 0)
                {
                    // Tạo thư mục nếu chưa tồn tại
                    string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images", "product");
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    // Tạo tên file duy nhất
                    string uniqueFileName = Path.GetFileName(hinhAnh.FileName);
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);

                    // Lưu file
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await hinhAnh.CopyToAsync(fileStream);
                    }

                    // Lưu đường dẫn tương đối vào model
                    sANPHAM.hinhAnh = $"{uniqueFileName}";
                }

                // Lưu sản phẩm vào database
                _context.Add(sANPHAM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Nếu ModelState không hợp lệ, truyền lại danh mục
            ViewBag.Categories = _context.DANHMUCCHITIET
                .Select(d => new {
                    Id = d.IdDanhMucCT,
                    TenDanhMuc = d.TenDanhMucCT
                })
                .ToList();

            return View(sANPHAM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sANPHAM = await _context.SANPHAM.FindAsync(id);
            if (sANPHAM == null)
            {
                return NotFound();
            }

            // Lấy danh sách danh mục để hiển thị trong dropdown
            ViewData["IdDanhMucCT"] = new SelectList(_context.DANHMUCCHITIET, "IdDanhMucCT", "TenDanhMucCT", sANPHAM.IdDanhMucCT);

            return View(sANPHAM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, SANPHAM sANPHAM, IFormFile hinhAnh)
        {
            if (id != sANPHAM.IdSanPham)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Lấy thông tin sản phẩm hiện tại từ database để giữ lại các thông tin không thay đổi
                    var existingProduct = await _context.SANPHAM.AsNoTracking().FirstOrDefaultAsync(p => p.IdSanPham == id);
                    if (existingProduct == null)
                    {
                        return NotFound();
                    }

                    // Xử lý upload hình ảnh mới nếu có
                    if (hinhAnh != null && hinhAnh.Length > 0)
                    {
                        // Tạo thư mục nếu chưa tồn tại
                        string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images", "product");
                        if (!Directory.Exists(uploadFolder))
                        {
                            Directory.CreateDirectory(uploadFolder);
                        }

                        // Xóa file ảnh cũ nếu có
                        if (!string.IsNullOrEmpty(existingProduct.hinhAnh))
                        {
                            string oldFileName = Path.GetFileName(existingProduct.hinhAnh);
                            string oldFilePath = Path.Combine(uploadFolder, oldFileName);
                            if (System.IO.File.Exists(oldFilePath))
                            {
                                System.IO.File.Delete(oldFilePath);
                            }
                        }

                        // Tạo tên file duy nhất
                        string uniqueFileName = Path.GetFileName(hinhAnh.FileName);
                        string filePath = Path.Combine(uploadFolder, uniqueFileName);

                        // Lưu file
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await hinhAnh.CopyToAsync(fileStream);
                        }

                        // Cập nhật đường dẫn tương đối vào model
                        sANPHAM.hinhAnh = $"/images/product/{uniqueFileName}";
                    }
                    else
                    {
                        // Giữ nguyên đường dẫn hình ảnh cũ nếu không có upload hình mới
                        sANPHAM.hinhAnh = existingProduct.hinhAnh;
                    }

                    // Cập nhật sản phẩm vào database
                    _context.Update(sANPHAM);
                    await _context.SaveChangesAsync();

                    TempData["Success"] = "Cập nhật sản phẩm thành công!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SANPHAMExists(sANPHAM.IdSanPham))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"Lỗi khi cập nhật sản phẩm: {ex.Message}";
                    ModelState.AddModelError("", "Có lỗi xảy ra khi cập nhật sản phẩm. Vui lòng thử lại.");
                }
            }

            // Nếu ModelState không hợp lệ hoặc có lỗi, trả về view với dữ liệu hiện tại
            ViewData["IdDanhMucCT"] = new SelectList(_context.DANHMUCCHITIET, "IdDanhMucCT", "TenDanhMucCT", sANPHAM.IdDanhMucCT);
            return View(sANPHAM);
        }

        // GET: SANPHAMs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sANPHAM = await _context.SANPHAM
                .Include(s => s.DanhMucChiTiet)
                .FirstOrDefaultAsync(m => m.IdSanPham == id);
            if (sANPHAM == null)
            {
                return NotFound();
            }

            return View(sANPHAM);
        }

        // POST: SANPHAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sANPHAM = await _context.SANPHAM.FindAsync(id);
            if (sANPHAM == null)
            {
                return NotFound();
            }

            try
            {
                // Xóa file ảnh nếu có
                if (!string.IsNullOrEmpty(sANPHAM.hinhAnh))
                {
                    // Lấy tên file từ đường dẫn
                    string fileName = Path.GetFileName(sANPHAM.hinhAnh);

                    // Tạo đường dẫn đầy đủ đến file ảnh
                    string imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "product", fileName);

                    // Kiểm tra file có tồn tại không
                    if (System.IO.File.Exists(imagePath))
                    {
                        // Xóa file
                        System.IO.File.Delete(imagePath);
                    }
                }

                // Xóa sản phẩm khỏi database
                _context.SANPHAM.Remove(sANPHAM);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Xóa sản phẩm thành công!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Có lỗi xảy ra khi xóa sản phẩm: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        private bool SANPHAMExists(string id)
        {
            return _context.SANPHAM.Any(e => e.IdSanPham == id);
        }

        // GET: /SANPHAM/AddToExcel
        [HttpGet]
        public IActionResult AddToExcel()
        {
            return View();
        }

        // POST: /SANPHAM/AddToExcel
        [HttpPost]
        public async Task<IActionResult> AddToExcel(IFormFile excelFile)
        {
            // Kiểm tra file Excel có được upload hay không
            if (excelFile == null || excelFile.Length == 0)
            {
                TempData["Error"] = "Bạn chưa chọn file Excel.";
                return View();
            }

            var products = new List<SANPHAM>(); // Danh sách sản phẩm hợp lệ
            var errors = new List<string>();    // Danh sách lưu lỗi chi tiết

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

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
                        for (int row = 2; row <= rowCount; row++)
                        {
                            try
                            {
                                // Đọc dữ liệu từ các cột
                                string idSanPham = worksheet.Cells[row, 1].Value?.ToString().Trim();
                                string idDanhMucCTStr = worksheet.Cells[row, 2].Value?.ToString().Trim();
                                string tenSanPham = worksheet.Cells[row, 3].Value?.ToString().Trim();
                                string giaGocStr = worksheet.Cells[row, 4].Value?.ToString().Trim();
                                string giamGiaStr = worksheet.Cells[row, 5].Value?.ToString().Trim();
                                string ngayXuatBanStr = worksheet.Cells[row, 6].Value?.ToString().Trim();
                                string soLuotXemStr = worksheet.Cells[row, 7].Value?.ToString().Trim();
                                string soLuongConStr = worksheet.Cells[row, 8].Value?.ToString().Trim();
                                string soLuongDaBanStr = worksheet.Cells[row, 9].Value?.ToString().Trim();
                                string moTaChiTiet = worksheet.Cells[row, 10].Value?.ToString().Trim();
                                string trangThai = worksheet.Cells[row, 11].Value?.ToString().Trim();
                                string hinhAnh = worksheet.Cells[row, 12].Value?.ToString().Trim();

                                // Kiểm tra dữ liệu bắt buộc
                                if (string.IsNullOrEmpty(idSanPham))
                                {
                                    errors.Add($"Dòng {row}: IdSanPham không được để trống.");
                                    continue;
                                }
                                if (string.IsNullOrEmpty(tenSanPham))
                                {
                                    errors.Add($"Dòng {row}: TenSanPham không được để trống.");
                                    continue;
                                }

                                // Chuyển đổi và kiểm tra dữ liệu số/ngày tháng
                                if (!int.TryParse(idDanhMucCTStr, out int idDanhMucCT))
                                {
                                    errors.Add($"Dòng {row}: IdDanhMucCT không hợp lệ.");
                                    continue;
                                }
                                if (!decimal.TryParse(giaGocStr, out decimal giaGoc))
                                {
                                    errors.Add($"Dòng {row}: GiaGoc không hợp lệ.");
                                    continue;
                                }
                                decimal giamGia = 0m;
                                if (!string.IsNullOrEmpty(giamGiaStr) && !decimal.TryParse(giamGiaStr, out giamGia))
                                {
                                    errors.Add($"Dòng {row}: GiamGia không hợp lệ.");
                                    continue;
                                }
                                DateTime? ngayXuatBan = null;
                                if (!string.IsNullOrEmpty(ngayXuatBanStr))
                                {
                                    if (DateTime.TryParse(ngayXuatBanStr, out DateTime parsedDate))
                                    {
                                        ngayXuatBan = parsedDate;
                                    }
                                    else
                                    {
                                        errors.Add($"Dòng {row}: NgayXuatBan không hợp lệ.");
                                        continue;
                                    }
                                }
                                int soLuotXem = 0;
                                if (!string.IsNullOrEmpty(soLuotXemStr) && !int.TryParse(soLuotXemStr, out soLuotXem))
                                {
                                    errors.Add($"Dòng {row}: SoLuotXem không hợp lệ.");
                                    continue;
                                }
                                int soLuongCon = 0;
                                if (!string.IsNullOrEmpty(soLuongConStr) && !int.TryParse(soLuongConStr, out soLuongCon))
                                {
                                    errors.Add($"Dòng {row}: SoLuongCon không hợp lệ.");
                                    continue;
                                }
                                int soLuongDaBan = 0;
                                if (!string.IsNullOrEmpty(soLuongDaBanStr) && !int.TryParse(soLuongDaBanStr, out soLuongDaBan))
                                {
                                    errors.Add($"Dòng {row}: SoLuongDaBan không hợp lệ.");
                                    continue;
                                }

                                // Kiểm tra độ dài
                                if (idSanPham.Length > 7)
                                {
                                    errors.Add($"Dòng {row}: IdSanPham vượt quá 7 ký tự.");
                                    continue;
                                }
                                if (tenSanPham.Length > 500)
                                {
                                    errors.Add($"Dòng {row}: TenSanPham vượt quá 500 ký tự.");
                                    continue;
                                }
                                if (!string.IsNullOrEmpty(hinhAnh) && hinhAnh.Length > 500)
                                {
                                    errors.Add($"Dòng {row}: hinhAnh vượt quá 500 ký tự.");
                                    continue;
                                }

                                // Kiểm tra khóa ngoại IdDanhMucCT
                                if (!_context.DANHMUCCHITIET.Any(d => d.IdDanhMucCT == idDanhMucCT))
                                {
                                    errors.Add($"Dòng {row}: IdDanhMucCT '{idDanhMucCT}' không tồn tại.");
                                    continue;
                                }

                                // Kiểm tra sản phẩm đã tồn tại
                                if (_context.SANPHAM.Any(s => s.IdSanPham == idSanPham))
                                {
                                    errors.Add($"Dòng {row}: Sản phẩm với IdSanPham '{idSanPham}' đã tồn tại.");
                                    continue;
                                }

                                // Tạo đối tượng sản phẩm nếu dữ liệu hợp lệ
                                var product = new SANPHAM
                                {
                                    IdSanPham = idSanPham,
                                    IdDanhMucCT = idDanhMucCT,
                                    TenSanPham = tenSanPham,
                                    GiaGoc = giaGoc,
                                    GiamGia = giamGia,
                                    NgayXuatBan = ngayXuatBan,
                                    SoLuotXem = soLuotXem,
                                    SoLuongCon = soLuongCon,
                                    SoLuongDaBan = soLuongDaBan,
                                    MoTaChiTiet = moTaChiTiet,
                                    TrangThai = string.IsNullOrEmpty(trangThai) ? "conHang" : trangThai,
                                    hinhAnh = hinhAnh
                                };

                                products.Add(product);
                            }
                            catch (Exception ex)
                            {
                                errors.Add($"Dòng {row}: Lỗi khi xử lý dữ liệu - {ex.Message}");
                            }
                        }
                    }
                }

                // Lưu dữ liệu hợp lệ vào DB
                if (products.Any())
                {
                    try
                    {
                        // Thêm danh sách sản phẩm vào DbContext
                        _context.SANPHAM.AddRange(products);
                        await _context.SaveChangesAsync();
                        TempData["Success"] = $"Thêm thành công {products.Count} sản phẩm.";
                    }
                    catch (DbUpdateException ex)
                    {
                        // Lấy thông tin chi tiết từ inner exception
                        var innerException = ex.InnerException?.Message ?? ex.Message;
                        TempData["Error"] = $"Lỗi khi lưu vào cơ sở dữ liệu: {innerException}";
                    }
                }
            }
            catch (Exception ex)
            {
                errors.Add($"Lỗi chung khi xử lý file Excel: {ex.Message}");
            }

            // Hiển thị thông báo lỗi chi tiết nếu có
            if (errors.Any())
            {
                TempData["Error"] = string.Join("<br/>", errors);
            }
            else if (!products.Any())
            {
                TempData["Error"] = "Không có dữ liệu hợp lệ để thêm.";
            }

            return RedirectToAction("Index");
        }
    }
}
