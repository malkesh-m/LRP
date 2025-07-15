using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssApAgingTemp
    {
        public decimal Groupno { get; set; }
        public string VendorName { get; set; }
        public string VendorNo { get; set; }
        public string DocumentNo { get; set; }
        public decimal? DocumentBalance { get; set; }
        public decimal? Appliedamount { get; set; }
        public decimal? DocumentAmount { get; set; }
        public DateTime? Pstgdate { get; set; }
        public DateTime? VendorVoucherApplicabilityDocumentDate { get; set; }
        public string AccountNo { get; set; }
        public string AccountDescription { get; set; }
        public decimal? DebitAmount { get; set; }
        public decimal? CreditAmount { get; set; }
        public bool Voided { get; set; }
        public string DocumentTypeNo { get; set; }
        public string CompanyName { get; set; }
        public string VoucherNo { get; set; }
        public string AppliedToDocumentNo { get; set; }
        public string DocumenttypeName { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string CssLink { get; set; }
        public DateTime? AppliedDate { get; set; }
    }
}
