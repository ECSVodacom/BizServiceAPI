using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class BarcodeLookupTable
    {
        public int Id { get; set; }
        public string? Customer { get; set; }
        public string IncorrectBarcode { get; set; } = null!;
        public string? IncorrectProductCode { get; set; }
        public string? CorrectBarcode { get; set; }
        public string? CorrectProductCode { get; set; }
        public int? ConversionFactor { get; set; }
    }
}
