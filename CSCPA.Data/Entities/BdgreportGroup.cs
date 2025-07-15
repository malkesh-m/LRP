using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgreportGroup
    {
        public BdgreportGroup()
        {
            BdgreportGroupBdgglaccountMappings = new HashSet<BdgreportGroupBdgglaccountMapping>();
            BdgreportGroupBdgreports = new HashSet<BdgreportGroupBdgreport>();
            BdgreportGroupDuplicateMaskings = new HashSet<BdgreportGroupDuplicateMasking>();
            BdgreportGroupMissingMaskings = new HashSet<BdgreportGroupMissingMasking>();
            Feccompanies = new HashSet<Feccompany>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid BdgcompanyId { get; set; }
        public bool ShowAccountsWithZeroAmount { get; set; }
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

        public virtual Bdgcompany Bdgcompany { get; set; }
        public virtual ICollection<BdgreportGroupBdgglaccountMapping> BdgreportGroupBdgglaccountMappings { get; set; }
        public virtual ICollection<BdgreportGroupBdgreport> BdgreportGroupBdgreports { get; set; }
        public virtual ICollection<BdgreportGroupDuplicateMasking> BdgreportGroupDuplicateMaskings { get; set; }
        public virtual ICollection<BdgreportGroupMissingMasking> BdgreportGroupMissingMaskings { get; set; }
        public virtual ICollection<Feccompany> Feccompanies { get; set; }
    }
}
