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
    public class LOAINHANVIENsController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public LOAINHANVIENsController(WebBookStoreManageContext context)
        {
            _context = context;
        }

        // GET: LOAINHANVIENs
        public async Task<IActionResult> Index()
        {
            return View(await _context.LOAINHANVIEN.ToListAsync());
        }

        // GET: LOAINHANVIENs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lOAINHANVIEN = await _context.LOAINHANVIEN
                .FirstOrDefaultAsync(m => m.IdLoaiNhanVien == id);
            if (lOAINHANVIEN == null)
            {
                return NotFound();
            }

            return View(lOAINHANVIEN);
        }

        // GET: LOAINHANVIENs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LOAINHANVIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLoaiNhanVien,TenLoaiNhanVien")] LOAINHANVIEN lOAINHANVIEN)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lOAINHANVIEN);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lOAINHANVIEN);
        }

        // GET: LOAINHANVIENs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lOAINHANVIEN = await _context.LOAINHANVIEN.FindAsync(id);
            if (lOAINHANVIEN == null)
            {
                return NotFound();
            }
            return View(lOAINHANVIEN);
        }

        // POST: LOAINHANVIENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLoaiNhanVien,TenLoaiNhanVien")] LOAINHANVIEN lOAINHANVIEN)
        {
            if (id != lOAINHANVIEN.IdLoaiNhanVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lOAINHANVIEN);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LOAINHANVIENExists(lOAINHANVIEN.IdLoaiNhanVien))
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
            return View(lOAINHANVIEN);
        }

        // GET: LOAINHANVIENs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lOAINHANVIEN = await _context.LOAINHANVIEN
                .FirstOrDefaultAsync(m => m.IdLoaiNhanVien == id);
            if (lOAINHANVIEN == null)
            {
                return NotFound();
            }

            return View(lOAINHANVIEN);
        }

        // POST: LOAINHANVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lOAINHANVIEN = await _context.LOAINHANVIEN.FindAsync(id);
            _context.LOAINHANVIEN.Remove(lOAINHANVIEN);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LOAINHANVIENExists(int id)
        {
            return _context.LOAINHANVIEN.Any(e => e.IdLoaiNhanVien == id);
        }
    }
}
