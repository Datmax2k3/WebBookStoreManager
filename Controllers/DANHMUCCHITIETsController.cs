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
    public class DANHMUCCHITIETsController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public DANHMUCCHITIETsController(WebBookStoreManageContext context)
        {
            _context = context;
        }

        // GET: DANHMUCCHITIETs
        public async Task<IActionResult> Index()
        {
            var webBookStoreManageContext = _context.DANHMUCCHITIET.Include(d => d.DanhMuc);
            return View(await webBookStoreManageContext.ToListAsync());
        }

        // GET: DANHMUCCHITIETs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dANHMUCCHITIET = await _context.DANHMUCCHITIET
                .Include(d => d.DanhMuc)
                .FirstOrDefaultAsync(m => m.IdDanhMucCT == id);
            if (dANHMUCCHITIET == null)
            {
                return NotFound();
            }

            return View(dANHMUCCHITIET);
        }

        // GET: DANHMUCCHITIETs/Create
        public IActionResult Create()
        {
            ViewData["IdDanhMuc"] = new SelectList(_context.DANHMUC, "IdDanhMuc", "TenDanhMuc");
            return View();
        }

        // POST: DANHMUCCHITIETs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDanhMucCT,TenDanhMucCT,IdDanhMuc")] DANHMUCCHITIET dANHMUCCHITIET)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dANHMUCCHITIET);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDanhMuc"] = new SelectList(_context.DANHMUC, "IdDanhMuc", "TenDanhMuc", dANHMUCCHITIET.IdDanhMuc);
            return View(dANHMUCCHITIET);
        }

        // GET: DANHMUCCHITIETs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dANHMUCCHITIET = await _context.DANHMUCCHITIET.FindAsync(id);
            if (dANHMUCCHITIET == null)
            {
                return NotFound();
            }
            ViewData["IdDanhMuc"] = new SelectList(_context.DANHMUC, "IdDanhMuc", "TenDanhMuc", dANHMUCCHITIET.IdDanhMuc);
            return View(dANHMUCCHITIET);
        }

        // POST: DANHMUCCHITIETs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDanhMucCT,TenDanhMucCT,IdDanhMuc")] DANHMUCCHITIET dANHMUCCHITIET)
        {
            if (id != dANHMUCCHITIET.IdDanhMucCT)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dANHMUCCHITIET);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DANHMUCCHITIETExists(dANHMUCCHITIET.IdDanhMucCT))
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
            ViewData["IdDanhMuc"] = new SelectList(_context.DANHMUC, "IdDanhMuc", "TenDanhMuc", dANHMUCCHITIET.IdDanhMuc);
            return View(dANHMUCCHITIET);
        }

        // GET: DANHMUCCHITIETs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dANHMUCCHITIET = await _context.DANHMUCCHITIET
                .Include(d => d.DanhMuc)
                .FirstOrDefaultAsync(m => m.IdDanhMucCT == id);
            if (dANHMUCCHITIET == null)
            {
                return NotFound();
            }

            return View(dANHMUCCHITIET);
        }

        // POST: DANHMUCCHITIETs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dANHMUCCHITIET = await _context.DANHMUCCHITIET.FindAsync(id);
            _context.DANHMUCCHITIET.Remove(dANHMUCCHITIET);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DANHMUCCHITIETExists(int id)
        {
            return _context.DANHMUCCHITIET.Any(e => e.IdDanhMucCT == id);
        }
    }
}
