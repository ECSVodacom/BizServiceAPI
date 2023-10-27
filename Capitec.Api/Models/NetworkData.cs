namespace Capitec.Api.Models
{
    public class NetworkData
    {
        public int? networkId { get; set; }
        public string? networkName { get; set; }
        public posData? posData { get; set; }
    }

    public class posData
    {
        public string? storeID { get; set; }
        public string? terminalID { get; set; }
    }
}
