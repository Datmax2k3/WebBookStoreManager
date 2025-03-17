using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        

        public IActionResult Index()
        {
            return View();
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

        public IActionResult Product(int? categoryId, string danhmuc, string danhmucchitiet, string sort, int? page)
        {
            int currentPage = page ?? 1;
            int pageSize = 20;

            var danhMucs = _context.DANHMUC.Include(dm => dm.DanhMucChiTiets).ToList();

            // Nếu có giá trị lọc đa lựa chọn từ danhmuc thì ưu tiên sử dụng nó, ngược lại mới dùng categoryId
            if (!string.IsNullOrEmpty(danhmuc))
            {
                // Không tự động gán categoryId bằng giá trị đầu tiên
            }
            else if (categoryId == null && danhMucs.Any())
            {
                categoryId = danhMucs.First().IdDanhMuc;
            }

            // Lưu lại các giá trị lọc trong view model
            var viewModel = new ProductViewModel
            {
                DanhMucs = danhMucs,
                // Các thuộc tính khác...
                SelectedCategoryId = categoryId ?? 0,
                SelectedDanhMuc = danhmuc,
                SelectedDanhMucChiTiet = danhmucchitiet
            };

            // Xây dựng truy vấn lọc sản phẩm
            var productsQuery = _context.SANPHAM.Include(sp => sp.DanhMucChiTiet).AsQueryable();

            if (!string.IsNullOrEmpty(danhmuc))
            {
                var selectedDanhMucIds = danhmuc.Split(',').Select(int.Parse).ToList();
                productsQuery = productsQuery.Where(p => selectedDanhMucIds.Contains(p.DanhMucChiTiet.DanhMuc.IdDanhMuc));
            }
            else if (categoryId.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.DanhMucChiTiet != null
                    && p.DanhMucChiTiet.IdDanhMuc == categoryId.Value);
            }

            // Nếu có lọc theo danh mục chi tiết
            if (!string.IsNullOrEmpty(danhmucchitiet))
            {
                var selectedDanhMucCTIds = danhmucchitiet.Split(',').Select(int.Parse).ToList();
                productsQuery = productsQuery.Where(p => selectedDanhMucCTIds.Contains(p.DanhMucChiTiet.IdDanhMucCT));
            }

            // Sau khi lọc theo danhmucchitiet
            if (!string.IsNullOrEmpty(sort))
            {
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
                        productsQuery = productsQuery.OrderBy(p => p.TenSanPham);
                        break;
                }
            }
            else
            {
                // Nếu không có sort, sắp xếp mặc định
                productsQuery = productsQuery.OrderBy(p => p.TenSanPham);
            }

            var sanPhams = productsQuery.ToList();
            var pagedSanPhams = sanPhams.ToPagedList(currentPage, pageSize);

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
                .ToList();
            var pagedSanPhams = new StaticPagedList<SANPHAM>(pagedData, currentPage, pageSize, totalCount);

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
