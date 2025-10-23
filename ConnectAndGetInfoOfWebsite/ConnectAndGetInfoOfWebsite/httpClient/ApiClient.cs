using ConnectAndGetInfoOfWebsite.httpClient;
using DocumentFormat.OpenXml.InkML;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConnectAndGetInfoOfWebsite
{
    public class ApiClient
    {
        private static readonly HttpClient client = new HttpClient();

        // THÊM DÒNG NÀY VÀO:
        static ApiClient()
        {
            client.DefaultRequestHeaders.ExpectContinue = false;
        }

        public static async Task<Result<TResponse>> SendRequestAsync<TRequest, TResponse>(
                    string url, string path, HttpMethod method, TRequest body)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // 1. Generate signature headers
                    var authHeaders = ConstantApiKey.GenerateSheinSignature(
                        ConstantApiKey.OpenKeyId,
                        ConstantApiKey.SecretKey,
                        path
                    );

                    // 2. Tạo nội dung body
                    var content = new StringContent(
                        JsonConvert.SerializeObject(body),
                        Encoding.UTF8,
                        "application/json"
                    );

                    // 3. Chuẩn bị HttpRequestMessage
                    var request = new HttpRequestMessage(method, $"{url}{path}")
                    {
                        Content = content
                    };

                    // 4. Thêm các header cần thiết
                    foreach (var header in authHeaders)
                    {
                        // Lưu ý: Content-Type phải thêm vào content.Headers, không phải request.Headers
                        if (header.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
                        {
                            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        }
                        else
                        {
                            request.Headers.Add(header.Key, header.Value);
                        }
                    }

                    // 5. Gửi request
                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    // 6. Đọc kết quả
                    var responseBodyString = await response.Content.ReadAsStringAsync();
                    var responseBody = JsonConvert.DeserializeObject<TResponse>(responseBodyString);

                    return await Result<TResponse>.SuccessAsync(responseBody);
                }
            }
            catch (Exception ex)
            {
                return await Result<TResponse>.FailAsync(ex.Message);
            }
        }


        /// <summary>
        /// Gửi request POST đến API với body và headers tùy chỉnh.
        /// </summary>
        /// <typeparam name="TRequest">Kiểu dữ liệu của body gửi đi.</typeparam>
        /// <typeparam name="TResponse">Kiểu dữ liệu của response mong đợi.</typeparam>
        /// <param name="url">URL của API.</param>
        /// <param name="body">Đối tượng body sẽ được serialize thành JSON.</param>
        /// <param name="customHeaders">Dictionary chứa các header tùy chỉnh (ví dụ: x-lt-signature, ...)</param>
        /// <returns>Một Result object chứa TResponse hoặc thông báo lỗi.</returns>
        public static async Task<Result<TResponse>> SendRequestAsync1<TRequest, TResponse>(
            string url,
            TRequest body,
            Dictionary<string, string> customHeaders = null) // Thêm tham số headers
        {
            // 1. Tạo nội dung JSON cho body
            // "application/json" đã tự động thêm header Content-Type
            var content = new StringContent(
                JsonConvert.SerializeObject(body),
                Encoding.UTF8,
                "application/json");

            // 2. Sử dụng HttpRequestMessage để có thể thêm headers
            // Dùng 'using' để đảm bảo request message được giải phóng
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, url))
            {
                // 3. Gán nội dung (body) cho request
                requestMessage.Content = content;

                // 4. Thêm các header tùy chỉnh vào request
                if (customHeaders != null)
                {
                    foreach (var header in customHeaders)
                    {
                        // Dùng TryAddWithoutValidation để chấp nhận các key header lạ (như x-lt-...)
                        requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value);
                    }
                }

                try
                {
                    // 5. Gửi request bằng SendAsync thay vì PostAsync
                    var response = await client.SendAsync(requestMessage);

                    response.EnsureSuccessStatusCode(); // Nếu lỗi sẽ ném exception

                    var responseBodyString = await response.Content.ReadAsStringAsync();
                    var responseBody = JsonConvert.DeserializeObject<TResponse>(responseBodyString);

                    return await Result<TResponse>.SuccessAsync(responseBody);
                }
                catch (HttpRequestException httpEx) // Bắt lỗi HTTP cụ thể hơn
                {
                    return await Result<TResponse>.FailAsync(message: $"Lỗi HTTP: {httpEx.Message}");
                }
                catch (Exception ex) // Bắt các lỗi chung khác (ví dụ: timeout, network...)
                {
                    return await Result<TResponse>.FailAsync($"Lỗi: {ex.Message}");
                }
            }
        }
    }
}
