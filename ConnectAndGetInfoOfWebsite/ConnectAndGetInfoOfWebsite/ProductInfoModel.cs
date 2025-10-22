using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAndGetInfoOfWebsite
{
    public class ProductInfoModel
    {
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public string Net { get; set; } = string.Empty;
        public string ProductImageUrl { get; set; }
        public string ProductCategory1 { get; set; }
        public string ProductCategory2 { get; set; }
        public string Description { get; set; }
        public string ProductUrl { get; set; }
    }
}
