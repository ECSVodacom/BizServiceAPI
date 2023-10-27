using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class ThreeGmobileStoreList
    {
        public string StoreEan { get; set; } = null!;
        public string StoreName { get; set; } = null!;
        public string Region { get; set; } = null!;
    }
}
