using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class ProcterQty
    {
        public int Id { get; set; }
        public string Barcode { get; set; } = null!;
        public int QtyMultiplier { get; set; }
    }
}
