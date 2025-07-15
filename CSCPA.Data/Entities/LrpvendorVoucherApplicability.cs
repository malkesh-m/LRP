using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrpvendorVoucherApplicability
    {
        public Guid LrpvendorVoucherId { get; set; }
        public Guid ObjectUid { get; set; }
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

        public virtual LrpdocumentType LrpdocumentType { get; set; }
        public virtual LrpvendorVoucher LrpvendorVoucher { get; set; }
    }
}
