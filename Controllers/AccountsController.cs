using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using WebBookStoreManage.Data;
using WebBookStoreManage.Models;
using WebBookStoreManage.Services;
using WebBookStoreManage.ViewModels;

namespace WebBookStoreManage.Controllers
{
    public class AccountsController : Controller
    {
        private readonly WebBookStoreManageContext _context;
        private readonly EmailService _emailSender;
        private readonly IDataProtector _protector;
        public AccountsController(WebBookStoreManageContext context, EmailService emailSender, IDataProtectionProvider dpProvider)
        {
            _context = context;
            _emailSender = emailSender;
            _protector = dpProvider.CreateProtector("ResetPassword");
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
                return View(model);

            // Eager‐load NhanVien ⇒ LoaiNhanVien và VaiTro
            var account = await _context.TAIKHOAN
                .Include(a => a.NhanVien)
                    .ThenInclude(nv => nv.LoaiNhanVien)
                .Include(a => a.VaiTro)
                .FirstOrDefaultAsync(a => a.TenDangNhap == model.TenDangNhap);

            if (account == null
                || !new PasswordService.PasswordService()
                            .VerifyPassword(account.MatKhau, model.MatKhau))
            {
                TempData["LoginError"] = "Tài khoản hoặc mật khẩu không đúng";
                return View(model);
            }

            bool isEmployee = account.NhanVien != null;
            bool isEmployeeTransport = isEmployee
                && account.NhanVien.LoaiNhanVien.TenLoaiNhanVien
                      .Equals("nhân viên giao hàng", StringComparison.OrdinalIgnoreCase);
            bool isAdmin = account.VaiTro?.TenVaiTro
                      .Equals("admin", StringComparison.OrdinalIgnoreCase) ?? false;

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, account.TenDangNhap),
        new Claim(ClaimTypes.NameIdentifier, account.IdTaiKhoan.ToString()),
        new Claim("IsEmployee", isEmployee.ToString()),
        new Claim("IsEmployeeTransport", isEmployeeTransport.ToString()),
        new Claim("IsAdmin", isAdmin.ToString())
    };

            var identity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));

            if (isEmployeeTransport)
                return RedirectToAction("EmployeeOrderManagement", "Order");
            if (isAdmin)
                return RedirectToAction("Index", "Admin");
            if (isEmployee)
                return RedirectToAction("EmployeeOrderManagement", "Order");

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

        // GET: Profile – hiển thị thông tin cá nhân
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Accounts");
            }

            var idTaiKhoanStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(idTaiKhoanStr, out int idTaiKhoan))
            {
                return RedirectToAction("Login", "Accounts");
            }

            var account = await _context.TAIKHOAN
                .Include(a => a.NguoiDung)
                .FirstOrDefaultAsync(a => a.IdTaiKhoan == idTaiKhoan);

            if (account == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (account.NguoiDung == null)
            {
                return RedirectToAction("CreateProfile");
            }

            return View(account.NguoiDung);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProfile()
        {
            bool isEmployeeTransport = ViewBag.isEmployeeTransport != null && (bool)ViewBag.isEmployeeTransport;
            if (isEmployeeTransport)
                return RedirectToAction("Index", "Home");

            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login");

            var idTaiKhoanStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(idTaiKhoanStr, out int idTaiKhoan))
                return RedirectToAction("Login");

            // Nếu profile đã tồn tại
            var user = await _context.NGUOIDUNG.FirstOrDefaultAsync(u => u.IdTaiKhoan == idTaiKhoan);
            if (user != null && !string.IsNullOrEmpty(user.TenNguoiDung))
                return RedirectToAction("Profile");

            // Khởi tạo ViewModel mới
            var model = new CreateProfileViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProfile(CreateProfileViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login");

            // Validate các trường bắt buộc
            if (string.IsNullOrEmpty(model.Email))
                ModelState.AddModelError("Email", "Email không được để trống");

            if (string.IsNullOrEmpty(model.VerificationCode))
                ModelState.AddModelError("VerificationCode", "Mã xác thực không được để trống");

            // Kiểm tra nếu email đã tồn tại
            var existingUser = await _context.NGUOIDUNG.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (existingUser != null)
                ModelState.AddModelError("Email", "Email đã được sử dụng.");

            // Lấy mã xác thực từ Session (đã được lưu trong SendVerificationCode)
            var sessionCode = HttpContext.Session.GetString("VerificationCode");
            var sessionEmail = HttpContext.Session.GetString("VerificationEmail");

            // Kiểm tra mã xác thực nếu email trùng với email trong session
            if (!string.IsNullOrEmpty(model.Email) && model.Email == sessionEmail)
            {
                if (string.IsNullOrEmpty(sessionCode) || model.VerificationCode != sessionCode)
                {
                    ModelState.AddModelError("VerificationCode", "Mã xác thực không đúng.");
                }
            }
            else
            {
                // Nếu email không trùng với email trong session, cần báo lỗi
                ModelState.AddModelError("Email", "Email không khớp với email đã nhận mã xác thực.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Nếu hợp lệ, tạo mới hồ sơ
            var idTaiKhoan = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var newUser = new NGUOIDUNG
            {
                IdTaiKhoan = idTaiKhoan,
                TenNguoiDung = model.TenNguoiDung,
                DiaChi = model.DiaChi,
                Email = model.Email,
                soDienThoai = model.soDienThoai
            };

            _context.NGUOIDUNG.Add(newUser);
            await _context.SaveChangesAsync();

            // Xóa dữ liệu trong Session sau khi hoàn tất
            HttpContext.Session.Remove("VerificationCode");
            HttpContext.Session.Remove("VerificationEmail");

            return RedirectToAction("Profile");
        }

        [HttpPost]
        [Route("Account/SendVerificationCode")]
        public async Task<IActionResult> SendVerificationCode(string email)
        {
            // Kiểm tra email có tồn tại trong database không
            var existingUser = await _context.NGUOIDUNG.FirstOrDefaultAsync(u => u.Email == email);
            if (existingUser != null)
            {
                return Json(new { success = false, message = "Email đã được sử dụng." });
            }

            // Sinh mã xác thực ngẫu nhiên (ví dụ: 6 chữ số)
            var verificationCode = new Random().Next(100000, 999999).ToString();
            HttpContext.Session.SetString("VerificationCode", verificationCode);
            HttpContext.Session.SetString("VerificationEmail", email);

            // Gửi email chứa mã xác thực
            await _emailSender.SendEmailAsync(email, "Mã xác thực", $"Mã xác thực của bạn là: {verificationCode}");

            return Json(new { success = true });
        }



        // GET: EditProfile – hiển thị form cập nhật thông tin cá nhân
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Accounts");
            }

            var idTaiKhoanStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(idTaiKhoanStr, out int idTaiKhoan))
            {
                return RedirectToAction("Login", "Accounts");
            }

            var account = await _context.TAIKHOAN
                .Include(a => a.NguoiDung)
                .FirstOrDefaultAsync(a => a.IdTaiKhoan == idTaiKhoan);

            if (account == null)
            {
                return RedirectToAction("Accounts", "Login");
            }

            return View(account.NguoiDung);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(NGUOIDUNG model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Tải người dùng từ DB theo ID (đảm bảo ID không bị thay đổi)
            var userInDb = await _context.NGUOIDUNG.FirstOrDefaultAsync(u => u.IdNguoiDung == model.IdNguoiDung);
            if (userInDb == null)
            {
                return NotFound();
            }

            // Cập nhật các trường cần thiết, nhưng không cập nhật email
            userInDb.TenNguoiDung = model.TenNguoiDung;
            userInDb.soDienThoai = model.soDienThoai;
            userInDb.DiaChi = model.DiaChi;

            await _context.SaveChangesAsync();

            return RedirectToAction("Profile");
        }


        // GET: EditPassword – hiển thị form cập nhật mật khẩu
        [HttpGet]
        public IActionResult EditPassword()
        {
            return View();
        }

        // POST: EditPassword – cập nhật mật khẩu
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPassword(string currentPassword, string newPassword, string confirmPassword)
        {
            if (newPassword != confirmPassword)
            {
                TempData["PasswordError"] = "Mật khẩu mới và mật khẩu xác nhận không khớp";
                return View();
            }

            var idTaiKhoanStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(idTaiKhoanStr, out int idTaiKhoan))
            {
                return RedirectToAction("Login", "Accounts");
            }

            var account = await _context.TAIKHOAN.FirstOrDefaultAsync(a => a.IdTaiKhoan == idTaiKhoan);
            if (account == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var passwordService = new PasswordService.PasswordService();
            if (!passwordService.VerifyPassword(account.MatKhau, currentPassword))
            {
                TempData["PasswordError"] = "Mật khẩu hiện tại không đúng";
                return View();
            }

            account.MatKhau = passwordService.HashPassword(newPassword);
            _context.TAIKHOAN.Update(account);
            await _context.SaveChangesAsync();

            TempData["PasswordSuccess"] = "Đổi mật khẩu thành công";
            return RedirectToAction("EditPassword");
        }

        // GET: hiển thị form nhập email
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        // POST: sau khi nhập email, sang màn xác nhận
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            // tìm user theo NGUOIDUNG.Email
            var nguoiDung = await _context.NGUOIDUNG
                                 .Include(u => u.TaiKhoan)
                                 .FirstOrDefaultAsync(u => u.Email == email);
            if (nguoiDung == null)
            {
                TempData["Message"] = "Email không tồn tại trong hệ thống.";
                return View();
            }

            // Tạo mật khẩu tạm
            var newPwd = Guid.NewGuid().ToString("n").Substring(0, 8);
            // Build token chứa: “idTaiKhoan|newPwd|expireTicks”
            var payload = $"{nguoiDung.IdTaiKhoan}|{newPwd}|{DateTime.UtcNow.AddHours(2).Ticks}";
            var token = _protector.Protect(payload);

            // Link xác nhận
            var confirmUrl = Url.Action(
                "ConfirmReset",
                "Accounts",
                new { token = WebUtility.UrlEncode(token) },
                protocol: Request.Scheme);

            // Gửi email
            var body = $@"
        Mật khẩu tạm của bạn là <b>{newPwd}</b><br/>
        Click <a href=""{confirmUrl}"">vào đây</a> để xác nhận đổi mật khẩu.";
            await _emailSender.SendEmailAsync(email, "Đặt lại mật khẩu", body);

            TempData["Message"] = "Chúng tôi đã gửi email chứa hướng dẫn đến bạn.";
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> ConfirmReset(string token)
        {
            string payload;
            try
            {
                payload = _protector.Unprotect(WebUtility.UrlDecode(token));
            }
            catch
            {
                return Content("Link không hợp lệ hoặc đã hết hạn.");
            }

            // payload = "idTaiKhoan|newPwd|expireTicks"
            var parts = payload.Split('|');
            if (parts.Length != 3 ||
                !int.TryParse(parts[0], out var idTk) ||
                !long.TryParse(parts[2], out var ticks) ||
                DateTime.UtcNow.Ticks > ticks)
            {
                return Content("Link đã hết hạn hoặc không hợp lệ.");
            }

            var newPwd = parts[1];
            // Cập nhật mật khẩu:
            var account = await _context.TAIKHOAN.FindAsync(idTk);
            if (account == null) return Content("Tài khoản không tồn tại.");

            // Hash và lưu
            account.MatKhau = new PasswordService.PasswordService().HashPassword(newPwd);
            await _context.SaveChangesAsync();

            // Tạo URL tới Login
            var loginUrl = Url.Action("Login", "Accounts");

            // Nội dung HTML với meta-refresh sau 2 giây
            var html = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"" />
    <title>Đổi mật khẩu thành công</title>
    <meta http-equiv=""refresh"" content=""2;url={loginUrl}"" />
</head>
<body style=""font-family: Arial, sans-serif; text-align: center; padding-top: 50px;"">
    <h2>Đổi mật khẩu thành công!</h2>
    <p>Bạn sẽ được chuyển đến trang đăng nhập trong giây lát…</p>
</body>
</html>";

            return Content(html, "text/html; charset=utf-8");
        }


        // Utility: sinh password ngẫu nhiên
        private string GenerateRandomPassword(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var rnd = new Random();
            return new string(Enumerable
                .Range(0, length)
                .Select(_ => chars[rnd.Next(chars.Length)])
                .ToArray());
        }



    }
}
