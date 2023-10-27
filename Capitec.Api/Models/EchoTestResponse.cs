
namespace Capitec.Api.Models
{
    public class EchoTestResponse
    {
        public string? echoData { get; set; }
        public string messageID { get; set; }
        public string responseCode { get; set; }
        public string responseText { get; set; }
       
        public string? structuredData { get; set; }

        public string transmissionDateTime { get; set; }



    }
}
