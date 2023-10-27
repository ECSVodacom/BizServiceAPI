using BizServiceApi.Database.Repository;
using Capitec.Api.Models;
using Capitec.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Capitec.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NrtController : ControllerBase
    {
        private readonly DbContextOptions<TransformationDbContext> _context;

        private readonly IConfiguration _configuration;

        public NrtController(IConfiguration configuration, DbContextOptions<TransformationDbContext> context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost(Name = "NRT/adviseTransaction")]
        public NearRealTimeResponse adviseTransaction(NearRealTimeRequest request)
        {
            var gateway = new Gateway(_context);
            //gateway.AddUser("vodacom11084", "sJ1^pD3)rG2^lB1&bB7$");

            var transmissionDateTime = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            var response = new NearRealTimeResponse
            {
                messageID = request.messageID,
                transmissionDateTime = transmissionDateTime,
                responseCode = "APPROVED",
                responseText = "Payment Advised"
            };

            var login = request.securityData.login;
            var authenticated = gateway.Authenticate(login.loginID, login.password);
            if (authenticated == false)
            {
                response.responseCode = "INVALID_AUTHENTICATION";
                response.responseText = "Invalid login details.";
                return response;
            }

            var responeXml = new NearRealTimeXmlResponse
            {
                Sender = "CapitecNRT",
                MessageId = request.messageID,
                AccountNumber = request.accountNumber,
                TransmissionDateTime = transmissionDateTime,
                Amount = request?.amount,
                TenderType = request?.tenderType ?? string.Empty,
                NetworkTransactionId = request?.networkTransactionID ?? string.Empty
            };

            var result = "Success";

            var transactionId = 0;
            DateTime? sentToBiz = null;

            try
            {
                transactionId = gateway.SaveTransaction(request);

                var bizLinkEndPoint = _configuration.GetValue<string>("Settings:BizLinkEndPoint");
                var client = new HttpClient();

                var xmlRequest = NearRealTimeToXml(responeXml);

                var responseResult = client.PostAsync(bizLinkEndPoint, new StringContent(xmlRequest, Encoding.UTF8, "application/xml")).Result;

                if (responseResult.IsSuccessStatusCode)
                {
                    sentToBiz = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
                response.responseCode = "TIMEOUT";
            }
            finally
            {
                gateway.UpdateTransaction(transactionId, sentToBiz, result);
            }


            return response;
        }

        [HttpPost(Name = "NRT/echoTest")]
        public EchoTestResponse echoTest(EchoTestRequest request)
        {


            var gateway = new Gateway(_context);
            var transmissionDateTime = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");

            var echoTestResponse = new EchoTestResponse
            {
                messageID = request.messageID,
                responseCode = "APPROVED",
                responseText = "Echo Test Successful",
                transmissionDateTime = transmissionDateTime,
            };

            if (request?.echoData != null) echoTestResponse.echoData = request.echoData;
            if (request?.structuredData != null) echoTestResponse.structuredData = request.structuredData;

            var login = request?.securityData.login;
            var authenticated = gateway.Authenticate(login.loginID, login.password);
            if (authenticated == false)
            {
                echoTestResponse.responseCode = "INVALID_AUTHENTICATION";
                echoTestResponse.responseText = "Invalid login details.";
                return echoTestResponse;
            }

            return echoTestResponse;
        }


        private static string NearRealTimeToXml(NearRealTimeXmlResponse nearRealTimeXmlResponse)
        {
            XmlWriterSettings settings = new()
            {
                OmitXmlDeclaration = true
            };

            var xns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new(typeof(NearRealTimeXmlResponse));

            string xml = string.Empty;

            using (StringWriter? stringWriter = new())
            {
                using XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings);
                serializer.Serialize(xmlWriter, nearRealTimeXmlResponse, xns);
                xml = stringWriter.ToString();
            }

            return xml;
        }
    }


}
