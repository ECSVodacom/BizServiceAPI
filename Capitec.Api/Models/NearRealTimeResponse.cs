namespace Capitec.Api.Models
{
    public class NearRealTimeResponse
    {
        public string messageID { get; set; }
        public string transmissionDateTime { get; set; }
        public string responseCode { get; set; }
        public string responseText { get; set; }
    }
}
