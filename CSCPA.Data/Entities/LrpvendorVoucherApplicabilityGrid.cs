using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrpvendorVoucherApplicabilityGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid LrpvendorVoucherId { get; set; }
        public string AppliedToDocumentNo { get; set; }
        public decimal AppliedAmount { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string VoucherNo { get; set; }
        public string DocumentType { get; set; }
        public string CssLink { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public Guid RelatedVendorVoucherId { get; set; }
    }
}
