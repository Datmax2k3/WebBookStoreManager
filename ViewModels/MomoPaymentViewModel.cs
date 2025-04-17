using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBookStoreManage.ViewModels
{
    public class MomoPaymentViewModel
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentCode { get; set; }
        public string QrCodeUrl { get; set; }
    }
}
