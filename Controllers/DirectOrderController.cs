using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.Json;
using WebBookStoreManage.Data;
using WebBookStoreManage.Models;
using WebBookStoreManage.ViewModels;
using System.Security.Claims;
using Microsoft.Extensions.Logging;

namespace WebBookStoreManage.Controllers
{
    public class DirectOrderController : Controller
    {
        private readonly WebBookStoreManageContext _context;
        private readonly ILogger<DirectOrderController> _logger;

        public DirectOrderController(WebBookStoreManageContext context, ILogger<DirectOrderController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: DirectOrder/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                // Lấy danh sách sản phẩm có trong kho và giới hạn số lượng trường được lấy
                var products = await _context.SANPHAM
                    .Where(p => p.SoLuongCon > 0)
                    .OrderBy(p => p.TenSanPham)
                    .Select(p => new
                    {
                        p.IdSanPham,
                        p.TenSanPham,
                        p.GiaBan,
                        p.SoLuongCon
                    })
                    .ToListAsync();

                // Chuyển đổi danh sách sản phẩm sang đối tượng đầy đủ
                var productsList = products.Select(p => new SANPHAM
                {
                    IdSanPham = p.IdSanPham,
                    TenSanPham = p.TenSanPham,
                    GiaBan = p.GiaBan,
                    SoLuongCon = p.SoLuongCon
                }).ToList();

                // Lấy ID nhân viên đang đăng nhập
                var currentStaffId = GetCurrentStaffId();

                // Truyền dữ liệu qua ViewBag
                ViewBag.Products = productsList;
                ViewBag.CurrentStaffId = currentStaffId;

                var model = new DirectOrderViewModel
                {
                    StaffId = currentStaffId,
                    OrderDate = DateTime.Now
                };

                // Thêm một sản phẩm mặc định
                model.OrderItems.Add(new OrderItemViewModel());

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi tải trang tạo đơn hàng: {ex.Message}");
                return View("Error");
            }
        }

        // Lớp đại diện cho mỗi item trong JSON
        private class OrderItemJson
        {
            public int index { get; set; }
            public string productId { get; set; }
            public int quantity { get; set; }
            public decimal price { get; set; }
            public decimal amount { get; set; }
        }

        // POST: DirectOrder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDirectOrder()
        {
            try
            {
                _logger.LogInformation("Bắt đầu xử lý tạo đơn hàng trực tiếp");

                // Lấy dữ liệu từ form trực tiếp
                var orderDate = DateTime.Parse(Request.Form["OrderDate"].ToString());
                var note = Request.Form["Note"].ToString();

                // Đảm bảo staffId là số nguyên hợp lệ
                if (!int.TryParse(Request.Form["StaffId"].ToString(), out int staffId))
                {
                    staffId = GetCurrentStaffId(); // Sử dụng giá trị mặc định nếu không thể parse
                }

                // Lấy JSON của OrderItems
                var orderItemsJson = Request.Form["OrderItemsJson"].ToString();

                // Xử lý totalAmount 
                var totalAmountStr = Request.Form["TotalAmount"].ToString().Trim();

                // Xử lý định dạng số
                decimal totalAmount;
                if (!decimal.TryParse(totalAmountStr, NumberStyles.Any, CultureInfo.InvariantCulture, out totalAmount))
                {
                    // Loại bỏ các ký tự không phải số và dấu thập phân
                    totalAmountStr = new string(totalAmountStr.Where(c => char.IsDigit(c) || c == '.' || c == ',').ToArray());
                    totalAmountStr = totalAmountStr.Replace(',', '.');

                    if (!decimal.TryParse(totalAmountStr, NumberStyles.Any, CultureInfo.InvariantCulture, out totalAmount))
                    {
                        ModelState.AddModelError("", "Tổng tiền không hợp lệ");
                        return await RedirectToCreateWithError();
                    }
                }

                // Phân tích JSON thành danh sách OrderItems
                List<OrderItemJson> orderItemsFromJson;
                try
                {
                    orderItemsFromJson = JsonSerializer.Deserialize<List<OrderItemJson>>(orderItemsJson);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Lỗi khi phân tích JSON: {ex.Message}");
                    ModelState.AddModelError("", "Lỗi khi phân tích dữ liệu sản phẩm");
                    return await RedirectToCreateWithError();
                }

                // Chuyển đổi từ OrderItemJson sang OrderItemViewModel
                var orderItems = new List<OrderItemViewModel>();
                if (orderItemsFromJson != null)
                {
                    foreach (var jsonItem in orderItemsFromJson)
                    {
                        // Kiểm tra xem sản phẩm có được chọn không
                        if (string.IsNullOrEmpty(jsonItem.productId))
                        {
                            continue;
                        }

                        // Thêm vào danh sách
                        orderItems.Add(new OrderItemViewModel
                        {
                            ProductId = jsonItem.productId,
                            Quantity = jsonItem.quantity,
                            Amount = jsonItem.amount
                        });
                    }
                }

                // Kiểm tra và xử lý đơn hàng
                if (orderItems.Count == 0)
                {
                    ModelState.AddModelError("", "Đơn hàng phải có ít nhất một sản phẩm");
                    return await RedirectToCreateWithError();
                }

                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    // Lấy tất cả sản phẩm cần thiết trong một lần truy vấn để tăng hiệu suất
                    var productIds = orderItems.Select(i => i.ProductId).ToList();
                    var products = await _context.SANPHAM
                        .Where(p => productIds.Contains(p.IdSanPham))
                        .ToDictionaryAsync(p => p.IdSanPham, p => p);

                    // Kiểm tra sản phẩm và số lượng
                    foreach (var item in orderItems)
                    {
                        if (!products.TryGetValue(item.ProductId, out var product))
                        {
                            ModelState.AddModelError("", $"Sản phẩm không tồn tại: {item.ProductId}");
                            return await RedirectToCreateWithError();
                        }

                        if (product.SoLuongCon < item.Quantity)
                        {
                            ModelState.AddModelError("", $"Sản phẩm '{product.TenSanPham}' chỉ còn {product.SoLuongCon} trong kho");
                            return await RedirectToCreateWithError();
                        }
                    }

                    // Tạo phiếu đặt mới
                    var phieuDat = new PHIEUDAT
                    {
                        NgayTaoPhieu = orderDate,
                        GhiChu = note,
                        TongTien = totalAmount,
                    };

                    _context.PHIEUDAT.Add(phieuDat);
                    await _context.SaveChangesAsync();

                    // Tạo chi tiết phiếu đặt
                    var chiTietPhieuDats = new List<CHITIETPHIEUDAT>();
                    foreach (var item in orderItems)
                    {
                        var product = products[item.ProductId];

                        var chiTietPhieuDat = new CHITIETPHIEUDAT
                        {
                            IdPhieuDat = phieuDat.IdPhieuDat,
                            IdSanPham = item.ProductId,
                            SoLuong = item.Quantity,
                            ThanhTien = item.Amount
                        };

                        chiTietPhieuDats.Add(chiTietPhieuDat);

                        // Cập nhật số lượng sản phẩm
                        product.SoLuongCon -= item.Quantity;
                        product.SoLuongDaBan += item.Quantity;
                        _context.SANPHAM.Update(product);
                    }

                    _context.CHITIETPHIEUDAT.AddRange(chiTietPhieuDats);
                    await _context.SaveChangesAsync();

                    // Tạo đơn hàng
                    var donHang = new DONHANG
                    {
                        IdPhieuDat = phieuDat.IdPhieuDat,
                        TrangThaiDonHang = TrangThaiDonHang.hoanThanh, // Đơn hàng trực tiếp nên mặc định đã duyệt
                        IdNhanVien = staffId,
                        NgayThanhToan = DateTime.Now // Đơn hàng trực tiếp nên mặc định đã thanh toán
                    };

                    _context.DONHANG.Add(donHang);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    // Chuyển hướng đến trang xác nhận hoặc trang chi tiết đơn hàng
                    return RedirectToAction("EmployeeOrderDetails", "Order", new { id = donHang.IdDonHang + 1});
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError($"Lỗi tạo đơn hàng: {ex.Message}");
                    ModelState.AddModelError("", $"Lỗi: {ex.Message}");
                    return await RedirectToCreateWithError();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi xử lý form: {ex.Message}");
                ModelState.AddModelError("", $"Lỗi xử lý form: {ex.Message}");
                return await RedirectToCreateWithError();
            }
        }

        private async Task<IActionResult> RedirectToCreateWithError()
        {
            // Lấy danh sách sản phẩm có trong kho
            var products = await _context.SANPHAM
                .Where(p => p.SoLuongCon > 0)
                .OrderBy(p => p.TenSanPham)
                .Select(p => new SANPHAM
                {
                    IdSanPham = p.IdSanPham,
                    TenSanPham = p.TenSanPham,
                    GiaBan = p.GiaBan,
                    SoLuongCon = p.SoLuongCon
                })
                .ToListAsync();

            int currentStaffId = GetCurrentStaffId();
            ViewBag.CurrentStaffId = currentStaffId;
            ViewBag.Products = products;

            // Tạo model mới
            var model = new DirectOrderViewModel
            {
                StaffId = currentStaffId,
                OrderDate = DateTime.Now
            };
            model.OrderItems.Add(new OrderItemViewModel());

            return View("Create", model);
        }

        private int GetCurrentStaffId()
        {
            // Lấy thông tin người dùng đang đăng nhập
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                // Tìm nhân viên dựa trên IdTaiKhoan - sử dụng truy vấn tối ưu
                var staff = _context.NHANVIEN
                    .Where(nv => nv.IdTaiKhoan == userId)
                    .Select(nv => new { nv.IdNhanVien })
                    .FirstOrDefault();

                if (staff != null)
                {
                    return staff.IdNhanVien;
                }
            }

            // Nếu không tìm thấy, trả về giá trị mặc định
            return 1;
        }
    }
}