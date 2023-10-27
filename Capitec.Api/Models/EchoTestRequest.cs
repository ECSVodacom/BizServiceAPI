

using Newtonsoft.Json;

namespace Capitec.Api.Models
{
    public class EchoTestRequest
    {
        public string? echoData { get; set; }
        public string messageID { get; set; }
        public SecurityData securityData { get; set; }

     
        public string? structuredData { get; set; }
        public DateTime transmissionDateTime { get; set; }

    }
}
