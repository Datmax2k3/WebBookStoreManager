using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebBookStoreManage.Data;

namespace WebBookStoreManage.Controllers
{
    public class EmployeeCheckFilter : IActionFilter
    {
        private readonly WebBookStoreManageContext _context;

        public EmployeeCheckFilter(WebBookStoreManageContext context)
        {
            _context = context;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Kiểm tra xem context.Controller có phải là Controller không
            var controller = context.Controller as Controller;
            if (controller != null && context.HttpContext.User.Identity.IsAuthenticated)
            {
                var idTaiKhoanStr = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (int.TryParse(idTaiKhoanStr, out int idTaiKhoan))
                {
                    var account = _context.TAIKHOAN
                        .Include(a => a.NhanVien)
                        .Include(a => a.VaiTro)
                        .FirstOrDefault(a => a.IdTaiKhoan == idTaiKhoan);

                    // Nếu có dữ liệu nhân viên => là nhân viên
                    bool isEmployee = account?.NhanVien != null;
                    // Kiểm tra VaiTro: nếu tên vai trò là "admin" (không phân biệt chữ hoa, chữ thường)
                    bool isAdmin = account?.VaiTro?.TenVaiTro?.Equals("admin", StringComparison.OrdinalIgnoreCase) ?? false;

                    controller.ViewBag.IsEmployee = isEmployee;
                    controller.ViewBag.IsAdmin = isAdmin;
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Không cần thực hiện gì
        }
    }
}
