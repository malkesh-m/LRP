using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Bdgdepartment
    {
        public Bdgdepartment()
        {
            BdgbudgetInfos = new HashSet<BdgbudgetInfo>();
            BdgdepartmentBdgaccountGroups = new HashSet<BdgdepartmentBdgaccountGroup>();
            BdgdepartmentHistoricData = new HashSet<BdgdepartmentHistoricDatum>();
            BdgemployeeEmployeeHistories = new HashSet<BdgemployeeEmployeeHistory>();
            Bdgemployees = new HashSet<Bdgemployee>();
            BdgglaccountMappings = new HashSet<BdgglaccountMapping>();
            BdgreportGroupBdgglaccountMappings = new HashSet<BdgreportGroupBdgglaccountMapping>();
            BudgetAmountTemps = new HashSet<BudgetAmountTemp>();
            FecdistributionDetails = new HashSet<FecdistributionDetail>();
            Fecdistributions = new HashSet<Fecdistribution>();
            UserAccountBdgdepartments = new HashSet<UserAccountBdgdepartment>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string Number { get; set; }
        public Guid? BdgdepartmentGroupId { get; set; }
        public Guid BdgcompanyId { get; set; }
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
        public virtual BdgdepartmentGroup BdgdepartmentGroup { get; set; }
        public virtual ICollection<BdgbudgetInfo> BdgbudgetInfos { get; set; }
        public virtual ICollection<BdgdepartmentBdgaccountGroup> BdgdepartmentBdgaccountGroups { get; set; }
        public virtual ICollection<BdgdepartmentHistoricDatum> BdgdepartmentHistoricData { get; set; }
        public virtual ICollection<BdgemployeeEmployeeHistory> BdgemployeeEmployeeHistories { get; set; }
        public virtual ICollection<Bdgemployee> Bdgemployees { get; set; }
        public virtual ICollection<BdgglaccountMapping> BdgglaccountMappings { get; set; }
        public virtual ICollection<BdgreportGroupBdgglaccountMapping> BdgreportGroupBdgglaccountMappings { get; set; }
        public virtual ICollection<BudgetAmountTemp> BudgetAmountTemps { get; set; }
        public virtual ICollection<FecdistributionDetail> FecdistributionDetails { get; set; }
        public virtual ICollection<Fecdistribution> Fecdistributions { get; set; }
        public virtual ICollection<UserAccountBdgdepartment> UserAccountBdgdepartments { get; set; }
    }
}
