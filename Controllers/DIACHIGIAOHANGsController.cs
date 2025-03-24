using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBookStoreManage.Data;
using WebBookStoreManage.Models;

namespace WebBookStoreManage.Controllers
{
    public class DIACHIGIAOHANGsController : Controller
    {
        private readonly WebBookStoreManageContext _context;
        private readonly HttpClient _httpClient;

        public DIACHIGIAOHANGsController(WebBookStoreManageContext context)
        {
            _context = context;
            _httpClient = new HttpClient();
        }

        // GET: DIACHIGIAOHANGs/Index
        public async Task<IActionResult> Index()
        {
            var addresses = _context.DIACHIGIAOHANG.Include(d => d.NguoiDung);
            return View(await addresses.ToListAsync());
        }

        // GET: DIACHIGIAOHANGs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.DIACHIGIAOHANG
                .Include(d => d.NguoiDung)
                .FirstOrDefaultAsync(m => m.IdDiaChi == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: DIACHIGIAOHANGs/Create
        public async Task<IActionResult> Create()
        {
            // Kiểm tra đăng nhập
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Accounts");
            }

            // Lấy IdTàiKhoản từ Claims
            var idTaiKhoanStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(idTaiKhoanStr, out int idTaiKhoan))
            {
                // Không lấy được ID => Yêu cầu đăng nhập
                return RedirectToAction("Login", "Accounts");
            }

            // Tìm NGUOIDUNG theo idTaiKhoan
            var nguoiDung = await _context.NGUOIDUNG
                .FirstOrDefaultAsync(nd => nd.IdTaiKhoan == idTaiKhoan);
            if (nguoiDung == null)
            {
                // Chưa có thông tin người dùng
                return RedirectToAction("Index", "Home");
            }

            // Khởi tạo model, gán IdNguoiDung
            var model = new DIACHIGIAOHANG
            {
                IdNguoiDung = nguoiDung.IdNguoiDung
            };

            // Không xử lý gì thêm. Trả về view để UI tự xây dựng địa chỉ.
            return View(model);
        }

        // POST: DIACHIGIAOHANGs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DIACHIGIAOHANG model)
        {
            // Model bao gồm: HoVaTen, SdtGiaoHang, DiaChiGiaoHang, IdNguoiDung
            // Phía UI đã tự ghép đủ thông tin vào DiaChiGiaoHang, ta chỉ cần lưu.

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Lưu DB
            _context.Add(model);
            await _context.SaveChangesAsync();

            // Sau khi lưu xong, chuyển về trang Checkout (Order)
            return RedirectToAction("Checkout", "Order");
        }

        // GET: DIACHIGIAOHANGs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var address = await _context.DIACHIGIAOHANG.FindAsync(id);
            if (address == null) return NotFound();

            return View(address);
        }

        // POST: DIACHIGIAOHANGs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DIACHIGIAOHANG model)
        {
            if (id != model.IdDiaChi)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
                // Sau khi cập nhật, quay về trang Checkout
                return RedirectToAction("Checkout", "Order");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DIACHIGIAOHANGExists(model.IdDiaChi))
                {
                    return NotFound();
                }
                throw;
            }
        }

        // GET: DIACHIGIAOHANGs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var address = await _context.DIACHIGIAOHANG
                .Include(d => d.NguoiDung)
                .FirstOrDefaultAsync(m => m.IdDiaChi == id);
            if (address == null) return NotFound();

            return View(address);
        }

        // POST: DIACHIGIAOHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _context.DIACHIGIAOHANG.FindAsync(id);
            if (address == null) return NotFound();

            _context.DIACHIGIAOHANG.Remove(address);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DIACHIGIAOHANGExists(int id)
        {
            return _context.DIACHIGIAOHANG.Any(e => e.IdDiaChi == id);
        }
    }
}