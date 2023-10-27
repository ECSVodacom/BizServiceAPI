using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class MondelezOrderDatum
    {
        public int Id { get; set; }
        public string? Sender { get; set; }
        public string? Receiver { get; set; }
        public string? CustomerOrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? CustomerDeliveryPoint { get; set; }
        public string? VendorCode { get; set; }
    }
}
