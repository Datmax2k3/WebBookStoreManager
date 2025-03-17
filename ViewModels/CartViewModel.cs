using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBookStoreManage.Models;

namespace WebBookStoreManage.ViewModels
{
    public class CartViewModel
    {
        public List<GIOHANG> CartItems { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalCost { get; set; }
    }
}
