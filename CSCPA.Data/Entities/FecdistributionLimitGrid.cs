using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FecdistributionLimitGrid
    {
        public Guid ObjectUid { get; set; }
        public string Year { get; set; }
        public decimal Amount { get; set; }
        public string DistributionLimitType { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
