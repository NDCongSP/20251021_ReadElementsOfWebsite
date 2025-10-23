using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAndGetInfoOfWebsite.httpClient
{
    public static class ConstantApiKey
    {
        /// <summary>
        /// Mặc định giá trị lấy từ hệ thống.
        /// </summary>
        public static string APP_ID { get; set; } = "13D3D7DDA5002955F47DAAC0D37C0";

        /// <summary>
        /// Mặc định giá trị lấy từ hệ thống.
        /// </summary>
        public static string APP_Secretkey { get; set; } = "C1DD8C94889B411A95B80C88D1221597";

        public static string SecretKey { get; set; } = "09C0FD0D95834C73A1E7C9BCDBC6D226";

        /// <summary>
        /// Mặc định giá trị dưới.
        /// </summary>
        public static string OpenKeyId { get; set; } = "045702EF163D4E0A97DEA57943D3F176";

        public static Dictionary<string, string> GenerateSheinSignature(string openKeyId, string secretKey, string path)
        {
            // Quy tắc 2: Lấy timestamp (mili-giây)
            string timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();

            // Quy tắc 4: Tạo 5 ký tự ngẫu nhiên
            string randomKey = GenerateRandomString(5);

            // Step 1: Assemble signature data VALUE
            string value = $"{openKeyId}&{timestamp}&{path}";
            Console.WriteLine($"Step 1 - Signature data VALUE: {value}");

            // Step 2: Assemble signature key KEY
            string key = $"{secretKey}{randomKey}";
            Console.WriteLine($"Step 2 - Signature key KEY: {key}");

            // Step 3: HMAC-SHA256 calculation and conversion to hexadecimal
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] valueBytes = Encoding.UTF8.GetBytes(value);

            using (HMACSHA256 hmac = new HMACSHA256(keyBytes))
            {
                byte[] hmacResult = hmac.ComputeHash(valueBytes);
                StringBuilder hexBuilder = new StringBuilder();

                foreach (byte b in hmacResult)
                {
                    hexBuilder.Append(b.ToString("x2"));
                }

                string hexSignature = hexBuilder.ToString();
                Console.WriteLine($"Step 3 - HMAC-SHA256 result (HEX): {hexSignature}");

                // Step 4: Base64 encoding
                string base64Signature = Convert.ToBase64String(Encoding.UTF8.GetBytes(hexSignature));

                //// Base64 encode trực tiếp từ raw bytes
                //string base64Signature = Convert.ToBase64String(hmacResult);
                Console.WriteLine($"Step 4 - Base64 encoding result: {base64Signature}");

                // Step 5: Append RandomKey
                string finalSignature = $"{randomKey}{base64Signature}";
                Console.WriteLine($"Step 5 - Final signature: {finalSignature}");

                // Trả về tất cả các header cần thiết
                var headers = new Dictionary<string, string>
                {
                    { "x-lt-signature", finalSignature },
                    { "x-lt-openKeyId", openKeyId },
                    { "x-lt-timestamp", timestamp },
                    { "language", "en" }, // Header này có trong Postman của bạn
                    { "Content-Type","application/json"}
                };

                return headers;
            }
        }

        /// <summary>
        /// Hàm băm HMAC-SHA256 và encode Base64.
        /// </summary>
        private static string ComputeHmacSha256AndBase64(string data, string key)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                return Convert.ToBase64String(hashBytes);
            }
        }

        /// <summary>
        /// Hàm tạo chuỗi ngẫu nhiên (gồm chữ và số)
        /// </summary>
        private static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
