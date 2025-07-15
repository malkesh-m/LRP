using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Model
{
    public class LRPVendorVoucherAddEditModel
    {
        public Guid LrpvendorId { get; set; }
        public Guid? ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string VoucherNo { get; set; }
        public Guid? LrpdocumentTypeId { get; set; }
        public Guid? LrpvoucherStatusId { get; set; }
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
        public string Description { get; set; }
        public Guid? Lrpten99BoxNoId { get; set; }
        public Guid? Lrpten99TaxTypeId { get; set; }

        
    }
    public class LRPVendorVoucherListModel
    {
        public Guid LrpvendorId { get; set; }
        public Guid ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string VoucherNo { get; set; }
        [Display(Name ="Document Type")]
        public Guid? LrpdocumentTypeId { get; set; }
        [Display(Name = "Voucher Status")]
        public Guid? LrpvoucherStatusId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string DocumentNo { get; set; }
        public decimal? DocumentAmount { get; set; }
        public decimal? Ten99amnt { get; set; }
        public decimal? CurrentBalanceAmount { get; set; }
        public string Pono { get; set; }
        [Display(Name = "Trx Description")]
        public string TrxDescription { get; set; }
        public bool Voided { get; set; }
        public bool Hold { get; set; }
        [Display(Name = "GL Posting Date")]
        public DateTime? Pstgdate { get; set; }
        public DateTime? Iddate { get; set; }
        public string Company { get; set; }
        public string CssLink { get; set; }
        public string CssLinkLines { get; set; }
        public string Description { get; set; }
        public Guid? Lrpten99BoxNoId { get; set; }
        public Guid? Lrpten99TaxTypeId { get; set; }
    }
}
