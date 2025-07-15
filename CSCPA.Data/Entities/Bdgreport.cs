using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Bdgreport
    {
        public Bdgreport()
        {
            BdgreportGroupBdgreports = new HashSet<BdgreportGroupBdgreport>();
            BdgreportParameters = new HashSet<BdgreportParameter>();
            UserAccountBdgreports = new HashSet<UserAccountBdgreport>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid BdgcompanyId { get; set; }
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
        public bool ShowInCrystalViewer { get; set; }
        public string Source { get; set; }
        public Guid? PortalId { get; set; }
        public bool? IsAdmin { get; set; }

        public virtual Bdgcompany Bdgcompany { get; set; }
        public virtual Portal Portal { get; set; }
        public virtual ICollection<BdgreportGroupBdgreport> BdgreportGroupBdgreports { get; set; }
        public virtual ICollection<BdgreportParameter> BdgreportParameters { get; set; }
        public virtual ICollection<UserAccountBdgreport> UserAccountBdgreports { get; set; }
    }
}
