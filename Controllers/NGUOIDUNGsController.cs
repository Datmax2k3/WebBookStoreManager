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
        public async Task<IActionResult> Index()
        {
            var webBookStoreManageContext = _context.NGUOIDUNG
                .Include(n => n.TaiKhoan);
            return View(await webBookStoreManageContext.ToListAsync());
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