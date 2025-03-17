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
    public class NHANVIENsController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public NHANVIENsController(WebBookStoreManageContext context)
        {
            _context = context;
        }

        // GET: NHANVIENs
        public async Task<IActionResult> Index()
        {
            var webBookStoreManageContext = _context.NHANVIEN
                .Include(n => n.LoaiNhanVien)
                .Include(n => n.TaiKhoan);
            return View(await webBookStoreManageContext.ToListAsync());
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
            var availableTaiKhoans = _context.TAIKHOAN
                .Where(t => t.NhanVien == null && t.NguoiDung == null)
                .Select(t => new { t.IdTaiKhoan, t.TenDangNhap });
            ViewData["IdTaiKhoan"] = new SelectList(availableTaiKhoans, "IdTaiKhoan", "TenDangNhap");
            return View();
        }

        // POST: NHANVIENs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenNhanVien,Email,DienThoai,IdLoaiNhanVien,IdTaiKhoan")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                nHANVIEN.NgayVaoLam = DateTime.Now;
                _context.Add(nHANVIEN);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLoaiNhanVien"] = new SelectList(_context.LOAINHANVIEN, "IdLoaiNhanVien", "TenLoaiNhanVien", nHANVIEN.IdLoaiNhanVien);
            var availableTaiKhoans = _context.TAIKHOAN
                .Where(t => t.NhanVien == null && t.NguoiDung == null)
                .Select(t => new { t.IdTaiKhoan, t.TenDangNhap });
            ViewData["IdTaiKhoan"] = new SelectList(availableTaiKhoans, "IdTaiKhoan", "TenDangNhap", nHANVIEN.IdTaiKhoan);
            return View(nHANVIEN);
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