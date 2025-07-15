using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Lrpreport
    {
        public Lrpreport()
        {
            LrpcodeLrpreports = new HashSet<LrpcodeLrpreport>();
            LrpglyearCodes = new HashSet<LrpglyearCode>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string ReportFile { get; set; }
        public string ServerName { get; set; }
        public string Dbname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
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

        public virtual ICollection<LrpcodeLrpreport> LrpcodeLrpreports { get; set; }
        public virtual ICollection<LrpglyearCode> LrpglyearCodes { get; set; }
    }
}
