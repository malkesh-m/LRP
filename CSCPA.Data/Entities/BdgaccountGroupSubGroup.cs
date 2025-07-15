using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgaccountGroupSubGroup
    {
        public BdgaccountGroupSubGroup()
        {
            BdgaccountGroupSubGroupSubGroups = new HashSet<BdgaccountGroupSubGroupSubGroup>();
            BdgbudgetInfoDetailDetailDetailDetailDetails = new HashSet<BdgbudgetInfoDetailDetailDetailDetailDetail>();
            BdgbudgetInfoDetailDetailDetailDetails = new HashSet<BdgbudgetInfoDetailDetailDetailDetail>();
            BdgbudgetInfoDetailDetailDetails = new HashSet<BdgbudgetInfoDetailDetailDetail>();
            BdgbudgetInfoDetailDetails = new HashSet<BdgbudgetInfoDetailDetail>();
            BdgbudgetInfoDetails = new HashSet<BdgbudgetInfoDetail>();
            BdgglaccountMappings = new HashSet<BdgglaccountMapping>();
            BdgreportGroupBdgglaccountMappings = new HashSet<BdgreportGroupBdgglaccountMapping>();
            BudgetAmountTemps = new HashSet<BudgetAmountTemp>();
            FecdistributionDetails = new HashSet<FecdistributionDetail>();
            InverseParentBdgaccountGroupSubGroup = new HashSet<BdgaccountGroupSubGroup>();
        }

        public Guid BdgaccountGroupId { get; set; }
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string AccountCode { get; set; }
        public Guid? ParentBdgaccountGroupSubGroupId { get; set; }
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

        public virtual BdgaccountGroup BdgaccountGroup { get; set; }
        public virtual BdgaccountGroupSubGroup ParentBdgaccountGroupSubGroup { get; set; }
        public virtual ICollection<BdgaccountGroupSubGroupSubGroup> BdgaccountGroupSubGroupSubGroups { get; set; }
        public virtual ICollection<BdgbudgetInfoDetailDetailDetailDetailDetail> BdgbudgetInfoDetailDetailDetailDetailDetails { get; set; }
        public virtual ICollection<BdgbudgetInfoDetailDetailDetailDetail> BdgbudgetInfoDetailDetailDetailDetails { get; set; }
        public virtual ICollection<BdgbudgetInfoDetailDetailDetail> BdgbudgetInfoDetailDetailDetails { get; set; }
        public virtual ICollection<BdgbudgetInfoDetailDetail> BdgbudgetInfoDetailDetails { get; set; }
        public virtual ICollection<BdgbudgetInfoDetail> BdgbudgetInfoDetails { get; set; }
        public virtual ICollection<BdgglaccountMapping> BdgglaccountMappings { get; set; }
        public virtual ICollection<BdgreportGroupBdgglaccountMapping> BdgreportGroupBdgglaccountMappings { get; set; }
        public virtual ICollection<BudgetAmountTemp> BudgetAmountTemps { get; set; }
        public virtual ICollection<FecdistributionDetail> FecdistributionDetails { get; set; }
        public virtual ICollection<BdgaccountGroupSubGroup> InverseParentBdgaccountGroupSubGroup { get; set; }
    }
}
