using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBookStoreManage.Data;
using WebBookStoreManage.Models;

namespace WebBookStoreManage.Controllers
{
    public class NGUOIDUNGsController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public NGUOIDUNGsController(WebBookStoreManageContext context)
        {
            _context = context;
        }

        // GET: NGUOIDUNGs
        // GET: NGUOIDUNGs
        public async Task<IActionResult> Index(
            string searchString,
            string currentFilter,
            int? pageNumber,
            int pageSize = 10)
        {
            // Nếu có search mới, reset pageNumber về 1
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            // 1. Build query và include tài khoản
            var userQuery = _context.NGUOIDUNG
                .Include(u => u.TaiKhoan)
                .AsQueryable();

            // 2. Áp dụng tìm kiếm không phân biệt hoa thường
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                var lower = searchString.ToLower();
                userQuery = userQuery.Where(u =>
                    u.TenNguoiDung.ToLower().Contains(lower) ||
                    u.Email.ToLower().Contains(lower) ||
                    (u.DiaChi != null && u.DiaChi.ToLower().Contains(lower)) ||
                    (u.soDienThoai != null && u.soDienThoai.Contains(lower)) ||
                    (u.TaiKhoan != null && u.TaiKhoan.TenDangNhap.ToLower().Contains(lower))
                );
            }

            // 3. Sắp xếp (ví dụ theo tên)
            userQuery = userQuery.OrderBy(u => u.TenNguoiDung);

            // 4. Phân trang
            var pagedUsers = await PaginatedList<NGUOIDUNG>
                .CreateAsync(userQuery, pageNumber ?? 1, pageSize);

            return View(pagedUsers);
        }



        // GET: NGUOIDUNGs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nGUOIDUNG = await _context.NGUOIDUNG
                .Include(n => n.TaiKhoan)
                .FirstOrDefaultAsync(m => m.IdNguoiDung == id);
            if (nGUOIDUNG == null)
            {
                return NotFound();
            }

            return View(nGUOIDUNG);
        }

        // GET: NGUOIDUNGs/Create
        public IActionResult Create()
        {
            var availableTaiKhoans = _context.TAIKHOAN
                .Where(t => t.NguoiDung == null && t.NhanVien == null)
                .Select(t => new { t.IdTaiKhoan, t.TenDangNhap });
            ViewData["IdTaiKhoan"] = new SelectList(availableTaiKhoans, "IdTaiKhoan", "TenDangNhap");
            return View();
        }

        // POST: NGUOIDUNGs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenNguoiDung,Email,DiaChi,IdTaiKhoan")] NGUOIDUNG nGUOIDUNG)
        {
            if (ModelState.IsValid)
            {
                nGUOIDUNG.NgayDangKy = DateTime.Now;
                _context.Add(nGUOIDUNG);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var availableTaiKhoans = _context.TAIKHOAN
                .Where(t => t.NguoiDung == null && t.NhanVien == null)
                .Select(t => new { t.IdTaiKhoan, t.TenDangNhap });
            ViewData["IdTaiKhoan"] = new SelectList(availableTaiKhoans, "IdTaiKhoan", "TenDangNhap", nGUOIDUNG.IdTaiKhoan);
            return View(nGUOIDUNG);
        }

        // GET: NGUOIDUNGs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nGUOIDUNG = await _context.NGUOIDUNG.FindAsync(id);
            if (nGUOIDUNG == null)
            {
                return NotFound();
            }
            var availableTaiKhoans = _context.TAIKHOAN
                .Where(t => t.NguoiDung == null || t.IdTaiKhoan == nGUOIDUNG.IdTaiKhoan)
                .Select(t => new { t.IdTaiKhoan, t.TenDangNhap });
            ViewData["IdTaiKhoan"] = new SelectList(availableTaiKhoans, "IdTaiKhoan", "TenDangNhap", nGUOIDUNG.IdTaiKhoan);
            return View(nGUOIDUNG);
        }

        // POST: NGUOIDUNGs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNguoiDung,TenNguoiDung,Email,DiaChi,NgayDangKy,IdTaiKhoan")] NGUOIDUNG nGUOIDUNG)
        {
            if (id != nGUOIDUNG.IdNguoiDung)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nGUOIDUNG);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NGUOIDUNGExists(nGUOIDUNG.IdNguoiDung))
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
            var availableTaiKhoans = _context.TAIKHOAN
                .Where(t => t.NguoiDung == null || t.IdTaiKhoan == nGUOIDUNG.IdTaiKhoan)
                .Select(t => new { t.IdTaiKhoan, t.TenDangNhap });
            ViewData["IdTaiKhoan"] = new SelectList(availableTaiKhoans, "IdTaiKhoan", "TenDangNhap", nGUOIDUNG.IdTaiKhoan);
            return View(nGUOIDUNG);
        }

        // GET: NGUOIDUNGs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nGUOIDUNG = await _context.NGUOIDUNG
                .Include(n => n.TaiKhoan)
                .FirstOrDefaultAsync(m => m.IdNguoiDung == id);
            if (nGUOIDUNG == null)
            {
                return NotFound();
            }

            return View(nGUOIDUNG);
        }

        // POST: NGUOIDUNGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nGUOIDUNG = await _context.NGUOIDUNG.FindAsync(id);
            _context.NGUOIDUNG.Remove(nGUOIDUNG);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NGUOIDUNGExists(int id)
        {
            return _context.NGUOIDUNG.Any(e => e.IdNguoiDung == id);
        }
    }
}