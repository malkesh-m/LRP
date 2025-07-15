using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrpvendorVoucherDistributionGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid LrpvendorVoucherId { get; set; }
        public string AccountNo { get; set; }
        public string AccountDescription { get; set; }
        public decimal? DebitAmount { get; set; }
        public decimal? CreditAmount { get; set; }
        public string CssLinkLines { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
