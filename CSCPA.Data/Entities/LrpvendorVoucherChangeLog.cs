using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrpvendorVoucherChangeLog
    {
        public Guid? LrpvendorVoucherId { get; set; }
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? InvoiceDateOld { get; set; }
        public string TrxDescription { get; set; }
        public string TrxDescriptionOld { get; set; }
        public decimal? Ten99amntold { get; set; }
        public decimal? Ten99amnt { get; set; }
        public string CssLink { get; set; }
        public Guid? Lrpten99BoxNoIdold { get; set; }
        public Guid? Lrpten99BoxNoId { get; set; }
        public Guid? Lrpten99TaxTypeIdold { get; set; }
        public Guid? Lrpten99TaxTypeId { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int RecordId { get; set; }
        public int? OldRecordId { get; set; }
        public Guid? InstallationUid { get; set; }
        public string ImportedObjectUid { get; set; }

        public virtual Lrpten99BoxNo Lrpten99BoxNo { get; set; }
        public virtual Lrpten99TaxType Lrpten99TaxType { get; set; }
        public virtual LrpvendorVoucher LrpvendorVoucher { get; set; }
    }
}
