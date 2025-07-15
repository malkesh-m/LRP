using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgaccountGroup
    {
        public BdgaccountGroup()
        {
            BdgaccountGroupSubGroups = new HashSet<BdgaccountGroupSubGroup>();
            BdgbudgetInfoDetailDetailDetailDetailDetails = new HashSet<BdgbudgetInfoDetailDetailDetailDetailDetail>();
            BdgbudgetInfoDetailDetailDetailDetails = new HashSet<BdgbudgetInfoDetailDetailDetailDetail>();
            BdgbudgetInfoDetailDetailDetails = new HashSet<BdgbudgetInfoDetailDetailDetail>();
            BdgbudgetInfoDetailDetails = new HashSet<BdgbudgetInfoDetailDetail>();
            BdgbudgetInfoDetails = new HashSet<BdgbudgetInfoDetail>();
            BdgbudgetInfos = new HashSet<BdgbudgetInfo>();
            BdgdepartmentBdgaccountGroups = new HashSet<BdgdepartmentBdgaccountGroup>();
            BdgdepartmentHistoricData = new HashSet<BdgdepartmentHistoricDatum>();
            BdgglaccountMappings = new HashSet<BdgglaccountMapping>();
            BdgreportGroupBdgglaccountMappings = new HashSet<BdgreportGroupBdgglaccountMapping>();
            BudgetAmountTemps = new HashSet<BudgetAmountTemp>();
            FecdistributionDetails = new HashSet<FecdistributionDetail>();
            Fecdistributions = new HashSet<Fecdistribution>();
            InverseParentBdgaccountGroup = new HashSet<BdgaccountGroup>();
            YearSetupBdgaccountGroupFactors = new HashSet<YearSetupBdgaccountGroupFactor>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid? ParentBdgaccountGroupId { get; set; }
        public bool IsGlobal { get; set; }
        public Guid? BdgaccountGroupTypeId { get; set; }
        public string AccountCode { get; set; }
        public decimal ProposedBudgetFactor { get; set; }
        public string EditPageLink { get; set; }
        public string ShowPageLink { get; set; }
        public Guid BdgcompanyId { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool IsDeleted { get; set; }
        public bool? IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int RecordId { get; set; }
        public int? OldRecordId { get; set; }
        public Guid? InstallationUid { get; set; }
        public string ImportedObjectUid { get; set; }
        public string Linenumber { get; set; }
        public decimal? NextyearProposedBudgetFactor { get; set; }
        public decimal? TwoMoreyearsProposedBudgetFactor { get; set; }

        public virtual BdgaccountGroupType BdgaccountGroupType { get; set; }
        public virtual Bdgcompany Bdgcompany { get; set; }
        public virtual BdgaccountGroup ParentBdgaccountGroup { get; set; }
        public virtual ICollection<BdgaccountGroupSubGroup> BdgaccountGroupSubGroups { get; set; }
        public virtual ICollection<BdgbudgetInfoDetailDetailDetailDetailDetail> BdgbudgetInfoDetailDetailDetailDetailDetails { get; set; }
        public virtual ICollection<BdgbudgetInfoDetailDetailDetailDetail> BdgbudgetInfoDetailDetailDetailDetails { get; set; }
        public virtual ICollection<BdgbudgetInfoDetailDetailDetail> BdgbudgetInfoDetailDetailDetails { get; set; }
        public virtual ICollection<BdgbudgetInfoDetailDetail> BdgbudgetInfoDetailDetails { get; set; }
        public virtual ICollection<BdgbudgetInfoDetail> BdgbudgetInfoDetails { get; set; }
        public virtual ICollection<BdgbudgetInfo> BdgbudgetInfos { get; set; }
        public virtual ICollection<BdgdepartmentBdgaccountGroup> BdgdepartmentBdgaccountGroups { get; set; }
        public virtual ICollection<BdgdepartmentHistoricDatum> BdgdepartmentHistoricData { get; set; }
        public virtual ICollection<BdgglaccountMapping> BdgglaccountMappings { get; set; }
        public virtual ICollection<BdgreportGroupBdgglaccountMapping> BdgreportGroupBdgglaccountMappings { get; set; }
        public virtual ICollection<BudgetAmountTemp> BudgetAmountTemps { get; set; }
        public virtual ICollection<FecdistributionDetail> FecdistributionDetails { get; set; }
        public virtual ICollection<Fecdistribution> Fecdistributions { get; set; }
        public virtual ICollection<BdgaccountGroup> InverseParentBdgaccountGroup { get; set; }
        public virtual ICollection<YearSetupBdgaccountGroupFactor> YearSetupBdgaccountGroupFactors { get; set; }
    }
}
