using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class VodaTradeCusTable
    {
        public int Id { get; set; }
        public string SupplierEan { get; set; } = null!;
        public string SupplierName { get; set; } = null!;
        public string RetailerEan { get; set; } = null!;
        public string? RetailerName { get; set; }
        public int? Active { get; set; }
    }
}
