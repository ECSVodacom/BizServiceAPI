using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class MondelezProdatBarcode
    {
        public string Barcode { get; set; } = null!;
        public string ItemCode { get; set; } = null!;
        public string? Qty { get; set; }
    }
}
