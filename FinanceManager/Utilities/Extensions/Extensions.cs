using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Utilities.Extensions
{
    public static class Extensions
    {
        public static int ToInt(object input) => Convert.ToInt32(input);

        public static string ToSha256(this string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();

                Parallel.For(0, bytes.Length, i =>
                {
                    builder.Append(bytes[i].ToString("x2"));
                });
                
                return builder.ToString();
            }
        }

        public static bool IsNull(this object input) => input == null;

        public static decimal ToDecimal(this string input)
        {
            return Convert.ToDecimal(input);
        }
    }
}
