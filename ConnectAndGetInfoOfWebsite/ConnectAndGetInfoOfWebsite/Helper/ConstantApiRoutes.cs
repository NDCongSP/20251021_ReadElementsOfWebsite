using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAndGetInfoOfWebsite
{
    public static class ConstantApiRoutes
    {
        public static string DoimainApi = "https://openapi.sheincorp.com";  
        public static class Product
        {
            public const string ProductPublishOrEdit = "/open-api/goods/product/publishOrEdit";
            public const string ConvertImageLink = "/open-api/goods/transform-pic";
        }
    }
}
