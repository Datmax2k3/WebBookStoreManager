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
    public class GIOHANGsController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public GIOHANGsController(WebBookStoreManageContext context)
        {
            _context = context;
        }

        // GET: GIOHANGs
        public async Task<IActionResult> Index()
        {
            var webBookStoreManageContext = _context.GIOHANG.Include(g => g.NguoiDung).Include(g => g.SanPham);
            return View(await webBookStoreManageContext.ToListAsync());
        }

        // GET: GIOHANGs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gIOHANG = await _context.GIOHANG
                .Include(g => g.NguoiDung)
                .Include(g => g.SanPham)
                .FirstOrDefaultAsync(m => m.IdSanPham == id);
            if (gIOHANG == null)
            {
                return NotFound();
            }

            return View(gIOHANG);
        }

        // GET: GIOHANGs/Create
        public IActionResult Create()
        {
            ViewData["IdNguoiDung"] = new SelectList(_context.NGUOIDUNG, "IdNguoiDung", "Email");
            ViewData["IdSanPham"] = new SelectList(_context.SANPHAM, "IdSanPham", "IdSanPham");
            return View();
        }

        // POST: GIOHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSanPham,IdNguoiDung,SoLuong")] GIOHANG gIOHANG)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gIOHANG);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNguoiDung"] = new SelectList(_context.NGUOIDUNG, "IdNguoiDung", "Email", gIOHANG.IdNguoiDung);
            ViewData["IdSanPham"] = new SelectList(_context.SANPHAM, "IdSanPham", "IdSanPham", gIOHANG.IdSanPham);
            return View(gIOHANG);
        }

        // GET: GIOHANGs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gIOHANG = await _context.GIOHANG.FindAsync(id);
            if (gIOHANG == null)
            {
                return NotFound();
            }
            ViewData["IdNguoiDung"] = new SelectList(_context.NGUOIDUNG, "IdNguoiDung", "Email", gIOHANG.IdNguoiDung);
            ViewData["IdSanPham"] = new SelectList(_context.SANPHAM, "IdSanPham", "IdSanPham", gIOHANG.IdSanPham);
            return View(gIOHANG);
        }

        // POST: GIOHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdSanPham,IdNguoiDung,SoLuong")] GIOHANG gIOHANG)
        {
            if (id != gIOHANG.IdSanPham)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gIOHANG);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GIOHANGExists(gIOHANG.IdSanPham))
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
            ViewData["IdNguoiDung"] = new SelectList(_context.NGUOIDUNG, "IdNguoiDung", "Email", gIOHANG.IdNguoiDung);
            ViewData["IdSanPham"] = new SelectList(_context.SANPHAM, "IdSanPham", "IdSanPham", gIOHANG.IdSanPham);
            return View(gIOHANG);
        }

        // GET: GIOHANGs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gIOHANG = await _context.GIOHANG
                .Include(g => g.NguoiDung)
                .Include(g => g.SanPham)
                .FirstOrDefaultAsync(m => m.IdSanPham == id);
            if (gIOHANG == null)
            {
                return NotFound();
            }

            return View(gIOHANG);
        }

        // POST: GIOHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var gIOHANG = await _context.GIOHANG.FindAsync(id);
            _context.GIOHANG.Remove(gIOHANG);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GIOHANGExists(string id)
        {
            return _context.GIOHANG.Any(e => e.IdSanPham == id);
        }
    }
}
