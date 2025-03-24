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

        public async Task<IActionResult> Index()
        {
            // Kiểm tra nếu người dùng chưa đăng nhập thì chuyển hướng sang trang đăng nhập
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Accounts");
            }

            // Lấy IdTaiKhoan từ Claim, dùng int.TryParse để tránh lỗi parse
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int idTaiKhoan))
            {
                return RedirectToAction("Login", "Accounts");
            }

            // Tìm NGUOIDUNG dựa trên IdTaiKhoan
            var nguoiDung = await _context.NGUOIDUNG.FirstOrDefaultAsync(n => n.IdTaiKhoan == idTaiKhoan);
            if (nguoiDung == null)
            {
                // Nếu không tìm thấy NGUOIDUNG, chuyển hướng về trang chủ
                return RedirectToAction("Index", "Home");
            }

            int userId = nguoiDung.IdNguoiDung;

            // Lấy danh sách các mục trong giỏ hàng theo người dùng hiện tại
            var cartItems = await _context.GIOHANG
                .Include(g => g.SanPham)
                    .ThenInclude(s => s.SanPhamTacGias)
                        .ThenInclude(st => st.TacGia)
                .Include(g => g.SanPham)
                    .ThenInclude(s => s.DanhMucChiTiet)
                .Where(g => g.IdNguoiDung == userId)
                .ToListAsync();

            // Tính tổng số lượng và tổng chi phí
            int totalQuantity = cartItems.Sum(g => g.SoLuong);
            decimal totalCost = cartItems.Sum(g => (g.SanPham.GiaBan ?? 0) * g.SoLuong);

            // Khởi tạo view model, đảm bảo luôn có dữ liệu (có thể là danh sách rỗng nếu giỏ hàng trống)
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

        [HttpPost]
        public IActionResult UpdateCart([FromBody] UpdateCartRequest request)
        {
            Console.WriteLine($"Cập nhật giỏ hàng cho sản phẩm: {request.ProductId}, số lượng: {request.Quantity}");
            var idTaiKhoan = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var nguoiDung = _context.NGUOIDUNG.FirstOrDefault(n => n.IdTaiKhoan == idTaiKhoan);
            if (nguoiDung == null)
            {
                return Json(new { success = false, message = "Không tìm thấy người dùng." });
            }

            var cartItem = _context.GIOHANG.FirstOrDefault(g => g.IdNguoiDung == nguoiDung.IdNguoiDung && g.IdSanPham == request.ProductId);
            if (cartItem == null)
            {
                return Json(new { success = false, message = "Sản phẩm không tồn tại trong giỏ hàng." });
            }

            cartItem.SoLuong = request.Quantity;
            _context.SaveChanges();

            var cartItems = _context.GIOHANG
                .Include(g => g.SanPham)
                .Where(g => g.IdNguoiDung == nguoiDung.IdNguoiDung)
                .ToList();

            var totalQuantity = cartItems.Sum(g => g.SoLuong);
            var totalCost = cartItems.Sum(g => (g.SanPham.GiaBan ?? 0) * g.SoLuong);

            return Json(new { success = true, totalQuantity = totalQuantity, totalCost = totalCost });
        }

        public class UpdateCartRequest
        {
            public string ProductId { get; set; }
            public int Quantity { get; set; }
        }

        [HttpPost]
        public IActionResult RemoveFromCart([FromBody] RemoveFromCartRequest request)
        {
            var idTaiKhoan = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var nguoiDung = _context.NGUOIDUNG.FirstOrDefault(n => n.IdTaiKhoan == idTaiKhoan);
            if (nguoiDung == null)
            {
                return Json(new { success = false, message = "Không tìm thấy người dùng." });
            }

            var cartItem = _context.GIOHANG.FirstOrDefault(g => g.IdNguoiDung == nguoiDung.IdNguoiDung && g.IdSanPham == request.ProductId);
            if (cartItem == null)
            {
                return Json(new { success = false, message = "Sản phẩm không tồn tại trong giỏ hàng." });
            }

            _context.GIOHANG.Remove(cartItem);
            _context.SaveChanges();

            var cartItems = _context.GIOHANG
                .Include(g => g.SanPham)
                .Where(g => g.IdNguoiDung == nguoiDung.IdNguoiDung)
                .ToList();

            var totalQuantity = cartItems.Sum(g => g.SoLuong);
            var totalCost = cartItems.Sum(g => (g.SanPham.GiaBan ?? 0) * g.SoLuong);

            return Json(new { success = true, totalQuantity = totalQuantity, totalCost = totalCost });
        }

        public class RemoveFromCartRequest
        {
            public string ProductId { get; set; }
        }
    }
}
