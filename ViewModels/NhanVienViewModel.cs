using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebBookStoreManage.Models;

namespace WebBookStoreManage.ViewModels
{
    public class NhanVienViewModel
    {
        [Required]
        public NHANVIEN NhanVien { get; set; }

        [Required]
        public TAIKHOAN TaiKhoan { get; set; }
    }
}
