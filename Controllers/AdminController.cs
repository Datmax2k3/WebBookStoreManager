using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBookStoreManage.Data;
using WebBookStoreManage.Models;
using WebBookStoreManage.ViewModels;

namespace WebBookStoreManage.Controllers
{
    public class AdminController : Controller
    {
        private readonly WebBookStoreManageContext _context;

        public AdminController(WebBookStoreManageContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RevenueReport(DateTime? fromDate, DateTime? toDate, string reportType = "daily")
        {
            // Kiểm tra quyền quản trị
            bool isEmployee = ViewBag.IsEmployee != null && (bool)ViewBag.IsEmployee;
            bool isAdmin = ViewBag.IsAdmin != null && (bool)ViewBag.IsAdmin;

            if (!isAdmin && !isEmployee)
            {
                return RedirectToAction("AccessDenied", "Accounts");
            }

            // Xử lý mặc định cho ngày bắt đầu và kết thúc
            if (!fromDate.HasValue)
            {
                fromDate = DateTime.Now.AddMonths(-1);
            }

            if (!toDate.HasValue)
            {
                toDate = DateTime.Now;
            }

            // Đảm bảo ngày bắt đầu luôn trước ngày kết thúc
            if (fromDate > toDate)
            {
                var temp = fromDate;
                fromDate = toDate;
                toDate = temp;
            }

            // Lấy toàn bộ đơn hàng hoàn thành trong khoảng thời gian
            var completedOrders = await _context.DONHANG
                .Include(d => d.PhieuDat)
                    .ThenInclude(p => p.ChiTietPhieuDats)
                        .ThenInclude(ct => ct.SanPham)
                .Where(d => d.TrangThaiDonHang == TrangThaiDonHang.hoanThanh &&
                       d.NgayThanhToan >= fromDate && d.NgayThanhToan <= toDate.Value.AddDays(1))
                .ToListAsync();

            var model = new RevenueReportViewModel
            {
                FromDate = fromDate,
                ToDate = toDate,
                ReportType = reportType
            };

            // Tính toán tổng doanh thu, số đơn hàng
            model.TotalOrders = completedOrders.Count;
            model.TotalRevenue = completedOrders.Sum(o => o.PhieuDat.TongTien);
            model.TotalProducts = completedOrders.Sum(o => o.PhieuDat.ChiTietPhieuDats.Sum(ct => ct.SoLuong));
            model.AverageOrderValue = model.TotalOrders > 0 ? model.TotalRevenue / model.TotalOrders : 0;

            // Xử lý dữ liệu theo loại báo cáo
            switch (reportType)
            {
                case "daily":
                    // Dữ liệu theo ngày
                    model.PeriodColumnName = "Ngày";
                    model.ChartTitle = "Theo ngày";

                    var dailyData = completedOrders
                        .GroupBy(o => o.NgayThanhToan.Value.Date)
                        .OrderBy(g => g.Key)
                        .Select(g => new PeriodRevenueData
                        {
                            PeriodName = g.Key.ToString("dd/MM/yyyy"),
                            OrderCount = g.Count(),
                            ProductCount = g.Sum(o => o.PhieuDat.ChiTietPhieuDats.Sum(ct => ct.SoLuong)),
                            Revenue = g.Sum(o => o.PhieuDat.TongTien)
                        })
                        .ToList();

                    model.RevenueByPeriod = dailyData;
                    model.ChartLabels = dailyData.Select(d => d.PeriodName).ToList();
                    model.ChartData = dailyData.Select(d => d.Revenue).ToList();
                    break;

                case "monthly":
                    // Dữ liệu theo tháng
                    model.PeriodColumnName = "Tháng";
                    model.ChartTitle = "Theo tháng";

                    var monthlyData = completedOrders
                        .GroupBy(o => new { Month = o.NgayThanhToan.Value.Month, Year = o.NgayThanhToan.Value.Year })
                        .OrderBy(g => g.Key.Year)
                        .ThenBy(g => g.Key.Month)
                        .Select(g => new PeriodRevenueData
                        {
                            PeriodName = $"{g.Key.Month}/{g.Key.Year}",
                            OrderCount = g.Count(),
                            ProductCount = g.Sum(o => o.PhieuDat.ChiTietPhieuDats.Sum(ct => ct.SoLuong)),
                            Revenue = g.Sum(o => o.PhieuDat.TongTien)
                        })
                        .ToList();

                    model.RevenueByPeriod = monthlyData;
                    model.ChartLabels = monthlyData.Select(d => d.PeriodName).ToList();
                    model.ChartData = monthlyData.Select(d => d.Revenue).ToList();
                    break;

                case "yearly":
                    // Dữ liệu theo năm
                    model.PeriodColumnName = "Năm";
                    model.ChartTitle = "Theo năm";

                    var yearlyData = completedOrders
                        .GroupBy(o => o.NgayThanhToan.Value.Year)
                        .OrderBy(g => g.Key)
                        .Select(g => new PeriodRevenueData
                        {
                            PeriodName = g.Key.ToString(),
                            OrderCount = g.Count(),
                            ProductCount = g.Sum(o => o.PhieuDat.ChiTietPhieuDats.Sum(ct => ct.SoLuong)),
                            Revenue = g.Sum(o => o.PhieuDat.TongTien)
                        })
                        .ToList();

                    model.RevenueByPeriod = yearlyData;
                    model.ChartLabels = yearlyData.Select(d => d.PeriodName).ToList();
                    model.ChartData = yearlyData.Select(d => d.Revenue).ToList();
                    break;
            }

            // Lấy top 5 sản phẩm bán chạy nhất
            var topProducts = completedOrders
                .SelectMany(o => o.PhieuDat.ChiTietPhieuDats)
                .GroupBy(ct => ct.IdSanPham)
                .Select(g => new TopProductData
                {
                    IdSanPham = g.Key,
                    TenSanPham = g.First().SanPham.TenSanPham,
                    SoLuong = g.Sum(ct => ct.SoLuong),
                    DoanhThu = g.Sum(ct => ct.ThanhTien)
                })
                .OrderByDescending(p => p.DoanhThu)
                .Take(5)
                .ToList();

            model.TopProducts = topProducts;

            return View(model);
        }
    }
}
