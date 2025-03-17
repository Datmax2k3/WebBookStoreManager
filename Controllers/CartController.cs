using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebBookStoreManage.Data;
using WebBookStoreManage.Models;
using WebBookStoreManage.ViewModels;

namespace WebBookStoreManage.Controllers
{
    public class CartController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public CartController(WebBookStoreManageContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Lấy IdTaiKhoan từ claim
            var idTaiKhoan = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            // Tìm NGUOIDUNG dựa trên IdTaiKhoan
            var nguoiDung = _context.NGUOIDUNG.FirstOrDefault(n => n.IdTaiKhoan == idTaiKhoan);
            if (nguoiDung == null)
            {
                // Nếu không tìm thấy NGUOIDUNG, chuyển hướng về trang chủ hoặc xử lý lỗi
                return RedirectToAction("Index", "Home");
            }

            var userId = nguoiDung.IdNguoiDung;

            // Lấy danh sách các mục trong giỏ hàng
            var cartItems = _context.GIOHANG
                .Include(g => g.SanPham)
                    .ThenInclude(s => s.SanPhamTacGias)
                        .ThenInclude(st => st.TacGia)
                .Where(g => g.IdNguoiDung == userId)
                .ToList();

            var totalQuantity = cartItems.Sum(g => g.SoLuong);
            var totalCost = cartItems.Sum(g => (g.SanPham.GiaBan ?? 0) * g.SoLuong);

            var viewModel = new CartViewModel
            {
                CartItems = cartItems,
                TotalQuantity = totalQuantity,
                TotalCost = totalCost
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddToCart([FromBody] AddToCartRequest request)
        {
            // 1. Kiểm tra đăng nhập
            if (!User.Identity.IsAuthenticated)
            {
                // Trả về JSON, client sẽ redirect sang /Accounts/Login
                return Json(new { success = false, redirectTo = "/Accounts/Login" });
            }

            // 2. Lấy idTàiKhoản từ Claims
            var idTaiKhoanStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(idTaiKhoanStr))
            {
                // Lỗi: claims không có. 
                return Json(new { success = false, message = "Không tìm thấy tài khoản." });
            }
            int idTaiKhoan = int.Parse(idTaiKhoanStr);

            // 3. Tìm NGUOIDUNG theo idTaiKhoan
            var nguoiDung = _context.NGUOIDUNG
                .FirstOrDefault(nd => nd.IdTaiKhoan == idTaiKhoan);
            if (nguoiDung == null)
            {
                // Chưa có thông tin người dùng
                return Json(new { success = false, redirectTo = "/Accounts/Profile" });
            }

            // 4. Kiểm tra request.productId
            if (string.IsNullOrEmpty(request.ProductId))
            {
                return Json(new { success = false, message = "Mã sản phẩm không hợp lệ." });
            }

            // 5. Kiểm tra sản phẩm có tồn tại không
            var sanPham = _context.SANPHAM
                .FirstOrDefault(sp => sp.IdSanPham == request.ProductId);
            if (sanPham == null)
            {
                return Json(new { success = false, message = "Sản phẩm không tồn tại." });
            }

            // 6. Thêm/cập nhật giỏ hàng
            var cartItem = _context.GIOHANG
                .FirstOrDefault(g => g.IdNguoiDung == nguoiDung.IdNguoiDung
                                  && g.IdSanPham == request.ProductId);
            if (cartItem == null)
            {
                // Tạo mới
                cartItem = new GIOHANG
                {
                    IdNguoiDung = nguoiDung.IdNguoiDung,
                    IdSanPham = request.ProductId,
                    SoLuong = request.Quantity
                };
                _context.GIOHANG.Add(cartItem);
            }
            else
            {
                // Cộng dồn số lượng
                cartItem.SoLuong += request.Quantity;
            }

            _context.SaveChanges();

            return Json(new { success = true });
        }

        // Dùng class request để map JSON
        public class AddToCartRequest
        {
            public string ProductId { get; set; }
            public int Quantity { get; set; }
        }

    }
}
