using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgaccountGroupSubGroupSubGroupSubGroup
    {
        public BdgaccountGroupSubGroupSubGroupSubGroup()
        {
            BdgbudgetInfoDetails = new HashSet<BdgbudgetInfoDetail>();
            BdgreportGroupBdgglaccountMappings = new HashSet<BdgreportGroupBdgglaccountMapping>();
            BudgetAmountTemps = new HashSet<BudgetAmountTemp>();
            FecdistributionDetails = new HashSet<FecdistributionDetail>();
            InverseParentBdgaccountGroupSubGroupSubGroupSubGroup = new HashSet<BdgaccountGroupSubGroupSubGroupSubGroup>();
        }

        public Guid BdgaccountGroupSubGroupSubGroupId { get; set; }
        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string AccountCode { get; set; }
        public Guid? ParentBdgaccountGroupSubGroupSubGroupSubGroupId { get; set; }
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

        public virtual BdgaccountGroupSubGroupSubGroup BdgaccountGroupSubGroupSubGroup { get; set; }
        public virtual BdgaccountGroupSubGroupSubGroupSubGroup ParentBdgaccountGroupSubGroupSubGroupSubGroup { get; set; }
        public virtual ICollection<BdgbudgetInfoDetail> BdgbudgetInfoDetails { get; set; }
        public virtual ICollection<BdgreportGroupBdgglaccountMapping> BdgreportGroupBdgglaccountMappings { get; set; }
        public virtual ICollection<BudgetAmountTemp> BudgetAmountTemps { get; set; }
        public virtual ICollection<FecdistributionDetail> FecdistributionDetails { get; set; }
        public virtual ICollection<BdgaccountGroupSubGroupSubGroupSubGroup> InverseParentBdgaccountGroupSubGroupSubGroupSubGroup { get; set; }
    }
}
