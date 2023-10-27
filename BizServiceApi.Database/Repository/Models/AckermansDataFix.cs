using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class AckermansDataFix
    {
        public string? Line { get; set; }
        public string? OrderNumber { get; set; }
        public string? Sop { get; set; }
        public string? Clo { get; set; }
        public byte? LineNumber { get; set; }
        public string? ProductCode { get; set; }
        public string? Barcode { get; set; }
        public string? Qty { get; set; }
        public double? CostPrice { get; set; }
        public double? LineCostExcluding { get; set; }
        public double? Rsp { get; set; }
    }
}
