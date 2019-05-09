using System;
using System.Security.Cryptography;
using System.Text;

namespace Whoever.Common.Extensions
{
    public static class CryptographyExtension
    {

        public static string ToSHA256(this string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha256.ComputeHash(bytes);
                return GetStringFromHash(hash);
            }
        }

        public static string ToSHA512(this string input)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha512.ComputeHash(bytes);
                return GetStringFromHash(hash);
            }
        }

        public static string ToMD5(this string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                var bytes = Encoding.ASCII.GetBytes(input);
                var hash = md5.ComputeHash(bytes);
                return GetStringFromHash(hash);
            }
        }

        public static string ToBase64(this string str)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(plainTextBytes);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            var result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

    }
}
