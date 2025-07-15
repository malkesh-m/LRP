using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class YearSetup
    {
        public YearSetup()
        {
            BdgbudgetInfos = new HashSet<BdgbudgetInfo>();
            BdgdepartmentHistoricData = new HashSet<BdgdepartmentHistoricDatum>();
            BudgetAmountTemps = new HashSet<BudgetAmountTemp>();
            GltransactionLines = new HashSet<GltransactionLine>();
            InverseCopyYearSetup = new HashSet<YearSetup>();
            InversePreviousYearSetup = new HashSet<YearSetup>();
            LrpglyearCodes = new HashSet<LrpglyearCode>();
            YearSetupBdgaccountGroupFactors = new HashSet<YearSetupBdgaccountGroupFactor>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string YearCode { get; set; }
        public Guid? PreviousYearSetupId { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public Guid YearStatusId { get; set; }
        public Guid? CopyYearSetupId { get; set; }
        public Guid? BdgbudgetCopyOptionId { get; set; }
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
        public Guid? TwoMoreYearsSetupId { get; set; }
        public Guid? NextyearSetupId { get; set; }
        public Guid? MonthId { get; set; }
        public bool? Softlock { get; set; }

        public virtual BdgbudgetCopyOption BdgbudgetCopyOption { get; set; }
        public virtual YearSetup CopyYearSetup { get; set; }
        public virtual YearSetup PreviousYearSetup { get; set; }
        public virtual YearStatus YearStatus { get; set; }
        public virtual ICollection<BdgbudgetInfo> BdgbudgetInfos { get; set; }
        public virtual ICollection<BdgdepartmentHistoricDatum> BdgdepartmentHistoricData { get; set; }
        public virtual ICollection<BudgetAmountTemp> BudgetAmountTemps { get; set; }
        public virtual ICollection<GltransactionLine> GltransactionLines { get; set; }
        public virtual ICollection<YearSetup> InverseCopyYearSetup { get; set; }
        public virtual ICollection<YearSetup> InversePreviousYearSetup { get; set; }
        public virtual ICollection<LrpglyearCode> LrpglyearCodes { get; set; }
        public virtual ICollection<YearSetupBdgaccountGroupFactor> YearSetupBdgaccountGroupFactors { get; set; }
    }
}
