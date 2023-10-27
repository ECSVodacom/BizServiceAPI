using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class MondelezProdCodeLookup
    {
        public string? Barcode { get; set; }
        public string? ProductCode { get; set; }
        public string? Qty { get; set; }
    }
}
