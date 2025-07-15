using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrpglyearCode
    {
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid YearSetupId { get; set; }
        public Guid LrpcodeId { get; set; }
        public Guid? LrpreportId { get; set; }
        public decimal ItemizedAmount { get; set; }
        public decimal NonItemizedAmount { get; set; }
        public decimal TotalAmount { get; set; }
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

        public virtual Lrpcode Lrpcode { get; set; }
        public virtual Lrpreport Lrpreport { get; set; }
        public virtual YearSetup YearSetup { get; set; }
    }
}
