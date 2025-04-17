using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebBookStoreManage.ViewModels
{
    public class DirectOrderViewModel
    {
        [Display(Name = "Ngày đặt")]
        [Required(ErrorMessage = "Vui lòng nhập ngày đặt")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        [Display(Name = "Mã nhân viên")]
        public int StaffId { get; set; }

        public List<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();

        [Display(Name = "Tổng tiền")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Tổng tiền phải lớn hơn 0")]
        public decimal TotalAmount { get; set; }
    }

    public class OrderItemViewModel
    {
        [Required(ErrorMessage = "Vui lòng chọn sản phẩm")]
        [Display(Name = "Sản phẩm")]
        public string ProductId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số lượng")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; } = 1;

        [Display(Name = "Thành tiền")]
        public decimal Amount { get; set; }
    }
}