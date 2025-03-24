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

            // Kiểm tra nếu đã có profile thì chuyển đến Profile
            var user = await _context.NGUOIDUNG.FirstOrDefaultAsync(u => u.IdTaiKhoan == idTaiKhoan);
            if (user != null && !string.IsNullOrEmpty(user.TenNguoiDung))
                return RedirectToAction("Profile");

            // Nếu chưa có profile, tạo một model mới
            var model = new NGUOIDUNG();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProfile(NGUOIDUNG model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var idTaiKhoanStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(idTaiKhoanStr, out int idTaiKhoan))
            {
                return RedirectToAction("Login");
            }

            // Kiểm tra xem hồ sơ của người dùng này đã tồn tại chưa
            var existingUser = await _context.NGUOIDUNG.FirstOrDefaultAsync(u => u.IdTaiKhoan == idTaiKhoan);
            if (existingUser != null)
            {
                // Nếu đã có hồ sơ thì chuyển hướng đến trang Profile
                return RedirectToAction("Profile");
            }

            // Nếu chưa có, tạo mới hồ sơ
            // Email và các trường khác sẽ được nhập từ form (đảm bảo email được điền đầy đủ)
            model.IdTaiKhoan = idTaiKhoan; // gán IdTaiKhoan từ Claims vào model
            _context.NGUOIDUNG.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile");
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
