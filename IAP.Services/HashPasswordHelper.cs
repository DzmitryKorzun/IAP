using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IAP.Services
{
    public static class HashPasswordHelper
    {
        public static string GetPasswordHash(string password)
        {
            return BitConverter
                .ToString(SHA256.HashData(Encoding.UTF8.GetBytes(password)))
                .Replace("-", "").ToLower();
        }

        public static bool PasswordComparingWithHash(string hash, string password)
        {
            var passwordHash = GetPasswordHash(password);
            return hash == passwordHash? true: false;
        }
    }
}
