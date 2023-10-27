using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class DanoneTaxBarcodeLookup
    {
        public string Barcode { get; set; } = null!;
        public string NewBarcode { get; set; } = null!;
        public string UnitsPer { get; set; } = null!;
    }
}
