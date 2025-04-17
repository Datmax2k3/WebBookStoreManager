using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBookStoreManage.ViewModels
{
    public class CreateProfileViewModel
    {
        [Required(ErrorMessage = "Họ tên không được để trống")]
        public string TenNguoiDung { get; set; }

        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string soDienThoai { get; set; }

        [Required(ErrorMessage = "Mã xác thực không được để trống")]
        public string VerificationCode { get; set; }
    }
}
