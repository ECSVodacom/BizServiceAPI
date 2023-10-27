using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class DanoneOrdBarcode
    {
        public string CurrentBarcode { get; set; } = null!;
        public string NewBarcode { get; set; } = null!;
    }
}
