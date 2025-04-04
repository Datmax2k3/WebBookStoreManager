using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebBookStoreManage.Data;
using WebBookStoreManage.Models;
using WebBookStoreManage.ViewModels;
using X.PagedList;

namespace WebBookStoreManage.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public HomeController(WebBookStoreManageContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            // Kiểm tra xem người dùng có phải nhân viên không
            bool isEmployee = false;
            if (User.Identity.IsAuthenticated)
            {
                var account = await _context.TAIKHOAN
                    .Include(a => a.NhanVien)
                    .FirstOrDefaultAsync(a => a.TenDangNhap == User.Identity.Name);

                isEmployee = account?.NhanVien != null;
            }
            ViewBag.IsEmployee = isEmployee;

            // Lấy 50 sản phẩm đầu tiên cho cả hai mục đích
            var top50Products = await _context.SANPHAM
                .Include(p => p.SanPhamTacGias)
                    .ThenInclude(st => st.TacGia)
                .Take(50)
                .ToListAsync();

            // Xử lý ở phía client để lấy sản phẩm xem nhiều nhất và bán chạy nhất
            var topViewedProducts = top50Products
                .OrderByDescending(p => p.SoLuotXem)
                .Take(4)
                .ToList();

            var popularBooks = top50Products
                .OrderByDescending(p => p.SoLuongDaBan)
                .Skip(1) // Bỏ qua sản phẩm bán chạy nhất (đã dùng cho Best Selling)
                .Take(8)
                .ToList();

            var bestSellingProduct = top50Products
                .OrderByDescending(p => p.SoLuongDaBan)
                .FirstOrDefault();

            ViewBag.TopViewedProducts = topViewedProducts;
            ViewBag.BestSellingProduct = bestSellingProduct;
            ViewBag.PopularBooks = popularBooks;

            CartViewModel cartModel = new CartViewModel
            {
                CartItems = new List<GIOHANG>(),
                TotalCost = 0,
                TotalQuantity = 0
            };

            if (User.Identity.IsAuthenticated && int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int idTaiKhoan))
            {
                var nguoiDung = await _context.NGUOIDUNG.FirstOrDefaultAsync(n => n.IdTaiKhoan == idTaiKhoan);
                if (nguoiDung != null)
                {
                    int userId = nguoiDung.IdNguoiDung;
                    var cartItems = await _context.GIOHANG
                        .Include(g => g.SanPham)
                        .Where(g => g.IdNguoiDung == userId)
                        .ToListAsync();

                    cartModel.TotalQuantity = cartItems.Sum(g => g.SoLuong);
                    cartModel.TotalCost = cartItems.Sum(g => (g.SanPham.GiaBan ?? 0) * g.SoLuong);
                    cartModel.CartItems = cartItems;
                }
            }
            ViewBag.CartSummary = cartModel;
            return View(cartModel);
        }

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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Product(int? categoryId, string danhmuc, string danhmucchitiet, string sort, int? page)
        {
            int currentPage = page ?? 1;
            int pageSize = 20;
            var danhMucs = await _context.DANHMUC.Include(dm => dm.DanhMucChiTiets).ToListAsync();

            if (!string.IsNullOrEmpty(danhmuc))
            {
                // Không tự động gán categoryId bằng giá trị đầu tiên
            }
            else if (categoryId == null && danhMucs.Any())
            {
                categoryId = danhMucs.First().IdDanhMuc;
            }

            var viewModel = new ProductViewModel
            {
                DanhMucs = danhMucs,
                SelectedCategoryId = categoryId ?? 0,
                SelectedDanhMuc = danhmuc,
                SelectedDanhMucChiTiet = danhmucchitiet
            };

            // Bắt đầu với truy vấn SANPHAM
            var productsQuery = _context.SANPHAM.AsQueryable();

            // Lọc theo danh mục (danhmuc)
            if (!string.IsNullOrEmpty(danhmuc))
            {
                var selectedDanhMucIds = danhmuc.Split(',').Select(int.Parse).ToList();
                productsQuery = productsQuery.Where(sp => selectedDanhMucIds.Contains(sp.DanhMucChiTiet.DanhMuc.IdDanhMuc));
            }
            else if (categoryId.HasValue)
            {
                productsQuery = productsQuery.Where(sp => sp.DanhMucChiTiet != null && sp.DanhMucChiTiet.IdDanhMuc == categoryId.Value);
            }

            // Lọc theo danh mục chi tiết (danhmucchitiet)
            if (!string.IsNullOrEmpty(danhmucchitiet))
            {
                var selectedDanhMucCTIds = danhmucchitiet.Split(',').Select(int.Parse).ToList();
                productsQuery = productsQuery.Where(sp => selectedDanhMucCTIds.Contains(sp.DanhMucChiTiet.IdDanhMucCT));
            }

            // Chiếu sang ProductDto sau khi lọc
            var projectedQuery = productsQuery.Select(sp => new ProductDto
            {
                IdSanPham = sp.IdSanPham,
                TenSanPham = sp.TenSanPham,
                GiaGoc = sp.GiaGoc,
                hinhAnh = sp.hinhAnh,
                TenDanhMucCT = sp.DanhMucChiTiet.TenDanhMucCT
            });

            // Sắp xếp
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "az":
                        projectedQuery = projectedQuery.OrderBy(p => p.TenSanPham);
                        break;
                    case "za":
                        projectedQuery = projectedQuery.OrderByDescending(p => p.TenSanPham);
                        break;
                    case "price-asc":
                        projectedQuery = projectedQuery.OrderBy(p => p.GiaGoc);
                        break;
                    case "price-desc":
                        projectedQuery = projectedQuery.OrderByDescending(p => p.GiaGoc);
                        break;
                    default:
                        projectedQuery = projectedQuery.OrderBy(p => p.TenSanPham);
                        break;
                }
            }
            else
            {
                projectedQuery = projectedQuery.OrderBy(p => p.TenSanPham);
            }

            // Phân trang
            var pagedSanPhams = await projectedQuery.ToPagedListAsync(currentPage, pageSize);
            viewModel.SanPhams = pagedSanPhams;
            viewModel.CurrentPage = currentPage;
            viewModel.TotalPages = pagedSanPhams.PageCount;

            if (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_ProductList", viewModel);
            }
            return View(viewModel);
        }



        public IActionResult FilterProducts(string danhmuc, string danhmucchitiet, string sort, string keyword, int? page)
        {
            // 1. Xây dựng truy vấn ban đầu (các sản phẩm với thông tin liên quan)
            var productsQuery = _context.SANPHAM
                .Include(sp => sp.DanhMucChiTiet)
                .AsQueryable();

            // 2. Lọc theo danh mục (danhmuc)
            if (!string.IsNullOrEmpty(danhmuc))
            {
                var selectedDanhMucIds = danhmuc.Split(',').Select(int.Parse).ToList();
                productsQuery = productsQuery.Where(p =>
                    selectedDanhMucIds.Contains(p.DanhMucChiTiet.DanhMuc.IdDanhMuc));
            }

            // 3. Lọc theo danh mục chi tiết (danhmucchitiet)
            if (!string.IsNullOrEmpty(danhmucchitiet))
            {
                var selectedDanhMucCTIds = danhmucchitiet.Split(',').Select(int.Parse).ToList();
                productsQuery = productsQuery.Where(p =>
                    selectedDanhMucCTIds.Contains(p.DanhMucChiTiet.IdDanhMucCT));
            }

            // 4. Lọc theo từ khóa (nếu có)
            if (!string.IsNullOrEmpty(keyword))
            {
                productsQuery = productsQuery.Where(p =>
                    p.TenSanPham.Contains(keyword) ||
                    p.SanPhamTacGias.Any(tg => tg.TacGia.TenTacGia.Contains(keyword))
                );
            }

            // 5. Sắp xếp trên tập kết quả đã lọc
            switch (sort)
            {
                case "az":
                    productsQuery = productsQuery.OrderBy(p => p.TenSanPham);
                    break;
                case "za":
                    productsQuery = productsQuery.OrderByDescending(p => p.TenSanPham);
                    break;
                case "price-asc":
                    productsQuery = productsQuery.OrderBy(p => p.GiaBan);
                    break;
                case "price-desc":
                    productsQuery = productsQuery.OrderByDescending(p => p.GiaBan);
                    break;
                default:
                    // Nếu không có sort, có thể áp dụng sắp xếp mặc định
                    productsQuery = productsQuery.OrderBy(p => p.TenSanPham);
                    break;
            }

            // 6. Phân trang: áp dụng Skip/Take trực tiếp trên truy vấn đã được lọc và sắp xếp
            int currentPage = page ?? 1;
            int pageSize = 20;
            int totalCount = productsQuery.Count();
            var pagedData = productsQuery
        .Skip((currentPage - 1) * pageSize)
        .Take(pageSize)
        .Select(sp => new ProductDto
        {
            IdSanPham = sp.IdSanPham,
            TenSanPham = sp.TenSanPham,
            GiaGoc = sp.GiaGoc,
            hinhAnh = sp.hinhAnh,
            TenDanhMucCT = sp.DanhMucChiTiet.TenDanhMucCT
        })
        .ToList();
            var pagedSanPhams = new StaticPagedList<ProductDto>(pagedData, currentPage, pageSize, totalCount);

            // 7. Tạo view model
            var model = new ProductViewModel
            {
                DanhMucs = _context.DANHMUC.Include(dm => dm.DanhMucChiTiets).ToList(),
                SanPhams = pagedSanPhams,
                CurrentPage = currentPage,
                TotalPages = pagedSanPhams.PageCount
            };

            // 8. Trả về PartialView nếu là AJAX, ngược lại View đầy đủ
            if (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_ProductList", model);
            }
            return View("Product", model);
        }

        public async Task<IActionResult> ProductDetail(string id)
        {
            var sanPham = await _context.SANPHAM
                .Include(sp => sp.DanhMucChiTiet)
                .Include(sp => sp.HinhAnhSanPhams)
                .Include(s => s.SanPhamTacGias)
                    .ThenInclude(st => st.TacGia)
                .FirstOrDefaultAsync(sp => sp.IdSanPham == id);

            if (sanPham == null)
            {
                return NotFound();
            }

            // Tăng số lượt xem
            sanPham.SoLuotXem++;
            await _context.SaveChangesAsync();

            return View(sanPham);
        }

    }
}
