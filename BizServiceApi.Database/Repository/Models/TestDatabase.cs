using System;
using System.Collections.Generic;

namespace BizServiceApi.Database.Repository.Models
{
    public partial class TestDatabase
    {
        public string? KeyField { get; set; }
        public string? Sender { get; set; }
        public string? Receiver { get; set; }
        public string? Testdata { get; set; }
    }
}
