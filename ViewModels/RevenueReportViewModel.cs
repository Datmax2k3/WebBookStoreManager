using System;
using System.Collections.Generic;
using WebBookStoreManage.Models;

namespace WebBookStoreManage.ViewModels
{
    public class RevenueReportViewModel
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string ReportType { get; set; } = "daily"; // daily, monthly, yearly

        public decimal TotalRevenue { get; set; }
        public int TotalOrders { get; set; }
        public decimal AverageOrderValue { get; set; }
        public int TotalProducts { get; set; }

        public string ChartTitle { get; set; }
        public List<string> ChartLabels { get; set; } = new List<string>();
        public List<decimal> ChartData { get; set; } = new List<decimal>();

        public string PeriodColumnName { get; set; } = "Ngày";
        public List<PeriodRevenueData> RevenueByPeriod { get; set; } = new List<PeriodRevenueData>();
        public List<TopProductData> TopProducts { get; set; } = new List<TopProductData>();
    }

    public class PeriodRevenueData
    {
        public string PeriodName { get; set; }
        public int OrderCount { get; set; }
        public int ProductCount { get; set; }
        public decimal Revenue { get; set; }
    }

    public class TopProductData
    {
        public string IdSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int SoLuong { get; set; }
        public decimal DoanhThu { get; set; }
    }
}