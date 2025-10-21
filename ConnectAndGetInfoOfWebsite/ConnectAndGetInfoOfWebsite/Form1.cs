using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectAndGetInfoOfWebsite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _btnGetInformation.Click += _btnGetInformation_ClickAsync;
        }

        private async void _btnGetInformation_ClickAsync(object sender, EventArgs e)
        {
            string url = _txtProductUrl.Text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Vui lòng nhập URL sản phẩm!");
                return;
            }

            try
            {
                var html = await GetHtmlAsync(url);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                // Các XPath selector đã được cập nhật để khớp với HTML của cosme-de.net

                // 1. Lấy Tên sản phẩm
                // HTML dùng: <h1 class="main_item_name">...</h1>
                string name = doc.DocumentNode.SelectSingleNode("//h1[@class='main_item_name']")
                                ?.InnerText.Trim();

                // 2. Lấy Phân loại (Category)
                // 2a. Lấy text của link 1 trong breadcrumbs
                string categoryPart1 = doc.DocumentNode.SelectSingleNode("//div[@class='item_description']/p[1]/a[1]")
                                        ?.InnerText.Trim();

                // 2b. Lấy text của link 2 trong breadcrumbs
                string categoryPart2 = doc.DocumentNode.SelectSingleNode("//div[@class='item_description']/p[1]/a[2]")
                                        ?.InnerText.Trim();

                string category = "Không tìm thấy";

                if (categoryPart1 != null && categoryPart2 != null)
                {
                    // Giải mã HTML entities
                    categoryPart1 = System.Net.WebUtility.HtmlDecode(categoryPart1); // "ボディケア・香水"
                    categoryPart2 = System.Net.WebUtility.HtmlDecode(categoryPart2); // "女性用香水（レディースフレグランス）"
               
                    category = $"{categoryPart1} > {categoryPart2}";
                }

                // Giải mã các ký tự HTML (ví dụ: &#x5973; -> 女)
                if (category != null)
                {
                    category = System.Net.WebUtility.HtmlDecode(category);
                }


                // 3. Lấy Mô tả (Description)
                // HTML dùng: <div class="item_description">...<p class="text_02"> (nội dung ở đây) </p>...</div>
                // [1] để chọn thẻ <p class="text_02"> đầu tiên
                string descriptionParty1 = doc.DocumentNode.SelectSingleNode("//div[@class='item_description']/p[2]")
                                       ?.InnerText.Trim();
                string descriptionParty2 = doc.DocumentNode.SelectSingleNode("//div[@class='item_description']/p[3]")
                                    ?.InnerText.Trim();
                string descriptionParty3Note = doc.DocumentNode.SelectSingleNode("//div[@class='item_description']/p[5]")
                                    ?.InnerText.Trim();

                if (descriptionParty1 != null)
                {
                    descriptionParty1 = System.Net.WebUtility.HtmlDecode(descriptionParty1);
                }
                if (descriptionParty2 != null)
                {
                    descriptionParty2 = System.Net.WebUtility.HtmlDecode(descriptionParty2);
                }
                if (descriptionParty3Note != null)
                {
                    descriptionParty3Note = System.Net.WebUtility.HtmlDecode(descriptionParty3Note);
                }

                var description = string.IsNullOrEmpty(descriptionParty3Note)
                    ? $"{descriptionParty1}{Environment.NewLine}{descriptionParty2}{Environment.NewLine}"
                    : $"{descriptionParty1}{Environment.NewLine}{descriptionParty2}{Environment.NewLine}Caution: {descriptionParty3Note}"; ;

                // 4. Lấy URL Hình ảnh
                // XPath tìm thẻ <img> dựa trên cấu trúc HTML bạn cung cấp
                var imgNode = doc.DocumentNode.SelectSingleNode("//div[@class='main_img']/div[@class='img']/img");

                // Lấy giá trị của thuộc tính 'src'
                string imageUrl = imgNode?.GetAttributeValue("src", "Không tìm thấy");

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        _txtProductName.Text = name ?? "Không tìm thấy";
                        _txtProductCategory.Text = category ?? "Không tìm thấy";
                        _txtProductDescription.Text = description ?? "Không tìm thấy";
                        _txtProductImageUrl.Text = imageUrl ?? "Không tìm thấy";

                        // CẬP NHẬT PICTUREBOX
                        if (imageUrl != "Không tìm thấy")
                        {
                            _pic.LoadAsync(imageUrl);
                        }
                        else
                        {
                            _pic.Image = null; // Xóa ảnh nếu không tìm thấy
                        }
                    }));
                }
                else
                {
                    _txtProductName.Text = name ?? "Không tìm thấy";
                    _txtProductCategory.Text = category ?? "Không tìm thấy";
                    _txtProductDescription.Text = description ?? "Không tìm thấy";
                    _txtProductImageUrl.Text = imageUrl ?? "Không tìm thấy";

                    // CẬP NHẬT PICTUREBOX
                    if (imageUrl != "Không tìm thấy")
                    {
                        _pic.LoadAsync(imageUrl);
                    }
                    else
                    {
                        _pic.Image = null; // Xóa ảnh nếu không tìm thấy
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }

        private async Task<string> GetHtmlAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                // Thêm User-Agent là quan trọng để giả lập trình duyệt
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
                return await client.GetStringAsync(url);
            }
        }
    }
}
