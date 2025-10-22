using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectAndGetInfoOfWebsite
{
    public partial class frmImport : Form
    {
        private List<ProductInfoModel> _scrapedProducts = new List<ProductInfoModel>();
        public frmImport()
        {
            InitializeComponent();
            _btnImport.Click += _btnImport_Click;
            _btnExport.Click += _btnExport_Click;
        }

        private void _btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (_scrapedProducts == null || _scrapedProducts.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất. Vui lòng Import trước.");
                    return;
                }

                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel Files|*.xlsx";
                    saveDialog.Title = "Save an Excel File";
                    saveDialog.FileName = $"{DateTime.Now.ToString("yyyyMMddHHmmss")}_ProductInformation.xlsx";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        // 2. Ghi dữ liệu vào file Excel (đã cập nhật)
                        WriteProductsToExcel(saveDialog.FileName, _scrapedProducts);

                        if (File.Exists(saveDialog.FileName))
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                            {
                                FileName = saveDialog.FileName,
                                UseShellExecute = true
                            });
                        }
                        else
                        {
                            MessageBox.Show("File not found: " + saveDialog.FileName);
                        }
                    }
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void _btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Excel File|*.xlsx",
                Title = "Import Excel File Contain Product URL"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                _scrapedProducts.Clear();
                _grv.DataSource = null;

                // 2. Đọc file Excel (đã cập nhật)
                var urls = ReadUrlsFromExcel(ofd.FileName);
                if (urls.Count == 0)
                {
                    MessageBox.Show("N/A URL nào trong file Excel.");
                    return;
                }

                // 3. Lặp qua từng URL và cào dữ liệu
                foreach (var url in urls)
                {
                    if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.Absolute))
                        continue;

                    ProductInfoModel product = await ScrapeProductInfoAsync(url);
                    _scrapedProducts.Add(product);
                }

                // 4. Hiển thị kết quả
                _grv.DataSource = _scrapedProducts;
                MessageBox.Show($"Hoàn tất! Đã lấy thông tin của {_scrapedProducts.Count} sản phẩm.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình import: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Đọc file Excel bằng ClosedXML
        /// </summary>
        private List<string> ReadUrlsFromExcel(string filePath)
        {
            var urls = new List<string>();
            // Mở file Excel
            using (var workbook = new XLWorkbook(filePath))
            {
                // Lấy worksheet đầu tiên
                var worksheet = workbook.Worksheets.FirstOrDefault();
                if (worksheet == null)
                    throw new Exception("File Excel không hợp lệ hoặc không có worksheet.");

                // Lấy tất cả các hàng đang được sử dụng,
                // NHƯNG BỎ QUA HÀNG ĐẦU TIÊN (hàng tiêu đề)
                var rows = worksheet.RowsUsed().Skip(1);

                // Đọc từ hàng 2 trở đi
                foreach (var row in rows)
                {
                    // Lấy giá trị từ ô thứ 5 của hàng (Cột E)
                    string url = row.Cell(5).Value.ToString().Trim();

                    if (!string.IsNullOrEmpty(url))
                    {
                        urls.Add(url);
                    }
                }
            }
            return urls;
        }

        /// <summary>
        /// Ghi danh sách sản phẩm bằng ClosedXML
        /// </summary>
        private void WriteProductsToExcel(string filePath, List<ProductInfoModel> products)
        {
            // Tạo một workbook mới
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Products");

                // 1. Ghi tiêu đề (Hàng 1)
                worksheet.Cell(1, 1).Value = "BrandName";
                worksheet.Cell(1, 2).Value = "ProductName";
                worksheet.Cell(1, 3).Value = "Net";
                worksheet.Cell(1, 4).Value = "ProductImageUrl";
                worksheet.Cell(1, 5).Value = "ProductCategory 1";
                worksheet.Cell(1, 6).Value = "ProductCategory 2";
                worksheet.Cell(1, 7).Value = "Description";
                worksheet.Cell(1, 8).Value = "Product URL";

                // (Tùy chọn) In đậm hàng tiêu đề
                worksheet.Row(1).Style.Font.Bold = true;

                // 1. Chèn dữ liệu (KHÔNG CÓ TIÊU ĐỀ)
                // Dùng InsertData thay vì InsertTable để bỏ hàng tiêu đề
                // Dữ liệu sẽ bắt đầu từ ô A1
                worksheet.Cell(2, 1).InsertTable(products);             

                // 2. (Tùy chọn) Tự động giãn cột
                worksheet.Columns().AdjustToContents();

                // 3. THÊM BORDER (VIỀN)
                // Lấy tất cả các ô vừa chèn dữ liệu
                var dataRange = worksheet.RangeUsed();

                // Đặt viền bên trong và bên ngoài cho tất cả các ô đó
                dataRange.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
                dataRange.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                // 4. Lưu file
                workbook.SaveAs(filePath);
            }
        }

        private async Task<ProductInfoModel> ScrapeProductInfoAsync(string url)
        {
            var productInfo = new ProductInfoModel();
            productInfo.ProductUrl = url;

            try
            {
                var html = await GetHtmlAsync(url);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                // Các XPath selector đã được cập nhật để khớp với HTML của cosme-de.net

                // 0. Lấy Tên Brand
                string brand = doc.DocumentNode.SelectSingleNode("//div[@class='item_brand_name']/span[@class='brand_name']/a")?.InnerText.Trim();
                productInfo.BrandName = System.Net.WebUtility.HtmlDecode(brand ?? "N/A");

                // 1. Lấy Tên sản phẩm
                // HTML dùng: <h1 class="main_item_name">...</h1>
                string name = doc.DocumentNode.SelectSingleNode("//h1[@class='main_item_name']")
                                ?.InnerText.Trim();
                productInfo.ProductName = System.Net.WebUtility.HtmlDecode(name ?? "N/A");
                var nameSplit = productInfo.ProductName.Contains("ml")|| productInfo.ProductName.Contains("g")
                           ? productInfo.ProductName.Split(' ')
                           : null;
                productInfo.Net = nameSplit != null && nameSplit.Length > 1 ? nameSplit[nameSplit.Length - 1]
                            : "N/A";

                // 2. Lấy Phân loại (Category)
                // 2a. Lấy text của link 1 trong breadcrumbs
                string categoryPart1 = doc.DocumentNode.SelectSingleNode("//div[@class='item_description']/p[1]/a[1]")
                                        ?.InnerText.Trim();

                // 2b. Lấy text của link 2 trong breadcrumbs
                string categoryPart2 = doc.DocumentNode.SelectSingleNode("//div[@class='item_description']/p[1]/a[2]")
                                        ?.InnerText.Trim();

                string category = "N/A";

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
                productInfo.ProductCategory1 = categoryPart1;
                productInfo.ProductCategory2 = categoryPart2;


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
                productInfo.Description = System.Net.WebUtility.HtmlDecode(description ?? "N/A");
                // 4. Lấy URL Hình ảnh
                // XPath tìm thẻ <img> dựa trên cấu trúc HTML bạn cung cấp
                var imgNode = doc.DocumentNode.SelectSingleNode("//div[@class='main_img']/div[@class='img']/img");

                // Lấy giá trị của thuộc tính 'src'
                string imageUrl = imgNode?.GetAttributeValue("src", "N/A");
                productInfo.ProductImageUrl = imgNode?.GetAttributeValue("src", "N/A");
            }
            catch (Exception ex)
            {
                productInfo.ProductName = "LỖI KHI CÀO DỮ LIỆU";
                productInfo.ProductImageUrl = url;
                productInfo.Description = ex.Message;
                productInfo.ProductCategory1 = "N/A";
            }

            return productInfo;
        }

        private async Task<string> GetHtmlAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
                return await client.GetStringAsync(url);
            }
        }
    }
}
