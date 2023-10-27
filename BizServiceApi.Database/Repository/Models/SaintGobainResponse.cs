using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class SaintGobainResponse
    {
        public string? Id { get; set; }
        public string? OriginalOrder { get; set; }
        public string? ResponseOrder { get; set; }
        public string? Originator { get; set; }
        public string? Recipient { get; set; }
        public string? DeliveryPoint { get; set; }
    }
}
