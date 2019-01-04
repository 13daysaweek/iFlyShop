using System.Security.Cryptography;
using System.Text;

namespace ThirteenDaysAWeek.iFlyShop.Api.Services
{
    public class OrderNumberService : IOrderNumberService
    {
        private static readonly char[] _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        public string GetNewOrderNumber(int size)
        {
            var data = new byte[size];
            using (var crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }

            var result = new StringBuilder(size);
            foreach (var b in data)
            {
                result.Append(_chars[b % (_chars.Length)]);
            }

            return result.ToString();
        }
    }
}