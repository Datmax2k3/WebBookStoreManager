using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebBookStoreManage.Data;
using WebBookStoreManage.Models;

namespace WebBookStoreManage.Controllers
{
    public class AccountsController : Controller
    {
        private readonly WebBookStoreManageContext _context;
        public AccountsController(WebBookStoreManageContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(TAIKHOAN model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var account = await _context.TAIKHOAN
                .FirstOrDefaultAsync(a => a.TenDangNhap == model.TenDangNhap);

            if (account == null || !new PasswordService.PasswordService().VerifyPassword(account.MatKhau, model.MatKhau))
            {
                TempData["LoginError"] = "Tài khoản hoặc mật khẩu không đúng";
                return View(model);
            }

            // Tạo danh sách claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.TenDangNhap),
                new Claim(ClaimTypes.NameIdentifier, account.IdTaiKhoan.ToString()) // Sử dụng ClaimTypes.NameIdentifier
            };

            // Tạo claims identity
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Đăng nhập người dùng: tạo cookie xác thực
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(IFormCollection form)
        {
            string tenDangNhap = form["TenDangNhap"];
            string matKhau = form["MatKhau"];
            string confirmMatKhau = form["ConfirmMatKhau"];

            // Giữ lại dữ liệu vừa nhập để hiển thị lại nếu có lỗi
            ViewData["TenDangNhap"] = tenDangNhap;

            if (matKhau != confirmMatKhau)
            {
                TempData["RegisterError"] = "Mật khẩu nhập lại không khớp";
                return View();  // Trả về view đăng ký, không lưu vào DB
            }

            // Kiểm tra xem tài khoản đã tồn tại chưa
            var existingAccount = await _context.TAIKHOAN
                .FirstOrDefaultAsync(x => x.TenDangNhap == tenDangNhap);
            if (existingAccount != null)
            {
                TempData["RegisterError"] = "Tài khoản đã tồn tại";
                return View();
            }

            // Mã hóa mật khẩu
            var passwordService = new PasswordService.PasswordService();
            string hashedPassword = passwordService.HashPassword(matKhau);

            // Tạo tài khoản mới với IdVaiTro = 3
            TAIKHOAN newAccount = new TAIKHOAN
            {
                TenDangNhap = tenDangNhap,
                MatKhau = hashedPassword,
                IdVaiTro = 3
            };

            _context.TAIKHOAN.Add(newAccount);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login", "Accounts");
        }

        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }

    }
}
