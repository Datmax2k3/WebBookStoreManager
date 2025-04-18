using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBookStoreManage.Data;
using WebBookStoreManage.Models;
using WebBookStoreManage.ViewModels;

namespace WebBookStoreManage.Controllers
{
    public class NHANVIENsController : Controller
    {
        private readonly WebBookStoreManageContext _context;
        private readonly PasswordService.PasswordService _passwordService;


        public NHANVIENsController(WebBookStoreManageContext context, PasswordService.PasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        // GET: NHANVIENs
        public async Task<IActionResult> Index(string searchString, string currentFilter, int? pageNumber, int pageSize = 10)
        {
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var nhanVienQuery = _context.NHANVIEN
                .Include(n => n.LoaiNhanVien)
                .Include(n => n.TaiKhoan)
                .AsQueryable();

            // Áp dụng tìm kiếm nếu có
            if (!string.IsNullOrEmpty(searchString))
            {
                // Chuyển đổi searchString về chữ thường để tìm kiếm không phân biệt hoa thường
                searchString = searchString.ToLower();

                nhanVienQuery = nhanVienQuery.Where(n =>
                    n.TenNhanVien.ToLower().Contains(searchString) ||
                    n.Email.ToLower().Contains(searchString) ||
                    n.DienThoai.Contains(searchString) ||
                    (n.TaiKhoan != null && n.TaiKhoan.TenDangNhap.ToLower().Contains(searchString)) ||
                    (n.LoaiNhanVien != null && n.LoaiNhanVien.TenLoaiNhanVien.ToLower().Contains(searchString))
                );
            }

            // Sắp xếp theo tên nhân viên
            nhanVienQuery = nhanVienQuery.OrderBy(n => n.TenNhanVien);

            // Thực hiện phân trang
            var pageIndex = pageNumber ?? 1;
            var pagedNhanVien = await PaginatedList<NHANVIEN>.CreateAsync(nhanVienQuery, pageIndex, pageSize);

            return View(pagedNhanVien);
        }

        // GET: NHANVIENs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nHANVIEN = await _context.NHANVIEN
                .Include(n => n.LoaiNhanVien)
                .Include(n => n.TaiKhoan)
                .FirstOrDefaultAsync(m => m.IdNhanVien == id);
            if (nHANVIEN == null)
            {
                return NotFound();
            }

            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Create
        public IActionResult Create()
        {
            ViewData["IdLoaiNhanVien"] = new SelectList(_context.LOAINHANVIEN, "IdLoaiNhanVien", "TenLoaiNhanVien");

            // Khởi tạo ViewModel với các đối tượng rỗng
            var viewModel = new NhanVienViewModel
            {
                NhanVien = new NHANVIEN(),
                TaiKhoan = new TAIKHOAN { IdVaiTro = 2 } // Vai trò mặc định là nhân viên (2)
            };

            return View(viewModel);
        }

        // POST: NHANVIENs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NhanVienViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        // Kiểm tra tên đăng nhập đã tồn tại chưa
                        if (await _context.TAIKHOAN.AnyAsync(t => t.TenDangNhap == viewModel.TaiKhoan.TenDangNhap))
                        {
                            ModelState.AddModelError("TaiKhoan.TenDangNhap", "Tên đăng nhập đã tồn tại!");
                            ViewData["IdLoaiNhanVien"] = new SelectList(_context.LOAINHANVIEN, "IdLoaiNhanVien", "TenLoaiNhanVien", viewModel.NhanVien.IdLoaiNhanVien);
                            return View(viewModel);
                        }

                        // Mã hóa mật khẩu sử dụng PasswordService
                        viewModel.TaiKhoan.MatKhau = _passwordService.HashPassword(viewModel.TaiKhoan.MatKhau);

                        // Thêm tài khoản
                        _context.TAIKHOAN.Add(viewModel.TaiKhoan);
                        await _context.SaveChangesAsync();

                        // Thiết lập thông tin cho nhân viên
                        viewModel.NhanVien.IdTaiKhoan = viewModel.TaiKhoan.IdTaiKhoan;
                        viewModel.NhanVien.NgayVaoLam = DateTime.Now;

                        // Thêm nhân viên
                        _context.NHANVIEN.Add(viewModel.NhanVien);
                        await _context.SaveChangesAsync();

                        // Commit transaction nếu tất cả thành công
                        transaction.Commit();

                        TempData["Success"] = "Đã thêm nhân viên mới thành công!";
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        // Rollback nếu có lỗi
                        transaction.Rollback();

                        ModelState.AddModelError("", $"Có lỗi xảy ra: {ex.Message}");
                        TempData["Error"] = "Có lỗi xảy ra khi thêm nhân viên mới!";
                    }
                }
            }

            ViewData["IdLoaiNhanVien"] = new SelectList(_context.LOAINHANVIEN, "IdLoaiNhanVien", "TenLoaiNhanVien", viewModel.NhanVien.IdLoaiNhanVien);
            return View(viewModel);
        }

        // GET: NHANVIENs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nHANVIEN = await _context.NHANVIEN.FindAsync(id);
            if (nHANVIEN == null)
            {
                return NotFound();
            }
            ViewData["IdLoaiNhanVien"] = new SelectList(_context.LOAINHANVIEN, "IdLoaiNhanVien", "TenLoaiNhanVien", nHANVIEN.IdLoaiNhanVien);
            var availableTaiKhoans = _context.TAIKHOAN
                .Where(t => t.NhanVien == null || t.IdTaiKhoan == nHANVIEN.IdTaiKhoan)
                .Select(t => new { t.IdTaiKhoan, t.TenDangNhap });
            ViewData["IdTaiKhoan"] = new SelectList(availableTaiKhoans, "IdTaiKhoan", "TenDangNhap", nHANVIEN.IdTaiKhoan);
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNhanVien,TenNhanVien,Email,DienThoai,NgayVaoLam,IdLoaiNhanVien,IdTaiKhoan")] NHANVIEN nHANVIEN)
        {
            if (id != nHANVIEN.IdNhanVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nHANVIEN);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NHANVIENExists(nHANVIEN.IdNhanVien))
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
            ViewData["IdLoaiNhanVien"] = new SelectList(_context.LOAINHANVIEN, "IdLoaiNhanVien", "TenLoaiNhanVien", nHANVIEN.IdLoaiNhanVien);
            var availableTaiKhoans = _context.TAIKHOAN
                .Where(t => t.NhanVien == null || t.IdTaiKhoan == nHANVIEN.IdTaiKhoan)
                .Select(t => new { t.IdTaiKhoan, t.TenDangNhap });
            ViewData["IdTaiKhoan"] = new SelectList(availableTaiKhoans, "IdTaiKhoan", "TenDangNhap", nHANVIEN.IdTaiKhoan);
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nHANVIEN = await _context.NHANVIEN
                .Include(n => n.LoaiNhanVien)
                .Include(n => n.TaiKhoan)
                .FirstOrDefaultAsync(m => m.IdNhanVien == id);
            if (nHANVIEN == null)
            {
                return NotFound();
            }

            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nHANVIEN = await _context.NHANVIEN.FindAsync(id);
            _context.NHANVIEN.Remove(nHANVIEN);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NHANVIENExists(int id)
        {
            return _context.NHANVIEN.Any(e => e.IdNhanVien == id);
        }
    }
}