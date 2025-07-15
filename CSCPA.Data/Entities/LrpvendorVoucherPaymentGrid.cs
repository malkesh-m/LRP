using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrpvendorVoucherPaymentGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid LrpvendorId { get; set; }
        public string VoucherNo { get; set; }
        public string LrpdocumentType { get; set; }
        public DateTime? CheckDate { get; set; }
        public string CheckNo { get; set; }
        public decimal? CheckAmount { get; set; }
        public decimal? CurrentBalanceAmount { get; set; }
        public string Pono { get; set; }
        public string TrxDescription { get; set; }
        public bool Voided { get; set; }
        public bool Hold { get; set; }
        public DateTime? GlpostingDate { get; set; }
        public DateTime? Iddate { get; set; }
        public string Company { get; set; }
        public string CssLink { get; set; }
        public string CssLinkLines { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
