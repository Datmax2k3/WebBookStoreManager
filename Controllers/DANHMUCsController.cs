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
    public class DANHMUCsController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public DANHMUCsController(WebBookStoreManageContext context)
        {
            _context = context;
        }

        // GET: DANHMUCs
        public async Task<IActionResult> Index()
        {
            return View(await _context.DANHMUC.ToListAsync());
        }

        // GET: DANHMUCs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dANHMUC = await _context.DANHMUC
                .FirstOrDefaultAsync(m => m.IdDanhMuc == id);
            if (dANHMUC == null)
            {
                return NotFound();
            }

            return View(dANHMUC);
        }

        // GET: DANHMUCs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DANHMUCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDanhMuc,TenDanhMuc,ThuTu")] DANHMUC dANHMUC)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dANHMUC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dANHMUC);
        }

        // GET: DANHMUCs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dANHMUC = await _context.DANHMUC.FindAsync(id);
            if (dANHMUC == null)
            {
                return NotFound();
            }
            return View(dANHMUC);
        }

        // POST: DANHMUCs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDanhMuc,TenDanhMuc,ThuTu")] DANHMUC dANHMUC)
        {
            if (id != dANHMUC.IdDanhMuc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dANHMUC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DANHMUCExists(dANHMUC.IdDanhMuc))
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
            return View(dANHMUC);
        }

        // GET: DANHMUCs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dANHMUC = await _context.DANHMUC
                .FirstOrDefaultAsync(m => m.IdDanhMuc == id);
            if (dANHMUC == null)
            {
                return NotFound();
            }

            return View(dANHMUC);
        }

        // POST: DANHMUCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dANHMUC = await _context.DANHMUC.FindAsync(id);
            _context.DANHMUC.Remove(dANHMUC);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DANHMUCExists(int id)
        {
            return _context.DANHMUC.Any(e => e.IdDanhMuc == id);
        }
    }
}
