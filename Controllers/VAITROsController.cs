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
    public class VAITROsController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public VAITROsController(WebBookStoreManageContext context)
        {
            _context = context;
        }

        // GET: VAITROs
        public async Task<IActionResult> Index()
        {
            return View(await _context.VAITRO.ToListAsync());
        }

        // GET: VAITROs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vAITRO = await _context.VAITRO
                .FirstOrDefaultAsync(m => m.IdVaiTro == id);
            if (vAITRO == null)
            {
                return NotFound();
            }

            return View(vAITRO);
        }

        // GET: VAITROs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VAITROs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVaiTro,TenVaiTro")] VAITRO vAITRO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vAITRO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vAITRO);
        }

        // GET: VAITROs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vAITRO = await _context.VAITRO.FindAsync(id);
            if (vAITRO == null)
            {
                return NotFound();
            }
            return View(vAITRO);
        }

        // POST: VAITROs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVaiTro,TenVaiTro")] VAITRO vAITRO)
        {
            if (id != vAITRO.IdVaiTro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vAITRO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VAITROExists(vAITRO.IdVaiTro))
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
            return View(vAITRO);
        }

        // GET: VAITROs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vAITRO = await _context.VAITRO
                .FirstOrDefaultAsync(m => m.IdVaiTro == id);
            if (vAITRO == null)
            {
                return NotFound();
            }

            return View(vAITRO);
        }

        // POST: VAITROs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vAITRO = await _context.VAITRO.FindAsync(id);
            _context.VAITRO.Remove(vAITRO);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VAITROExists(int id)
        {
            return _context.VAITRO.Any(e => e.IdVaiTro == id);
        }
    }
}
