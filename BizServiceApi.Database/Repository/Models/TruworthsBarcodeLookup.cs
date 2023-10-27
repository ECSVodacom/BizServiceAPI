using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class TruworthsBarcodeLookup
    {
        public int Id { get; set; }
        public string? Supplier { get; set; }
        public string? Barcode { get; set; }
    }
}
