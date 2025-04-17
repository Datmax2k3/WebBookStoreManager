using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebBookStoreManage.Models;

namespace WebBookStoreManage.ViewModels
{
    public class PaymentViewModel
    {
        public DIACHIGIAOHANG DeliveryAddress { get; set; }
        public NGUOIDUNG Shoppers { get; set; }
        public List<GIOHANG> CartItems { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public string Note { get; set; }
        public string DiscountCode { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn phương thức vận chuyển.")]
        public string ShippingMethod { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn phương thức thanh toán.")]
        public string PaymentMethod { get; set; }

        public decimal ShippingFee { get; set; }

        public bool IsPaid { get; set; }
    }
}
