using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class MiaStoreLookup
    {
        public string StoreGln { get; set; } = null!;
        public string StoreCode { get; set; } = null!;
        public string StoreName { get; set; } = null!;
        public DateTime? UpdatedDate { get; set; }
    }
}
