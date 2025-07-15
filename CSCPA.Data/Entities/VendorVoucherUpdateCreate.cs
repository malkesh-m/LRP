using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class VendorVoucherUpdateCreate
    {
        public Guid VendorId { get; set; }
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string VoucherNo { get; set; }
        public Guid? DocumentTypeId { get; set; }
        public Guid? VoucherStatusId { get; set; }
        public decimal? Ten99amnt { get; set; }
        public string Ten99type { get; set; }
        public string Ten99boxnumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string DocumentNo { get; set; }
        public string OriginalNo { get; set; }
        public decimal? DocumentAmount { get; set; }
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
        public string Status { get; set; }
    }
}
