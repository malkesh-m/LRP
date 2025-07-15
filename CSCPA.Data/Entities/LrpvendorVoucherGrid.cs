using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrpvendorVoucherGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid LrpvendorId { get; set; }
        public string VoucherNo { get; set; }
        public string DocumentType { get; set; }
        public string VoucherStatus { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string DocumentNo { get; set; }
        public decimal? DocumentAmount { get; set; }
        public decimal? Ten99amnt { get; set; }
        public decimal? CurrentBalanceAmount { get; set; }
        public string Pono { get; set; }
        public string TrxDescription { get; set; }
        public bool Voided { get; set; }
        public bool Hold { get; set; }
        public DateTime? Pstgdate { get; set; }
        public DateTime? Iddate { get; set; }
        public string Company { get; set; }
        public string CssLink { get; set; }
        public string CssLinkLines { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
