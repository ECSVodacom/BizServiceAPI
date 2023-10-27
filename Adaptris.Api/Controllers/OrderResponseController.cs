
using Adaptris.Api.Models;
using Adaptris.Api.Repository;
using AdaptrisApi;
using BizServiceApi.Database.Repository;
using BizServiceApi.Database.Repository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using System.Xml;
using System.Xml.Serialization;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Adaptris.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderResponseController : ControllerBase
    {
        private readonly DbContextOptions<TransformationDbContext> _context;

        private readonly IConfiguration _configuration;
        private string _orderNumber;

        public OrderResponseController(IConfiguration configuration, DbContextOptions<TransformationDbContext> context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost(Name = "OrderResponse")]
        [Consumes("application/xml")]
        public ActionResult Get(Ordresp ordresp)
        {
            var header = ordresp.Ordrsp.Header;

            var orderNumber = header.MessageHeader.OrderDetails.CustomerOrderNumber;
            var confirmationCode = header.MessageHeader.OrderDetails.ConfirmationCode;
            var deliveryPoint = header.MessageHeader.CustomerLocation.CustomerDeliveryPoint;
            var orderResponseOrderNumber = header.MessageHeader.RspDetails.ResponseDocNumber;
            var reasonCode = header.MessageHeader.OrderDetails.orderResponseReasonCode;

            var gateway = new Gateway(_context);
            AdaptrisOrderHeader? existingOrder;

            _orderNumber = orderNumber;

            try
            {
                existingOrder = gateway.GetOrder(orderNumber, header.Sender, header.Receiver, deliveryPoint);
            }
            catch (Exception exception)
            {
                return BadRequest($"There was a problem connecting to the database {exception.Message}");
            }

            if (existingOrder == null)
            {
                return BadRequest($"Order {orderNumber} for the order response {orderResponseOrderNumber} could not found.");
            }
            if (existingOrder.AdaptrisOrderLines.Count == 0)
            {
                return BadRequest($"Order {orderNumber} found, but has no line items.");
            }

            var incomingLineItems = ordresp.Ordrsp.Header.MessageHeader.OrderLineDetails?.LineDetail;
            List<LineDetail> lineDetails = BuildOrderResponseLineItems(incomingLineItems, confirmationCode, existingOrder, reasonCode);
            ordresp.Ordrsp.Header.MessageHeader.OrderLineDetails = new OrderLineDetails { LineDetail = lineDetails };

            string xml = OrdrespToXml(ordresp);

            PostData postData = new(orderNumber, orderResponseOrderNumber, header.Sender, header.Receiver);

            gateway.UpdateOrder(existingOrder, orderResponseOrderNumber);

            return SendToBiz(xml, postData);
        }

        private ActionResult SendToBiz(string xmlRequest, PostData postData)
        {
            var bizLinkEndPoint = _configuration.GetValue<string>("Settings:BizLinkEndPoint");

            var client = new HttpClient();

            var postResult = client.PostAsync($"{bizLinkEndPoint}?from={postData.SenderGln}&to={postData.ReceiverGln}&filename=Response_{postData.OriginalOrderNumber}_{postData.OrderResponseOrderNumber}.xml",
               new StringContent(xmlRequest, Encoding.UTF8, "application/xml")).Result;

            postResult.EnsureSuccessStatusCode();
            var stream = postResult.Content.ReadAsStringAsync().Result;

            return Ok(stream);

        }

        private static List<LineDetail> BuildOrderResponseLineItems(List<LineDetail>? incomingLineItems, string confirmationCode, AdaptrisOrderHeader? existingOrder, string reasonCode)
        {
            var lineDetails = new List<LineDetail>();
            
            if (existingOrder == null) return lineDetails;

            foreach (AdaptrisOrderLine? ol in existingOrder.AdaptrisOrderLines)
            {
                if (/*confirmationCode.ToUpper() == Status.Modified &&*/ incomingLineItems != null)
                {
                    LineDetail? incomingLineItem = incomingLineItems.FirstOrDefault(
                        i => i.ProductDetails?.ConsumerUnitEan.TrimStart('0') == ol.Barcode.TrimStart('0'));

                    if (incomingLineItem != null)
                    {
                        if (incomingLineItem.ProductDetails == null)
                        {
                            incomingLineItem.ProductDetails = new() { StatusCode = confirmationCode };
                        }
                        else if (incomingLineItem.ProductDetails.StatusCode == string.Empty)
                        {
                            incomingLineItem.ProductDetails.StatusCode = confirmationCode;
                        }

                        lineDetails.Add(incomingLineItem);

                        continue;
                    }
                }

                lineDetails.Add(new LineDetail
                {
                    LineCounter = ol.LineNumber,
                    ProductDetails = new ProductDetails
                    {
                        ConsumerUnitEan = ol.Barcode,
                        OrderUnitEan = string.Empty,
                        SupplierProductCode = ol.ProductCode,
                        CustomerProductCode = ol.ProductCode,
                        SupplierProductDescription = ol.Description,
                        CustomerProductDescription = ol.Description,
                        StatusCode = confirmationCode.ToUpper() == Status.Modified ? Status.Accepted : confirmationCode,
                        ReasonCode = confirmationCode.ToUpper() == Status.Rejected ? reasonCode : ""
                    },
                    OrdQuantityDetails = new OrdQuantityDetails
                    {
                        NumberOfOrderUnits = confirmationCode.ToUpper() == Status.Rejected ? "0" : ol.Qty.ToString(),
                        OUnitOfMeasure = string.Empty
                    },
                    DelQuantityDetails = new DelQuantityDetails
                    {
                        NumberOfDeliveryUnits = confirmationCode.ToUpper() == Status.Rejected ? "0" : ol.Qty.ToString(),
                    },
                    CostDetails = new CostDetails
                    {
                        CostPriceExcludingVat = ol.ItemPrice == null ? string.Empty : ol.ItemPrice.ToString(),
                        CostUnitOfMeasure = string.Empty,
                        VatPercentage = string.Empty
                    },
                    LineCostExcludingVat = ol.LineCost == null ? string.Empty : ol.LineCost.ToString(),
                    LineCostIncludingVat = string.Empty,
                    TotalVat = string.Empty,
                    LineNarratives = new() { LineNarrativeText = string.Empty }
                });
            }

            return lineDetails;

        }

        private static string OrdrespToXml(Ordresp ordresp)
        {
            XmlWriterSettings settings = new()
            {
                OmitXmlDeclaration = true,
                Encoding = Encoding.UTF8,
            };

            var xns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new(typeof(Ordresp));

            string xml = string.Empty;

            using (StringWriter? stringWriter = new())
            {
                using XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings);
                serializer.Serialize(xmlWriter, ordresp, xns);
                xml = stringWriter.ToString();
            }

            return xml;
        }
    }

    internal class PostData
    {
        public PostData(string originalOrderNumber, string orderResponseOrderNumber, string senderGln, string receiverGln)
        {
            OriginalOrderNumber = originalOrderNumber;
            OrderResponseOrderNumber = orderResponseOrderNumber;
            SenderGln = senderGln;
            ReceiverGln = receiverGln;
        }

        public string OriginalOrderNumber { get; set; }
        public string OrderResponseOrderNumber { get; set; }
        public string SenderGln { get; set; }
        public string ReceiverGln { get; set; }
    }
}
