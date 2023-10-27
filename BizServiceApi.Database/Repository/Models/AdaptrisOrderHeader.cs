using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class AdaptrisOrderHeader
    {
        public AdaptrisOrderHeader()
        {
            AdaptrisOrderLines = new HashSet<AdaptrisOrderLine>();
        }

        public int Id { get; set; }
        public string OrderNumber { get; set; } = null!;
        public string Sender { get; set; } = null!;
        public string Receiver { get; set; } = null!;
        public string? DeliveryPoint { get; set; }
        public DateTime DateReceived { get; set; }
        public string? Status { get; set; }
        public string? ResponseDocNumber { get; set; }
        public DateTime? ResponseDate { get; set; }

        public virtual ICollection<AdaptrisOrderLine> AdaptrisOrderLines { get; set; }
    }
}
