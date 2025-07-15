using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Model
{
    public class LRPVendorVoucherApplicabilityAddEditModel
    {
        public Guid LrpvendorVoucherId { get; set; }
        public Guid? ObjectUID { get; set; }
        public decimal Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string AppliedToDocumentNo { get; set; }
        public decimal AppliedAmount { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string VoucherNo { get; set; }
        public Guid? LrpdocumentTypeId { get; set; }
        public string CssLink { get; set; }
        public string Description { get; set; }
    }
    public class LRPVendorVoucherApplicabilityListModel
    {
        [Display(Name = "Lrp Vendor Voucher")]
        public Guid LrpvendorVoucherId { get; set; }
        public Guid ObjectUID { get; set; }
        public decimal Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string AppliedToDocumentNo { get; set; }
        public decimal AppliedAmount { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string VoucherNo { get; set; }
        [Display(Name = "Lrp Document Type")]
        public Guid? LrpdocumentTypeId { get; set; }
        public string CssLink { get; set; }
        public string Description { get; set; }
    }
}
