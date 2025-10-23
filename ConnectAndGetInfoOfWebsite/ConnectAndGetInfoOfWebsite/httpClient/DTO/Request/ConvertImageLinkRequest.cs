using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAndGetInfoOfWebsite.httpClient.DTO.Request
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ConvertImageLinkRequest
    {
        public int image_type { get; set; }
        public string original_url { get; set; }
    }
}
