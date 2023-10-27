using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class MondelezShopriteLookup
    {
        public string? Barcode { get; set; }
        public string? ProductCode { get; set; }
        public string? CustomerGln { get; set; }
    }
}
