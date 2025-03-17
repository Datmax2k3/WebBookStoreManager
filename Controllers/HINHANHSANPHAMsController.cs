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
    public class HINHANHSANPHAMsController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public HINHANHSANPHAMsController(WebBookStoreManageContext context)
        {
            _context = context;
        }

        // GET: HINHANHSANPHAMs
        public async Task<IActionResult> Index()
        {
            var webBookStoreManageContext = _context.HINHANHSANPHAM.Include(h => h.SanPham);
            return View(await webBookStoreManageContext.ToListAsync());
        }

        // GET: HINHANHSANPHAMs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hINHANHSANPHAM = await _context.HINHANHSANPHAM
                .Include(h => h.SanPham)
                .FirstOrDefaultAsync(m => m.IdHinhAnh == id);
            if (hINHANHSANPHAM == null)
            {
                return NotFound();
            }

            return View(hINHANHSANPHAM);
        }

        // GET: HINHANHSANPHAMs/Create
        public IActionResult Create()
        {
            ViewData["IdSanPham"] = new SelectList(_context.SANPHAM, "IdSanPham", "IdSanPham");
            return View();
        }

        // POST: HINHANHSANPHAMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHinhAnh,UrlAnh,IdSanPham")] HINHANHSANPHAM hINHANHSANPHAM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hINHANHSANPHAM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSanPham"] = new SelectList(_context.SANPHAM, "IdSanPham", "IdSanPham", hINHANHSANPHAM.IdSanPham);
            return View(hINHANHSANPHAM);
        }

        // GET: HINHANHSANPHAMs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hINHANHSANPHAM = await _context.HINHANHSANPHAM.FindAsync(id);
            if (hINHANHSANPHAM == null)
            {
                return NotFound();
            }
            ViewData["IdSanPham"] = new SelectList(_context.SANPHAM, "IdSanPham", "IdSanPham", hINHANHSANPHAM.IdSanPham);
            return View(hINHANHSANPHAM);
        }

        // POST: HINHANHSANPHAMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdHinhAnh,UrlAnh,IdSanPham")] HINHANHSANPHAM hINHANHSANPHAM)
        {
            if (id != hINHANHSANPHAM.IdHinhAnh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hINHANHSANPHAM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HINHANHSANPHAMExists(hINHANHSANPHAM.IdHinhAnh))
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
            ViewData["IdSanPham"] = new SelectList(_context.SANPHAM, "IdSanPham", "IdSanPham", hINHANHSANPHAM.IdSanPham);
            return View(hINHANHSANPHAM);
        }

        // GET: HINHANHSANPHAMs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hINHANHSANPHAM = await _context.HINHANHSANPHAM
                .Include(h => h.SanPham)
                .FirstOrDefaultAsync(m => m.IdHinhAnh == id);
            if (hINHANHSANPHAM == null)
            {
                return NotFound();
            }

            return View(hINHANHSANPHAM);
        }

        // POST: HINHANHSANPHAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hINHANHSANPHAM = await _context.HINHANHSANPHAM.FindAsync(id);
            _context.HINHANHSANPHAM.Remove(hINHANHSANPHAM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HINHANHSANPHAMExists(string id)
        {
            return _context.HINHANHSANPHAM.Any(e => e.IdHinhAnh == id);
        }
    }
}
