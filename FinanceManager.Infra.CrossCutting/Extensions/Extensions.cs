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
        public static int ToInt(this object input) => Convert.ToInt32(input);

        public static string ToSha256(this string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();

                foreach (var b in bytes)
                    builder.Append(b.ToString("x2"));
                
                return builder.ToString();
            }
        }

        public static bool IsNull(this object input) => input == null;

        public static bool IsNotNull(this object input) => input != null;

        public static bool IsNotNull<T>(this T input, out T result)
        {
            result = input != null ? input : default;

            return input != null;
        }

        public static decimal MoneyToDecimal(this string input)
        {
            input = input.Contains(",") ? input.Replace(",", string.Empty) : input;

            return Convert.ToDecimal(input);
        }

        public static K Map<T, K>(this T inputObj, Func<T, K> func)
        {
            return func(inputObj);
        }

        public static DateTime ToDateTime(this object obj)
        {
            return Convert.ToDateTime(obj);
        }
    }
}
