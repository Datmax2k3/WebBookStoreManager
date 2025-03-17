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
    public class DIACHIGIAOHANGsController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public DIACHIGIAOHANGsController(WebBookStoreManageContext context)
        {
            _context = context;
        }

        // GET: DIACHIGIAOHANGs
        public async Task<IActionResult> Index()
        {
            var webBookStoreManageContext = _context.DIACHIGIAOHANG.Include(d => d.NguoiDung);
            return View(await webBookStoreManageContext.ToListAsync());
        }

        // GET: DIACHIGIAOHANGs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dIACHIGIAOHANG = await _context.DIACHIGIAOHANG
                .Include(d => d.NguoiDung)
                .FirstOrDefaultAsync(m => m.IdDiaChi == id);
            if (dIACHIGIAOHANG == null)
            {
                return NotFound();
            }

            return View(dIACHIGIAOHANG);
        }

        // GET: DIACHIGIAOHANGs/Create
        public IActionResult Create()
        {
            ViewData["IdNguoiDung"] = new SelectList(_context.NGUOIDUNG, "IdNguoiDung", "Email");
            return View();
        }

        // POST: DIACHIGIAOHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDiaChi,HoVaTen,DiaChiGiaoHang,SdtGiaoHang,IdNguoiDung")] DIACHIGIAOHANG dIACHIGIAOHANG)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dIACHIGIAOHANG);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNguoiDung"] = new SelectList(_context.NGUOIDUNG, "IdNguoiDung", "Email", dIACHIGIAOHANG.IdNguoiDung);
            return View(dIACHIGIAOHANG);
        }

        // GET: DIACHIGIAOHANGs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dIACHIGIAOHANG = await _context.DIACHIGIAOHANG.FindAsync(id);
            if (dIACHIGIAOHANG == null)
            {
                return NotFound();
            }
            ViewData["IdNguoiDung"] = new SelectList(_context.NGUOIDUNG, "IdNguoiDung", "Email", dIACHIGIAOHANG.IdNguoiDung);
            return View(dIACHIGIAOHANG);
        }

        // POST: DIACHIGIAOHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDiaChi,HoVaTen,DiaChiGiaoHang,SdtGiaoHang,IdNguoiDung")] DIACHIGIAOHANG dIACHIGIAOHANG)
        {
            if (id != dIACHIGIAOHANG.IdDiaChi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dIACHIGIAOHANG);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DIACHIGIAOHANGExists(dIACHIGIAOHANG.IdDiaChi))
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
            ViewData["IdNguoiDung"] = new SelectList(_context.NGUOIDUNG, "IdNguoiDung", "Email", dIACHIGIAOHANG.IdNguoiDung);
            return View(dIACHIGIAOHANG);
        }

        // GET: DIACHIGIAOHANGs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dIACHIGIAOHANG = await _context.DIACHIGIAOHANG
                .Include(d => d.NguoiDung)
                .FirstOrDefaultAsync(m => m.IdDiaChi == id);
            if (dIACHIGIAOHANG == null)
            {
                return NotFound();
            }

            return View(dIACHIGIAOHANG);
        }

        // POST: DIACHIGIAOHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dIACHIGIAOHANG = await _context.DIACHIGIAOHANG.FindAsync(id);
            _context.DIACHIGIAOHANG.Remove(dIACHIGIAOHANG);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DIACHIGIAOHANGExists(int id)
        {
            return _context.DIACHIGIAOHANG.Any(e => e.IdDiaChi == id);
        }
    }
}
