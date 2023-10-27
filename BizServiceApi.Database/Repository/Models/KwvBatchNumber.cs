using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class KwvBatchNumber
    {
        public int Id { get; set; }
        public int? BatchCounter { get; set; }
        public int? Year { get; set; }
    }
}
