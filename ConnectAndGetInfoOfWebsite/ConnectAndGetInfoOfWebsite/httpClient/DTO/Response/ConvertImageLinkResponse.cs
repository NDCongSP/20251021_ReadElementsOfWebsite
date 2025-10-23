using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAndGetInfoOfWebsite.httpClient.DTO.Response
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class InfoConvertImageLinkResponse
    {
        public string original { get; set; }
        public string transformed { get; set; }
        public string failure_reason { get; set; }
    }

    public class ConvertImageLinkResponse
    {
        public string code { get; set; }
        public string msg { get; set; }
        public InfoConvertImageLinkResponse info { get; set; }
        public object bbl { get; set; }
    }
}
