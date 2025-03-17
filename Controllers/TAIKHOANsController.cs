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
    public class TAIKHOANsController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public TAIKHOANsController(WebBookStoreManageContext context)
        {
            _context = context;
        }

        // GET: TAIKHOANs
        public async Task<IActionResult> Index()
        {
            var webBookStoreManageContext = _context.TAIKHOAN
                .Include(t => t.NguoiDung)
                .Include(t => t.NhanVien)
                .Include(t => t.VaiTro);
            return View(await webBookStoreManageContext.ToListAsync());
        }

        // GET: TAIKHOANs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tAIKHOAN = await _context.TAIKHOAN
                .Include(t => t.NguoiDung)
                .Include(t => t.NhanVien)
                .Include(t => t.VaiTro)
                .FirstOrDefaultAsync(m => m.IdTaiKhoan == id);
            if (tAIKHOAN == null)
            {
                return NotFound();
            }

            return View(tAIKHOAN);
        }

        // GET: TAIKHOANs/Create
        public IActionResult Create()
        {
            ViewData["IdVaiTro"] = new SelectList(_context.VAITRO, "IdVaiTro", "TenVaiTro");
            return View();
        }

        // POST: TAIKHOANs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenDangNhap,MatKhau,IdVaiTro")] TAIKHOAN tAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                // Mã hóa mật khẩu
                var passwordService = new PasswordService.PasswordService();
                tAIKHOAN.MatKhau = passwordService.HashPassword(tAIKHOAN.MatKhau);

                _context.Add(tAIKHOAN);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdVaiTro"] = new SelectList(_context.VAITRO, "IdVaiTro", "TenVaiTro", tAIKHOAN.IdVaiTro);
            return View(tAIKHOAN);
        }

        // GET: TAIKHOANs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tAIKHOAN = await _context.TAIKHOAN.FindAsync(id);
            if (tAIKHOAN == null)
            {
                return NotFound();
            }
            ViewData["IdVaiTro"] = new SelectList(_context.VAITRO, "IdVaiTro", "TenVaiTro", tAIKHOAN.IdVaiTro);
            return View(tAIKHOAN);
        }

        // POST: TAIKHOANs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTaiKhoan,TenDangNhap,MatKhau,IdVaiTro")] TAIKHOAN tAIKHOAN)
        {
            if (id != tAIKHOAN.IdTaiKhoan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Mã hóa mật khẩu
                    var passwordService = new PasswordService.PasswordService();
                    tAIKHOAN.MatKhau = passwordService.HashPassword(tAIKHOAN.MatKhau);

                    _context.Update(tAIKHOAN);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TAIKHOANExists(tAIKHOAN.IdTaiKhoan))
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
            ViewData["IdVaiTro"] = new SelectList(_context.VAITRO, "IdVaiTro", "TenVaiTro", tAIKHOAN.IdVaiTro);
            return View(tAIKHOAN);
        }

        // GET: TAIKHOANs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tAIKHOAN = await _context.TAIKHOAN
                .Include(t => t.NguoiDung)
                .Include(t => t.NhanVien)
                .Include(t => t.VaiTro)
                .FirstOrDefaultAsync(m => m.IdTaiKhoan == id);
            if (tAIKHOAN == null)
            {
                return NotFound();
            }

            return View(tAIKHOAN);
        }

        // POST: TAIKHOANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tAIKHOAN = await _context.TAIKHOAN.FindAsync(id);
            _context.TAIKHOAN.Remove(tAIKHOAN);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TAIKHOANExists(int id)
        {
            return _context.TAIKHOAN.Any(e => e.IdTaiKhoan == id);
        }
    }
}