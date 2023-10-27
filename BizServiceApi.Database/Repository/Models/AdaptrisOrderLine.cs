using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class AdaptrisOrderLine
    {
        public int Id { get; set; }
        public int OrderHeaderId { get; set; }
        public string? OrderNumber { get; set; }
        public int LineNumber { get; set; }
        public string Barcode { get; set; } = null!;
        public string ProductCode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Qty { get; set; }
        public decimal? ItemPrice { get; set; }
        public decimal? LineCost { get; set; }
        public string? Status { get; set; }

        public virtual AdaptrisOrderHeader OrderHeader { get; set; } 
    }
}
