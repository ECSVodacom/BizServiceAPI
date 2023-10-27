using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class VodapayTransaction
    {
        public int Id { get; set; }
        public string? Sender { get; set; }
        public string? OriginatorRequestNumber { get; set; }
        public string? Bank { get; set; }
        public string? TransactionRecipient { get; set; }
        public string? TransactionAmount { get; set; }
    }
}
