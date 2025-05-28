// /ViewComponents/CartSummaryViewComponent.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebBookStoreManage.Data;
using WebBookStoreManage.Models;
using WebBookStoreManage.ViewModels;

public class CartSummaryViewComponent : ViewComponent
{
    private readonly WebBookStoreManageContext _context;
    public CartSummaryViewComponent(WebBookStoreManageContext context)
        => _context = context;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = new CartViewModel { CartItems = new List<GIOHANG>(), TotalQuantity = 0, TotalCost = 0 };

        // Truy cập User qua HttpContext của ViewComponent
        var user = HttpContext.User;
        if (user.Identity.IsAuthenticated &&
            int.TryParse(user.FindFirstValue(ClaimTypes.NameIdentifier), out int idTaiKhoan))
        {
            var nguoiDung = await _context.NGUOIDUNG
                .FirstOrDefaultAsync(n => n.IdTaiKhoan == idTaiKhoan);
            if (nguoiDung != null)
            {
                var items = await _context.GIOHANG
                    .Include(g => g.SanPham)
                    .Where(g => g.IdNguoiDung == nguoiDung.IdNguoiDung)
                    .ToListAsync();

                model.CartItems = items;
                model.TotalQuantity = items.Sum(g => g.SoLuong);
                model.TotalCost = items.Sum(g => (g.SanPham.GiaBan ?? 0) * g.SoLuong);
            }
        }

        return View(model);
    }

}
