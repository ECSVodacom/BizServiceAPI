using System.Xml.Serialization;
// XmlSerializer serializer = new XmlSerializer(typeof(Ordresp));
// using (StringReader reader = new StringReader(xml))
// {
//    var test = (Ordresp)serializer.Deserialize(reader);
//}

[XmlRoot(ElementName = "Ordresp")]
public class Ordresp
{
    [XmlElement(ElementName = "FileInformation")]
    public FileInformation? FileInformation { get; set; }

    [XmlElement(ElementName = "Ordrsp")]
    public Ordrsp Ordrsp { get; set; }
}

[XmlRoot(ElementName = "FileInformation")]
public class FileInformation
{
    public string FileType { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "Ordrsp")]
public class Ordrsp
{

    [XmlElement(ElementName = "Header")]
    public Header Header { get; set; }
}


[XmlRoot(ElementName = "Header")]
public class Header
{

    [XmlElement(ElementName = "Sender")]
    public string Sender { get; set; }

    [XmlElement(ElementName = "Receiver")]
    public string Receiver { get; set; }

    [XmlElement(ElementName = "InterchangeNo")]
    public string InterchangeNo { get; set; }

    [XmlElement(ElementName = "Date")]
    public DateTime Date { get; set; }

    [XmlElement(ElementName = "MessageHeader")]
    public MessageHeader MessageHeader { get; set; }

}

[XmlRoot(ElementName = "MessageHeader")]
public class MessageHeader
{
    [XmlElement(ElementName = "MessageReferenceNr")]
    public string MessageReferenceNr { get; set; } = string.Empty;

    [XmlElement(ElementName = "MessageType")]
    public string MessageType { get; set; } = string.Empty;

    [XmlElement(ElementName = "MessageVersionNumber")]
    public string MessageVersionNumber { get; set; } = string.Empty;

    [XmlElement(ElementName = "MessageReleaseNumber")]
    public string MessageReleaseNumber { get; set; } = string.Empty;

    [XmlElement(ElementName = "ControllingAgency")]
    public string ControllingAgency { get; set; } = string.Empty;

    [XmlElement(ElementName = "AssociationAssignedCode")]
    public string AssociationAssignedCode { get; set; } = string.Empty;

    [XmlElement(ElementName = "SupplierDetails")]
    public SupplierDetails? SupplierDetails { get; set; }

    [XmlElement(ElementName = "CustomerLocation")]
    public CustomerLocation CustomerLocation { get; set; }

    [XmlElement(ElementName = "RspDetails")]
    public RspDetails RspDetails { get; set; }

    [XmlElement(ElementName = "OrderDetails")]
    public OrderDetails OrderDetails { get; set; }

    [XmlElement(ElementName = "DeliveryInstructions")]
    public DeliveryInstructions? DeliveryInstructions { get; set; }


    [XmlElement(ElementName = "OrderLineDetails")]
    public OrderLineDetails? OrderLineDetails { get; set; }
}

[XmlRoot(ElementName = "SupplierDetails")]
public class SupplierDetails
{

    [XmlElement(ElementName = "SupplierOrderPoint")]
    public string SupplierOrderPoint { get; set; } = string.Empty;

    [XmlElement(ElementName = "SupplierAccountingPoint")]
    public string SupplierAccountingPoint { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "CustomerLocation")]
public class CustomerLocation
{

    [XmlElement(ElementName = "CustomerDeliveryPoint")]
    public string CustomerDeliveryPoint { get; set; }

    [XmlElement(ElementName = "CustomerOrderPoint")]
    public string CustomerOrderPoint { get; set; } = string.Empty;

    [XmlElement(ElementName = "CustomerAlternateInvoicePoint")]
    public string CustomerAlternateInvoicePoint { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "RspDetails")]
public class RspDetails
{

    [XmlElement(ElementName = "ResponseDocNumber")]
    public string ResponseDocNumber { get; set; }

    [XmlElement(ElementName = "ResponseDate")]
    public string ResponseDate { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "OrderDetails")]
public class OrderDetails
{
    [XmlElement(ElementName = "CustomerOrderNumber")]
    public string CustomerOrderNumber { get; set; }

    [XmlElement(ElementName = "OrderDate")]
    public string OrderDate { get; set; } = string.Empty;

    [XmlElement(ElementName = "ConfirmationCode")]
    public string ConfirmationCode { get; set; }

    [XmlElement(ElementName = "orderResponseReasonCode")]
    public string orderResponseReasonCode { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "DeliveryInstructions")]
public class DeliveryInstructions
{
    [XmlElement(ElementName = "DeliveryWarehouse")]
    public string DeliveryWarehouse { get; set; } = string.Empty;

    [XmlElement(ElementName = "RequestedDeliveryDate")]
    public string RequestedDeliveryDate { get; set; } = string.Empty;

    [XmlElement(ElementName = "ExpectedDeliveryDate")]
    public string ExpectedDeliveryDate { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "ProductDetails")]
public class ProductDetails
{
    [XmlElement(ElementName = "ConsumerUnitEan")]
    public string ConsumerUnitEan { get; set; }

    [XmlElement(ElementName = "CustomerProductCode")]
    public string CustomerProductCode { get; set; } = string.Empty;

    [XmlElement(ElementName = "CustomerProductDescription")]
    public string CustomerProductDescription { get; set; } = string.Empty;

    [XmlElement(ElementName = "OrderUnitEan")]
    public string OrderUnitEan { get; set; } = string.Empty;

    [XmlElement(ElementName = "SupplierProductCode")]
    public string SupplierProductCode { get; set; } = string.Empty;

    [XmlElement(ElementName = "SupplierProductDescription")]
    public string SupplierProductDescription { get; set; } = string.Empty;

    [XmlElement(ElementName = "StatusCode")]
    public string StatusCode { get; set; } = string.Empty;

    [XmlElement(ElementName = "ReasonCode")]
    public string ReasonCode { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "OrdQuantityDetails")]
public class OrdQuantityDetails
{

    [XmlElement(ElementName = "NumberOfOrderUnits")]
    public string NumberOfOrderUnits { get; set; } = string.Empty;

    [XmlElement(ElementName = "OUnitOfMeasure")]
    public string OUnitOfMeasure { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "DelQuantityDetails")]
public class DelQuantityDetails
{

    [XmlElement(ElementName = "NumberOfDeliveryUnits")]
    public string NumberOfDeliveryUnits { get; set; } = string.Empty;
}

[XmlRoot(ElementName = "CostDetails")]
public class CostDetails
{
    [XmlElement(ElementName = "CostPriceExcludingVat")]
    public string CostPriceExcludingVat { get; set; } = string.Empty;

    [XmlElement(ElementName = "CostUnitOfMeasure")]
    public string CostUnitOfMeasure { get; set; } = string.Empty;

    [XmlElement(ElementName = "VatPercentage")]
    public string VatPercentage { get; set; } = string.Empty;

   
}

[XmlRoot(ElementName = "LineDetail")]
public class LineDetail
{
    [XmlElement(ElementName = "LineCounter")]
    public int LineCounter { get; set; }

    [XmlElement(ElementName = "ProductDetails")]
    public ProductDetails? ProductDetails { get; set; }

    [XmlElement(ElementName = "OrdQuantityDetails")]
    public OrdQuantityDetails? OrdQuantityDetails { get; set; }

    [XmlElement(ElementName = "DelQuantityDetails")]
    public DelQuantityDetails? DelQuantityDetails { get; set; }

    [XmlElement(ElementName = "CostDetails")]
    public CostDetails? CostDetails { get; set; }

    [XmlElement(ElementName = "LineCostExcludingVat")]
    public string LineCostExcludingVat { get; set; } = string.Empty;

    [XmlElement(ElementName = "LineCostIncludingVat")]
    public string LineCostIncludingVat { get; set; } = string.Empty;

    [XmlElement(ElementName = "TotalVat")]
    public string TotalVat { get; set; } = string.Empty;

    [XmlElement(ElementName = "LineNarratives")]
    public LineNarratives? LineNarratives { get; set; }
}

[XmlRoot(ElementName = "OrderLineDetails")]
public class OrderLineDetails
{

    [XmlElement(ElementName = "LineDetail")]
    public List<LineDetail>? LineDetail { get; set; }
}

[XmlRoot(ElementName = "LineNarratives")]
public class LineNarratives
{

    [XmlElement(ElementName = "LineNarrativeText")]
    public string LineNarrativeText { get; set; } = string.Empty;
}