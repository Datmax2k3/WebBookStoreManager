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
    public class DONHANGsController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public DONHANGsController(WebBookStoreManageContext context)
        {
            _context = context;
        }

        // GET: DONHANGs
        public async Task<IActionResult> Index()
        {
            var webBookStoreManageContext = _context.DONHANG.Include(d => d.NhanVien).Include(d => d.PhieuDat);
            return View(await webBookStoreManageContext.ToListAsync());
        }

        // GET: DONHANGs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dONHANG = await _context.DONHANG
                .Include(d => d.NhanVien)
                .Include(d => d.PhieuDat)
                .FirstOrDefaultAsync(m => m.IdDonHang == id);
            if (dONHANG == null)
            {
                return NotFound();
            }

            return View(dONHANG);
        }

        // GET: DONHANGs/Create
        public IActionResult Create()
        {
            ViewData["IdNhanVien"] = new SelectList(_context.NHANVIEN, "IdNhanVien", "DienThoai");
            ViewData["IdPhieuDat"] = new SelectList(_context.PHIEUDAT, "IdPhieuDat", "IdPhieuDat");
            return View();
        }

        // POST: DONHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDonHang,TrangThaiDonHang,NgayThanhToan,NgayGiaoHang,IdPhieuDat,IdNhanVien")] DONHANG dONHANG)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dONHANG);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNhanVien"] = new SelectList(_context.NHANVIEN, "IdNhanVien", "DienThoai", dONHANG.IdNhanVien);
            ViewData["IdPhieuDat"] = new SelectList(_context.PHIEUDAT, "IdPhieuDat", "IdPhieuDat", dONHANG.IdPhieuDat);
            return View(dONHANG);
        }

        // GET: DONHANGs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dONHANG = await _context.DONHANG.FindAsync(id);
            if (dONHANG == null)
            {
                return NotFound();
            }
            ViewData["IdNhanVien"] = new SelectList(_context.NHANVIEN, "IdNhanVien", "DienThoai", dONHANG.IdNhanVien);
            ViewData["IdPhieuDat"] = new SelectList(_context.PHIEUDAT, "IdPhieuDat", "IdPhieuDat", dONHANG.IdPhieuDat);
            return View(dONHANG);
        }

        // POST: DONHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDonHang,TrangThaiDonHang,NgayThanhToan,NgayGiaoHang,IdPhieuDat,IdNhanVien")] DONHANG dONHANG)
        {
            if (id != dONHANG.IdDonHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dONHANG);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DONHANGExists(dONHANG.IdDonHang))
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
            ViewData["IdNhanVien"] = new SelectList(_context.NHANVIEN, "IdNhanVien", "DienThoai", dONHANG.IdNhanVien);
            ViewData["IdPhieuDat"] = new SelectList(_context.PHIEUDAT, "IdPhieuDat", "IdPhieuDat", dONHANG.IdPhieuDat);
            return View(dONHANG);
        }

        // GET: DONHANGs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dONHANG = await _context.DONHANG
                .Include(d => d.NhanVien)
                .Include(d => d.PhieuDat)
                .FirstOrDefaultAsync(m => m.IdDonHang == id);
            if (dONHANG == null)
            {
                return NotFound();
            }

            return View(dONHANG);
        }

        // POST: DONHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dONHANG = await _context.DONHANG.FindAsync(id);
            _context.DONHANG.Remove(dONHANG);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DONHANGExists(int id)
        {
            return _context.DONHANG.Any(e => e.IdDonHang == id);
        }
    }
}
