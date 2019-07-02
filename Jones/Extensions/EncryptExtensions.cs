using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Jones.Extensions
{
    public static class EncryptExtensions
    {
        public static string Md5(this string source)
        {
            return source.IsNullOrEmpty() 
                ? null 
                : new MD5CryptoServiceProvider()
                    .ComputeHash(Encoding.UTF8.GetBytes(source))
                    .Aggregate<byte, string>(null, (current, b) => current + b.ToString("X2")).ToLower();
        }
    }
}