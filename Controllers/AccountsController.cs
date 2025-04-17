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
using WebBookStoreManage.Services;
using WebBookStoreManage.ViewModels;

namespace WebBookStoreManage.Controllers
{
    public class AccountsController : Controller
    {
        private readonly WebBookStoreManageContext _context;
        private readonly EmailService _emailSender;
        public AccountsController(WebBookStoreManageContext context, EmailService emailSender)
        {
            _context = context;
            _emailSender = emailSender;
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

            // Kiểm tra xem tài khoản có phải của nhân viên không
            bool isEmployee = account.NhanVien != null;

            // Tạo danh sách claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.TenDangNhap),
                new Claim(ClaimTypes.NameIdentifier, account.IdTaiKhoan.ToString()),
                // Thêm claim để xác định nhân viên
                new Claim("IsEmployee", isEmployee.ToString())
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

    }
}
