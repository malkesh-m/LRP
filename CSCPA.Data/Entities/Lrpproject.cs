using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Lrpproject
    {
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectCode { get; set; }
        public Guid? LrpprojectTypeId { get; set; }
        public Guid? Lrplm2receiptCodeId { get; set; }
        public Guid? Lrplm2disbursementCodeId { get; set; }
        public Guid? LrpcostCenterId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ScheduledEndDate { get; set; }
        public string GrantNo { get; set; }
        public DateTime? InactiveDate { get; set; }
        public string InactiveComment { get; set; }
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

        public virtual LrpcostCenter LrpcostCenter { get; set; }
        public virtual Lrplm2disbursementCode Lrplm2disbursementCode { get; set; }
        public virtual Lrplm2receiptCode Lrplm2receiptCode { get; set; }
        public virtual LrpprojectType LrpprojectType { get; set; }
    }
}
