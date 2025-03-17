//ViewModels/ProductViewModel.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using WebBookStoreManage.Models;

namespace WebBookStoreManage.ViewModels
{
    public class ProductViewModel
    {
        public List<DANHMUC> DanhMucs { get; set; }
        public IPagedList<SANPHAM> SanPhams { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int SelectedCategoryId { get; set; }
        public string SelectedDanhMuc { get; set; } // Lưu giá trị của tham số 'danhmuc'
        public string SelectedDanhMucChiTiet { get; set; } // Lưu giá trị của 'danhmucchitiet'
    }
}
