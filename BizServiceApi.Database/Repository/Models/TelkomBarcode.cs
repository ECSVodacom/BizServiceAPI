using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class TelkomBarcode
    {
        public string SupplierCode { get; set; } = null!;
        public string Barcode { get; set; } = null!;
    }
}
