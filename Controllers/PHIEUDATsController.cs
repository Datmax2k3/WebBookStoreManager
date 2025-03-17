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
    public class PHIEUDATsController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public PHIEUDATsController(WebBookStoreManageContext context)
        {
            _context = context;
        }

        // GET: PHIEUDATs
        public async Task<IActionResult> Index()
        {
            var webBookStoreManageContext = _context.PHIEUDAT.Include(p => p.DiaChiGiaoHang).Include(p => p.NguoiDung);
            return View(await webBookStoreManageContext.ToListAsync());
        }

        // GET: PHIEUDATs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pHIEUDAT = await _context.PHIEUDAT
                .Include(p => p.DiaChiGiaoHang)
                .Include(p => p.NguoiDung)
                .FirstOrDefaultAsync(m => m.IdPhieuDat == id);
            if (pHIEUDAT == null)
            {
                return NotFound();
            }

            return View(pHIEUDAT);
        }

        // GET: PHIEUDATs/Create
        public IActionResult Create()
        {
            ViewData["IdDiaChi"] = new SelectList(_context.DIACHIGIAOHANG, "IdDiaChi", "IdDiaChi");
            ViewData["IdNguoiDung"] = new SelectList(_context.NGUOIDUNG, "IdNguoiDung", "Email");
            return View();
        }

        // POST: PHIEUDATs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPhieuDat,NgayTaoPhieu,GhiChu,IdDiaChi,IdNguoiDung,TongTien")] PHIEUDAT pHIEUDAT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pHIEUDAT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDiaChi"] = new SelectList(_context.DIACHIGIAOHANG, "IdDiaChi", "IdDiaChi", pHIEUDAT.IdDiaChi);
            ViewData["IdNguoiDung"] = new SelectList(_context.NGUOIDUNG, "IdNguoiDung", "Email", pHIEUDAT.IdNguoiDung);
            return View(pHIEUDAT);
        }

        // GET: PHIEUDATs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pHIEUDAT = await _context.PHIEUDAT.FindAsync(id);
            if (pHIEUDAT == null)
            {
                return NotFound();
            }
            ViewData["IdDiaChi"] = new SelectList(_context.DIACHIGIAOHANG, "IdDiaChi", "IdDiaChi", pHIEUDAT.IdDiaChi);
            ViewData["IdNguoiDung"] = new SelectList(_context.NGUOIDUNG, "IdNguoiDung", "Email", pHIEUDAT.IdNguoiDung);
            return View(pHIEUDAT);
        }

        // POST: PHIEUDATs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPhieuDat,NgayTaoPhieu,GhiChu,IdDiaChi,IdNguoiDung,TongTien")] PHIEUDAT pHIEUDAT)
        {
            if (id != pHIEUDAT.IdPhieuDat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pHIEUDAT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PHIEUDATExists(pHIEUDAT.IdPhieuDat))
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
            ViewData["IdDiaChi"] = new SelectList(_context.DIACHIGIAOHANG, "IdDiaChi", "IdDiaChi", pHIEUDAT.IdDiaChi);
            ViewData["IdNguoiDung"] = new SelectList(_context.NGUOIDUNG, "IdNguoiDung", "Email", pHIEUDAT.IdNguoiDung);
            return View(pHIEUDAT);
        }

        // GET: PHIEUDATs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pHIEUDAT = await _context.PHIEUDAT
                .Include(p => p.DiaChiGiaoHang)
                .Include(p => p.NguoiDung)
                .FirstOrDefaultAsync(m => m.IdPhieuDat == id);
            if (pHIEUDAT == null)
            {
                return NotFound();
            }

            return View(pHIEUDAT);
        }

        // POST: PHIEUDATs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pHIEUDAT = await _context.PHIEUDAT.FindAsync(id);
            _context.PHIEUDAT.Remove(pHIEUDAT);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PHIEUDATExists(int id)
        {
            return _context.PHIEUDAT.Any(e => e.IdPhieuDat == id);
        }
    }
}
