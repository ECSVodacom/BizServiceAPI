using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class CapitecNrt
    {
        public int Id { get; set; }
        public Guid MessageId { get; set; }
        public DateTime Received { get; set; }
        public DateTime? SentToBiz { get; set; }
        public string? Result { get; set; }
        public string? OrignalJson { get; set; }
    }
}
