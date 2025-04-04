using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
    public class OrderController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public OrderController(WebBookStoreManageContext context)
        {
            _context = context;
        }

        // Hiển thị địa chỉ giao hàng của user
        public async Task<IActionResult> Checkout()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Accounts");
            }

            var idTaiKhoanStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(idTaiKhoanStr))
            {
                return RedirectToAction("Login", "Accounts");
            }

            int idTaiKhoan = int.Parse(idTaiKhoanStr);

            // Tìm người dùng
            var nguoiDung = await _context.NGUOIDUNG
                .FirstOrDefaultAsync(nd => nd.IdTaiKhoan == idTaiKhoan);
            if (nguoiDung == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // Lấy danh sách địa chỉ
            var diaChiList = await _context.DIACHIGIAOHANG
                .Where(d => d.IdNguoiDung == nguoiDung.IdNguoiDung)
                .ToListAsync();

            return View(diaChiList);
        }

        [HttpPost]
        public async Task<IActionResult> ChooseAddress(int idDiaChi)
        {
            // Lưu idDiaChi vào TempData để sử dụng trong Payment
            TempData["idDiaChi"] = idDiaChi;

            return RedirectToAction("Payment");
        }

        public async Task<IActionResult> Payment()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Accounts");
            }

            // Lấy idTaiKhoan từ Claims
            var idTaiKhoanStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(idTaiKhoanStr))
            {
                return RedirectToAction("Login", "Accounts");
            }
            int idTaiKhoan = int.Parse(idTaiKhoanStr);

            // Tìm người dùng
            var nguoiDung = await _context.NGUOIDUNG
                .FirstOrDefaultAsync(nd => nd.IdTaiKhoan == idTaiKhoan);
            if (nguoiDung == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // Lấy idDiaChi từ TempData
            if (!TempData.ContainsKey("idDiaChi"))
            {
                return RedirectToAction("Checkout");
            }
            int idDiaChi = (int)TempData["idDiaChi"];

            // Lấy địa chỉ giao hàng
            var diaChi = await _context.DIACHIGIAOHANG
                .FirstOrDefaultAsync(d => d.IdDiaChi == idDiaChi && d.IdNguoiDung == nguoiDung.IdNguoiDung);
            if (diaChi == null)
            {
                return RedirectToAction("Checkout");
            }

            // Lấy giỏ hàng
            var cartItems = await _context.GIOHANG
                .Include(g => g.SanPham)
                .Where(g => g.IdNguoiDung == nguoiDung.IdNguoiDung)
                .ToListAsync();

            // Tính tổng tiền
            decimal subtotal = (decimal)cartItems.Sum(item => item.SoLuong * item.SanPham.GiaBan);
            decimal total = subtotal; // Có thể thêm phí vận chuyển sau

            var model = new PaymentViewModel
            {
                DeliveryAddress = diaChi,
                Shoppers = nguoiDung,
                CartItems = cartItems,
                Subtotal = subtotal,
                Total = total,
                Note = string.Empty,
                DiscountCode = string.Empty
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(PaymentViewModel model)
        {
            // Kiểm tra ModelState
            if (!ModelState.IsValid)
            {
                return View("Payment", model);
            }

            // Lấy thông tin người dùng từ Claims
            var idTaiKhoanStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(idTaiKhoanStr))
            {
                return RedirectToAction("Login", "Accounts");
            }
            int idTaiKhoan = int.Parse(idTaiKhoanStr);
            var nguoiDung = await _context.NGUOIDUNG.FirstOrDefaultAsync(n => n.IdTaiKhoan == idTaiKhoan);
            if (nguoiDung == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // Tải lại giỏ hàng từ CSDL (vì thông tin giỏ hàng không được post qua form)
            var cartItems = await _context.GIOHANG
                .Include(g => g.SanPham)
                .Where(g => g.IdNguoiDung == nguoiDung.IdNguoiDung)
                .ToListAsync();

            // Tính lại Subtotal từ giỏ hàng
            decimal subtotal = cartItems.Sum(item => item.SoLuong * (item.SanPham.GiaBan ?? 0));
            model.Subtotal = subtotal;

            // Xác định phí vận chuyển dựa trên phương thức được chọn
            decimal shippingFee = (model.ShippingMethod == "standard") ? 25000 : 50000;
            model.ShippingFee = shippingFee;
            model.Total = model.Subtotal + shippingFee;

            // Nếu DeliveryAddress chưa có, tải lại dựa trên Id được gửi từ form (sử dụng input hidden)
            if (model.DeliveryAddress == null || model.DeliveryAddress.IdDiaChi == 0)
            {
                if (int.TryParse(Request.Form["DeliveryAddress.IdDiaChi"], out int idDiaChi))
                {
                    model.DeliveryAddress = await _context.DIACHIGIAOHANG.FirstOrDefaultAsync(d => d.IdDiaChi == idDiaChi);
                }
            }

            // Nếu Shoppers chưa có, gán lại bằng thông tin người dùng
            if (model.Shoppers == null)
            {
                model.Shoppers = nguoiDung;
            }

            // Tạo PHIEUDAT (đơn hàng)
            var order = new PHIEUDAT
            {
                NgayTaoPhieu = DateTime.Now,
                GhiChu = model.Note,
                IdDiaChi = model.DeliveryAddress.IdDiaChi,
                IdNguoiDung = model.Shoppers.IdNguoiDung,
                TongTien = model.Total,
            };

            _context.PHIEUDAT.Add(order);
            await _context.SaveChangesAsync();

            // Tạo chi tiết đơn hàng cho từng mặt hàng trong giỏ hàng

            foreach (var item in cartItems)
            {
                var orderDetail = new CHITIETPHIEUDAT
                {
                    SoLuong = item.SoLuong,
                    IdPhieuDat = order.IdPhieuDat,
                    IdSanPham = item.SanPham.IdSanPham,
                    ThanhTien = item.SoLuong * (item.SanPham.GiaBan ?? 0)
                };
                _context.CHITIETPHIEUDAT.Add(orderDetail);

                // Cập nhật số lượng tồn và số lượng đã bán của sản phẩm
                var product = await _context.SANPHAM.FirstOrDefaultAsync(p => p.IdSanPham == item.SanPham.IdSanPham);
                if (product != null)
                {
                    product.SoLuongCon -= item.SoLuong;
                    product.SoLuongDaBan += item.SoLuong;
                }
            }
            await _context.SaveChangesAsync();

            // Tạo DONHANG
            var donHang = new DONHANG
            {
                TrangThaiDonHang = TrangThaiDonHang.dangXuLy,
                IdPhieuDat = order.IdPhieuDat,
            };
            _context.DONHANG.Add(donHang);
            await _context.SaveChangesAsync();

            // Xóa các mục trong giỏ hàng của người dùng sau khi đặt hàng thành công
            _context.GIOHANG.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            return RedirectToAction("OrderManagement");
        }

        public async Task<IActionResult> OrderManagement()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Accounts");
            }

            var idTaiKhoanStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(idTaiKhoanStr, out int idTaiKhoan))
            {
                return RedirectToAction("Login", "Accounts");
            }

            var nguoiDung = await _context.NGUOIDUNG
                .FirstOrDefaultAsync(n => n.IdTaiKhoan == idTaiKhoan);
            if (nguoiDung == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // Lấy các đơn hàng của người dùng, sắp xếp giảm dần theo ngày tạo
            var orders = await _context.PHIEUDAT
                .Include(o => o.DiaChiGiaoHang)
                .Include(o => o.NguoiDung)
                .Include(o => o.DonHangs)
                .Where(o => o.IdNguoiDung == nguoiDung.IdNguoiDung)
                .OrderByDescending(o => o.NgayTaoPhieu)
                .ToListAsync();

            // Map PHIEUDAT sang OrderViewModel
            var orderViewModels = orders.Select(o => new OrderViewModel
            {
                PHIEUDAT = o,
                DONHANG = o.DonHangs != null && o.DonHangs.Any() ? o.DonHangs.First() : null
            }).ToList();

            return View(orderViewModels);
        }

        // Thêm vào lớp OrderController hoặc Controller điều khiển layout
        private async Task<int> GetProcessingOrderCount()
        {
            return await _context.DONHANG
                .Where(dh => dh.TrangThaiDonHang == TrangThaiDonHang.dangXuLy)
                .CountAsync();
        }

        // Sửa đổi action hoặc filter chạy trước khi render layout
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            bool isEmployee = ViewBag.IsEmployee != null && (bool)ViewBag.IsEmployee;
            bool isAdmin = ViewBag.IsAdmin != null && (bool)ViewBag.IsAdmin;
            if (!isEmployee && !isAdmin)
            {
                ViewBag.ProcessingOrderCount = await GetProcessingOrderCount();
            }
            await base.OnActionExecutionAsync(context, next);
        }

        public async Task<IActionResult> EmployeeOrderManagement(
    DateTime? startDate,
    DateTime? endDate,
    string status,
    string search,
    int page = 1,
    int pageSize = 10)
        {
            // Kiểm tra quyền nhân viên
            bool isEmployee = ViewBag.IsEmployee != null && (bool)ViewBag.IsEmployee;
            bool isAdmin = ViewBag.IsAdmin != null && (bool)ViewBag.IsAdmin;
            if (!isEmployee && !isAdmin)
            {
                return RedirectToAction("AccessDenied", "Accounts");
            }

            // Xây dựng query cơ bản
            var query = _context.PHIEUDAT
                .Include(o => o.DiaChiGiaoHang)
                .Include(o => o.NguoiDung)
                .Include(o => o.DonHangs)
                .AsQueryable();

            // Lọc theo ngày
            if (startDate.HasValue)
            {
                query = query.Where(o => o.NgayTaoPhieu >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                query = query.Where(o => o.NgayTaoPhieu <= endDate.Value);
            }

            // Lọc theo trạng thái
            if (!string.IsNullOrEmpty(status))
            {
                if (Enum.TryParse<TrangThaiDonHang>(status, out var parsedStatus))
                {
                    query = query.Where(o => o.DonHangs.Any(d => d.TrangThaiDonHang == parsedStatus));
                }
            }


            // Lọc theo tìm kiếm
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(o =>
                    o.IdPhieuDat.ToString().Contains(search) ||
                    (o.NguoiDung != null && o.NguoiDung.TenNguoiDung.Contains(search)) ||
                    (o.NguoiDung != null && o.NguoiDung.soDienThoai.Contains(search))
                );
            }

            // Sắp xếp giảm dần theo ngày tạo
            query = query.OrderByDescending(o => o.NgayTaoPhieu);

            // Phân trang
            var pagedOrders = await PaginatedList<PHIEUDAT>.CreateAsync(query, page, pageSize);

            // Map PHIEUDAT sang OrderViewModel
            var orderViewModels = pagedOrders.Select(o => new OrderViewModel
            {
                PHIEUDAT = o,
                DONHANG = o.DonHangs != null && o.DonHangs.Any() ? o.DonHangs.First() : null
            }).ToList();

            // Truyền thông tin phân trang và bộ lọc vào ViewBag
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = pagedOrders.TotalPages;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalItems = pagedOrders.TotalCount;
            ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");
            ViewBag.Status = status;
            ViewBag.Search = search;

            return View(orderViewModels);
        }

        // Lấy thông tin khách hàng qua Ajax
        [HttpGet]
        public async Task<IActionResult> GetCustomerInfo(int id)
        {
            var customer = await _context.NGUOIDUNG.FirstOrDefaultAsync(n => n.IdNguoiDung == id);
            if (customer == null)
            {
                return Json(null);
            }

            return Json(new
            {
                idNguoiDung = customer.IdNguoiDung,
                tenNguoiDung = customer.TenNguoiDung,
                email = customer.Email,
                soDienThoai = customer.soDienThoai
            });
        }

        // Action hiển thị chi tiết đơn hàng cho nhân viên
        [HttpGet]
        public async Task<IActionResult> EmployeeOrderDetails(int? id)
        {
            bool isEmployee = ViewBag.IsEmployee != null && (bool)ViewBag.IsEmployee;
            bool isAdmin = ViewBag.IsAdmin != null && (bool)ViewBag.IsAdmin;
            if (!isEmployee && !isAdmin)
            {
                return RedirectToAction("AccessDenied", "Accounts");
            }

            if (id == null)
                return NotFound();

            var order = await _context.PHIEUDAT
                .Include(o => o.DiaChiGiaoHang)
                .Include(o => o.NguoiDung)
                .Include(o => o.ChiTietPhieuDats)
                    .ThenInclude(ct => ct.SanPham)
                .Include(o => o.DonHangs) // Load danh sách đơn hàng
                .FirstOrDefaultAsync(o => o.IdPhieuDat == id);

            if (order == null)
                return NotFound();

            // Chuyển dữ liệu từ PHIEUDAT sang OrderViewModel
            var orderViewModel = new OrderViewModel
            {
                PHIEUDAT = order,
                DONHANG = order.DonHangs?.FirstOrDefault() // Lấy đơn hàng đầu tiên nếu có
            };

            return View(orderViewModel);
        }

        // Action hiển thị chi tiết đơn hàng của người dùng
        public async Task<IActionResult> OrderDetails(int? id)
        {
            if (id == null)
                return NotFound();

            var order = await _context.PHIEUDAT
                .Include(o => o.DiaChiGiaoHang)
                .Include(o => o.NguoiDung)
                .Include(o => o.ChiTietPhieuDats)
                    .ThenInclude(ct => ct.SanPham)
                .Include(o => o.DonHangs) // Load danh sách đơn hàng
                .FirstOrDefaultAsync(o => o.IdPhieuDat == id);

            if (order == null)
                return NotFound();

            // Chuyển dữ liệu từ PHIEUDAT sang OrderViewModel
            var orderViewModel = new OrderViewModel
            {
                PHIEUDAT = order,
                DONHANG = order.DonHangs?.FirstOrDefault() // Lấy đơn hàng đầu tiên nếu có
            };

            return View(orderViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateOrderStatus(int idDonHang, TrangThaiDonHang trangThai)
        {
            // Kiểm tra quyền của người dùng (nhân viên hoặc admin)
            // Trong thực tế, cần thêm code kiểm tra quyền vào đây

            var donHang = await _context.DONHANG
                .Include(dh => dh.PhieuDat)
                .FirstOrDefaultAsync(dh => dh.IdDonHang == idDonHang);

            if (donHang == null)
            {
                return NotFound();
            }

            // Cập nhật trạng thái đơn hàng
            donHang.TrangThaiDonHang = trangThai;

            // Cập nhật thông tin khác tùy theo trạng thái
            if (trangThai == TrangThaiDonHang.hoanThanh)
            {
                donHang.NgayThanhToan = DateTime.Now;
                donHang.NgayGiaoHang = DateTime.Now;
            }
            else if (trangThai == TrangThaiDonHang.dangVanChuyen)
            {
                donHang.NgayGiaoHang = DateTime.Now;
            }

            await _context.SaveChangesAsync();
            TempData["Message"] = "Đã cập nhật trạng thái đơn hàng thành công!";

            return RedirectToAction("OrderDetails", new { id = donHang.PhieuDat.IdPhieuDat });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelOrder(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Accounts");
            }

            var idTaiKhoanStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(idTaiKhoanStr, out int idTaiKhoan))
            {
                return RedirectToAction("Login", "Accounts");
            }

            var nguoiDung = await _context.NGUOIDUNG
                .FirstOrDefaultAsync(n => n.IdTaiKhoan == idTaiKhoan);

            if (nguoiDung == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // Lấy đơn hàng dựa trên Id
            var donHang = await _context.DONHANG
                .Include(dh => dh.PhieuDat)
                    .ThenInclude(p => p.ChiTietPhieuDats)
                        .ThenInclude(ct => ct.SanPham)
                .FirstOrDefaultAsync(dh => dh.PhieuDat.IdPhieuDat == id && dh.PhieuDat.IdNguoiDung == nguoiDung.IdNguoiDung);

            if (donHang == null)
            {
                return NotFound();
            }

            // Kiểm tra nếu trạng thái đang là `dangXuLy` thì mới cho phép hủy
            if (donHang.TrangThaiDonHang == TrangThaiDonHang.dangXuLy)
            {
                // Cập nhật trạng thái thành hủy đơn
                donHang.TrangThaiDonHang = TrangThaiDonHang.daHuy;

                // Cập nhật lại số lượng tồn và số lượng đã bán cho từng sản phẩm trong chi tiết đơn hàng
                if (donHang.PhieuDat?.ChiTietPhieuDats != null)
                {
                    foreach (var detail in donHang.PhieuDat.ChiTietPhieuDats)
                    {
                        var product = detail.SanPham;
                        if (product != null)
                        {
                            // Hoàn trả số lượng sản phẩm
                            product.SoLuongCon += detail.SoLuong;
                            product.SoLuongDaBan -= detail.SoLuong;

                            // Đảm bảo không có giá trị âm
                            product.SoLuongCon = Math.Max(0, product.SoLuongCon);
                            product.SoLuongDaBan = Math.Max(0, product.SoLuongDaBan);
                        }
                    }
                }

                await _context.SaveChangesAsync();
                TempData["Message"] = "Đơn hàng đã được hủy thành công!";
            }
            else
            {
                TempData["Error"] = "Bạn không thể hủy đơn hàng này!";
            }

            return RedirectToAction("OrderDetails", new { id });
        }

        // In đơn hàng
        [HttpGet]
        public async Task<IActionResult> PrintOrder(int id)
        {
            bool isEmployee = ViewBag.IsEmployee != null && (bool)ViewBag.IsEmployee;
            bool isAdmin = ViewBag.IsAdmin != null && (bool)ViewBag.IsAdmin;
            // Kiểm tra quyền nhân viên (hoặc khách hàng có quyền truy cập đơn hàng này)
            if (!isEmployee && !isAdmin)
            {
                // Kiểm tra xem đơn hàng có phải của khách hàng đang đăng nhập không
                var idTaiKhoanStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!int.TryParse(idTaiKhoanStr, out int idTaiKhoan))
                {
                    return RedirectToAction("Login", "Accounts");
                }

                var nguoiDung = await _context.NGUOIDUNG
                    .FirstOrDefaultAsync(n => n.IdTaiKhoan == idTaiKhoan);

                if (nguoiDung == null)
                {
                    return RedirectToAction("AccessDenied", "Accounts");
                }

                var phieuDat = await _context.PHIEUDAT
                    .FirstOrDefaultAsync(p => p.IdPhieuDat == id && p.IdNguoiDung == nguoiDung.IdNguoiDung);

                if (phieuDat == null)
                {
                    return RedirectToAction("AccessDenied", "Accounts");
                }
            }

            // Lấy thông tin đơn hàng
            var order = await _context.PHIEUDAT
                .Include(o => o.DiaChiGiaoHang)
                .Include(o => o.NguoiDung)
                .Include(o => o.ChiTietPhieuDats)
                    .ThenInclude(ct => ct.SanPham)
                .Include(o => o.DonHangs)
                .FirstOrDefaultAsync(o => o.IdPhieuDat == id);

            if (order == null)
            {
                return NotFound();
            }

            // Chuyển dữ liệu từ PHIEUDAT sang OrderViewModel
            var orderViewModel = new OrderViewModel
            {
                PHIEUDAT = order,
                DONHANG = order.DonHangs?.FirstOrDefault()
            };

            return View(orderViewModel);
        }

        
    }
}
