using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBookStoreManage.PasswordService
{
    public class PasswordService
    {
        private readonly PasswordHasher<object> _passwordHasher = new PasswordHasher<object>();

        // Mã hóa mật khẩu
        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        // Kiểm tra mật khẩu
        public bool VerifyPassword(string hashedPassword, string password)
        {
            return _passwordHasher.VerifyHashedPassword(null, hashedPassword, password) == PasswordVerificationResult.Success;
        }
    }
}
