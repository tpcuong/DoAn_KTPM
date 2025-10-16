using System.Security.Cryptography;
using System.Text;

namespace CuahangNongduoc.Helpers
{
    public static class PasswordHelper
    {
        public static string HashSha256(string plain)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(plain);
                var hash = sha.ComputeHash(bytes);
                var sb = new StringBuilder();
                foreach (var b in hash)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
