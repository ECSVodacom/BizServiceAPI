using System.Xml.Serialization;

namespace Capitec.Api.Models
{

    [XmlRoot(ElementName = "CapitecNRT")]
    public class NearRealTimeXmlResponse
    {
        [XmlElement(ElementName = "Sender")]
        public string Sender { get; set; }

        [XmlElement(ElementName = "MessageID")]
        public string MessageId { get; set; }

        [XmlElement(ElementName = "accountNumber")]
        public string AccountNumber { get; set; }

        public string TransmissionDateTime { get; set; }

        [XmlElement(ElementName = "amount")]
        public decimal? Amount { get; set; }

        [XmlElement(ElementName = "tenderType")]
        public string TenderType { get; set; }

        [XmlElement(ElementName = "networkTransactionID")]
        public string NetworkTransactionId { get; set; }
    }
}
