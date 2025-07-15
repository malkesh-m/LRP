using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Lrpcode
    {
        public Lrpcode()
        {
            FecdistributionDetails = new HashSet<FecdistributionDetail>();
            LrpcodeLrpreports = new HashSet<LrpcodeLrpreport>();
            LrpglyearCodes = new HashSet<LrpglyearCode>();
            LrplineSummaries = new HashSet<LrplineSummary>();
            LrptimeEntries = new HashSet<LrptimeEntry>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
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

        public virtual ICollection<FecdistributionDetail> FecdistributionDetails { get; set; }
        public virtual ICollection<LrpcodeLrpreport> LrpcodeLrpreports { get; set; }
        public virtual ICollection<LrpglyearCode> LrpglyearCodes { get; set; }
        public virtual ICollection<LrplineSummary> LrplineSummaries { get; set; }
        public virtual ICollection<LrptimeEntry> LrptimeEntries { get; set; }
    }
}
