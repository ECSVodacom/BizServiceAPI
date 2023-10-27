namespace Capitec.Api.Models
{
    public class NearRealTimeRequest
    {
        public string accountNumber { get; set; }

        public decimal? amount { get; set; }
        public string? echoData { get; set; }
        public string? issuerTransactionID { get; set; }

        public string messageID { get; set; }
        public string networkTransactionID { get; set; }
        public bool repeatIndicator { get; set; }

        public NetworkData? networkData { get; set; }
        public SecurityData securityData { get; set; }
        public string? structuredData { get; set; }

        public string tenderType { get; set; }
        public DateTime transmissionDateTime { get; set; }
    }
}
