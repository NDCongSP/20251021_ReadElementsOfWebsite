using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAndGetInfoOfWebsite.httpClient.DTO.Response
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class PublishOrUpdateResponse
    {
        public string code { get; set; }
        public string msg { get; set; }
        public Info info { get; set; }
        public object bbl { get; set; }
        public string traceId { get; set; }
    }

    public class Extra
    {
    }

    public class Info
    {
        public bool success { get; set; }
        public string spu_name { get; set; }
        public List<SkcList> skc_list { get; set; }
        public string version { get; set; }
        public object pre_valid_result { get; set; }
        public object mcc_valid_result { get; set; }
        public Extra extra { get; set; }
    }

    public class SkcList
    {
        public string skc_name { get; set; }
        public List<SkuList> sku_list { get; set; }
    }

    public class SkuList
    {
        public string sku_code { get; set; }
        public string supplier_sku { get; set; }
    }
}
