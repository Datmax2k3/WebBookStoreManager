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
    public class DANHGIAsController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public DANHGIAsController(WebBookStoreManageContext context)
        {
            _context = context;
        }

        // GET: DANHGIAs
        public async Task<IActionResult> Index()
        {
            var webBookStoreManageContext = _context.DANHGIA.Include(d => d.NguoiDung).Include(d => d.SanPham);
            return View(await webBookStoreManageContext.ToListAsync());
        }

        // GET: DANHGIAs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dANHGIA = await _context.DANHGIA
                .Include(d => d.NguoiDung)
                .Include(d => d.SanPham)
                .FirstOrDefaultAsync(m => m.IdDanhGia == id);
            if (dANHGIA == null)
            {
                return NotFound();
            }

            return View(dANHGIA);
        }

        // GET: DANHGIAs/Create
        public IActionResult Create()
        {
            ViewData["IdNguoiDung"] = new SelectList(_context.NGUOIDUNG, "IdNguoiDung", "Email");
            ViewData["IdSanPham"] = new SelectList(_context.SANPHAM, "IdSanPham", "IdSanPham");
            return View();
        }

        // POST: DANHGIAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDanhGia,NoiDung,IdSanPham,IdNguoiDung")] DANHGIA dANHGIA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dANHGIA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNguoiDung"] = new SelectList(_context.NGUOIDUNG, "IdNguoiDung", "Email", dANHGIA.IdNguoiDung);
            ViewData["IdSanPham"] = new SelectList(_context.SANPHAM, "IdSanPham", "IdSanPham", dANHGIA.IdSanPham);
            return View(dANHGIA);
        }

        // GET: DANHGIAs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dANHGIA = await _context.DANHGIA.FindAsync(id);
            if (dANHGIA == null)
            {
                return NotFound();
            }
            ViewData["IdNguoiDung"] = new SelectList(_context.NGUOIDUNG, "IdNguoiDung", "Email", dANHGIA.IdNguoiDung);
            ViewData["IdSanPham"] = new SelectList(_context.SANPHAM, "IdSanPham", "IdSanPham", dANHGIA.IdSanPham);
            return View(dANHGIA);
        }

        // POST: DANHGIAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDanhGia,NoiDung,IdSanPham,IdNguoiDung")] DANHGIA dANHGIA)
        {
            if (id != dANHGIA.IdDanhGia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dANHGIA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DANHGIAExists(dANHGIA.IdDanhGia))
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
            ViewData["IdNguoiDung"] = new SelectList(_context.NGUOIDUNG, "IdNguoiDung", "Email", dANHGIA.IdNguoiDung);
            ViewData["IdSanPham"] = new SelectList(_context.SANPHAM, "IdSanPham", "IdSanPham", dANHGIA.IdSanPham);
            return View(dANHGIA);
        }

        // GET: DANHGIAs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dANHGIA = await _context.DANHGIA
                .Include(d => d.NguoiDung)
                .Include(d => d.SanPham)
                .FirstOrDefaultAsync(m => m.IdDanhGia == id);
            if (dANHGIA == null)
            {
                return NotFound();
            }

            return View(dANHGIA);
        }

        // POST: DANHGIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dANHGIA = await _context.DANHGIA.FindAsync(id);
            _context.DANHGIA.Remove(dANHGIA);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DANHGIAExists(int id)
        {
            return _context.DANHGIA.Any(e => e.IdDanhGia == id);
        }
    }
}
