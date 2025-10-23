using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAndGetInfoOfWebsite.httpClient.DTO.Request
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class PublishOrUpdateRequest
    {
        public object spuPic { get; set; }
        public string brand_code { get; set; }
        public int category_id { get; set; }
        public int product_type_id { get; set; }
        public List<MultiLanguageDescList> multi_language_desc_list { get; set; }
        public List<MultiLanguageNameList> multi_language_name_list { get; set; }
        public object part_info_list { get; set; }
        public List<ProductAttributeList> product_attribute_list { get; set; }
        public List<SiteList> site_list { get; set; }
        public List<object> size_attribute_list { get; set; }
        public List<SkcList> skc_list { get; set; }
        public List<object> sale_attribute_sort_list { get; set; }
        public string source_system { get; set; }
        public object spu_code { get; set; }
        public string spu_name { get; set; }
        public int suit_flag { get; set; }
        public string supplier_code { get; set; }
        public object image_info { get; set; }
        public bool is_spu_pic { get; set; }
        public object sample_info { get; set; }
    }

    public class ImageInfo
    {
        public List<ImageInfoList> image_info_list { get; set; }
    }

    public class ImageInfoList
    {
        public int image_sort { get; set; }
        public int image_type { get; set; }
        public string image_url { get; set; }
    }

    public class MultiLanguageDescList
    {
        public string language { get; set; }
        public string name { get; set; }
    }

    public class MultiLanguageNameList
    {
        public string language { get; set; }
        public string name { get; set; }
    }

    public class PriceInfoList
    {
        public double base_price { get; set; }
        public string currency { get; set; }
        public string sub_site { get; set; }
    }

    public class ProductAttributeList
    {
        public int attribute_id { get; set; }
        public int attribute_type { get; set; }
        public int attribute_value_id { get; set; }
        public string attribute_extra_value { get; set; }
    }

    public class SaleAttribute
    {
        public int attribute_id { get; set; }
        public int attribute_value_id { get; set; }
    }

    public class SiteList
    {
        public string main_site { get; set; }
        public List<string> sub_site_list { get; set; }
    }

    public class SkcList
    {
        public ImageInfo image_info { get; set; }
        public SaleAttribute sale_attribute { get; set; }
        public object skc_title { get; set; }
        public List<SkuList> sku_list { get; set; }
        public string supplier_code { get; set; }
        public string shelf_require { get; set; }
        public string shelf_way { get; set; }
        public object hope_on_sale_date { get; set; }
    }

    public class SkuList
    {
        public string height { get; set; }
        public string length { get; set; }
        public string width { get; set; }
        public string weight { get; set; }
        public int mall_state { get; set; }
        public List<object> sale_attribute_list { get; set; }
        public string sku_code { get; set; }
        public List<PriceInfoList> price_info_list { get; set; }
        public List<StockInfoList> stock_info_list { get; set; }
        public int stop_purchase { get; set; }
        public string supplier_sku { get; set; }
        public string competing_product_link { get; set; }
        public object image_info { get; set; }
    }

    public class StockInfoList
    {
        public int inventory_num { get; set; }
    }
}
