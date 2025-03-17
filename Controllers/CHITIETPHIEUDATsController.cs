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
    public class CHITIETPHIEUDATsController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public CHITIETPHIEUDATsController(WebBookStoreManageContext context)
        {
            _context = context;
        }

        // GET: CHITIETPHIEUDATs
        public async Task<IActionResult> Index()
        {
            var webBookStoreManageContext = _context.CHITIETPHIEUDAT.Include(c => c.PhieuDat).Include(c => c.SanPham);
            return View(await webBookStoreManageContext.ToListAsync());
        }

        // GET: CHITIETPHIEUDATs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cHITIETPHIEUDAT = await _context.CHITIETPHIEUDAT
                .Include(c => c.PhieuDat)
                .Include(c => c.SanPham)
                .FirstOrDefaultAsync(m => m.IdChiTietPhieuDat == id);
            if (cHITIETPHIEUDAT == null)
            {
                return NotFound();
            }

            return View(cHITIETPHIEUDAT);
        }

        // GET: CHITIETPHIEUDATs/Create
        public IActionResult Create()
        {
            ViewData["IdPhieuDat"] = new SelectList(_context.PHIEUDAT, "IdPhieuDat", "IdPhieuDat");
            ViewData["IdSanPham"] = new SelectList(_context.SANPHAM, "IdSanPham", "IdSanPham");
            return View();
        }

        // POST: CHITIETPHIEUDATs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdChiTietPhieuDat,SoLuong,IdPhieuDat,IdSanPham,ThanhTien")] CHITIETPHIEUDAT cHITIETPHIEUDAT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cHITIETPHIEUDAT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPhieuDat"] = new SelectList(_context.PHIEUDAT, "IdPhieuDat", "IdPhieuDat", cHITIETPHIEUDAT.IdPhieuDat);
            ViewData["IdSanPham"] = new SelectList(_context.SANPHAM, "IdSanPham", "IdSanPham", cHITIETPHIEUDAT.IdSanPham);
            return View(cHITIETPHIEUDAT);
        }

        // GET: CHITIETPHIEUDATs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cHITIETPHIEUDAT = await _context.CHITIETPHIEUDAT.FindAsync(id);
            if (cHITIETPHIEUDAT == null)
            {
                return NotFound();
            }
            ViewData["IdPhieuDat"] = new SelectList(_context.PHIEUDAT, "IdPhieuDat", "IdPhieuDat", cHITIETPHIEUDAT.IdPhieuDat);
            ViewData["IdSanPham"] = new SelectList(_context.SANPHAM, "IdSanPham", "IdSanPham", cHITIETPHIEUDAT.IdSanPham);
            return View(cHITIETPHIEUDAT);
        }

        // POST: CHITIETPHIEUDATs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdChiTietPhieuDat,SoLuong,IdPhieuDat,IdSanPham,ThanhTien")] CHITIETPHIEUDAT cHITIETPHIEUDAT)
        {
            if (id != cHITIETPHIEUDAT.IdChiTietPhieuDat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cHITIETPHIEUDAT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CHITIETPHIEUDATExists(cHITIETPHIEUDAT.IdChiTietPhieuDat))
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
            ViewData["IdPhieuDat"] = new SelectList(_context.PHIEUDAT, "IdPhieuDat", "IdPhieuDat", cHITIETPHIEUDAT.IdPhieuDat);
            ViewData["IdSanPham"] = new SelectList(_context.SANPHAM, "IdSanPham", "IdSanPham", cHITIETPHIEUDAT.IdSanPham);
            return View(cHITIETPHIEUDAT);
        }

        // GET: CHITIETPHIEUDATs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cHITIETPHIEUDAT = await _context.CHITIETPHIEUDAT
                .Include(c => c.PhieuDat)
                .Include(c => c.SanPham)
                .FirstOrDefaultAsync(m => m.IdChiTietPhieuDat == id);
            if (cHITIETPHIEUDAT == null)
            {
                return NotFound();
            }

            return View(cHITIETPHIEUDAT);
        }

        // POST: CHITIETPHIEUDATs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cHITIETPHIEUDAT = await _context.CHITIETPHIEUDAT.FindAsync(id);
            _context.CHITIETPHIEUDAT.Remove(cHITIETPHIEUDAT);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CHITIETPHIEUDATExists(int id)
        {
            return _context.CHITIETPHIEUDAT.Any(e => e.IdChiTietPhieuDat == id);
        }
    }
}
