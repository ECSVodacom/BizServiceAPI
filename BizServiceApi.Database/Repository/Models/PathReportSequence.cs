using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class PathReportSequence
    {
        public int Id { get; set; }
        public string SenderEan { get; set; } = null!;
        public string ReceiverEan { get; set; } = null!;
        public int SequenceNumber { get; set; }
    }
}
