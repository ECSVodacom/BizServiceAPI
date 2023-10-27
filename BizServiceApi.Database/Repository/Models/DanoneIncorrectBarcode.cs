using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class DanoneIncorrectBarcode
    {
        public string? Barcode { get; set; }
        public string? BarcodeDescription { get; set; }
    }
}
