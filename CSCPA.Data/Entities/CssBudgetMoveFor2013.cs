using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssBudgetMoveFor2013
    {
        public decimal? AnnualSalary { get; set; }
        public int? EffectiveMonths { get; set; }
        public decimal? ProposedBudgetFactor { get; set; }
        public decimal? NextYearProposedBudgetFactor { get; set; }
        public Guid? EffectiveSalaryMonthId { get; set; }
        public decimal? BudgetAmount { get; set; }
        public Guid BdgbudgetInfoId { get; set; }
        public Guid BdgbudgetInfoDetailId { get; set; }
        public string BdgbudgetInfoDetail { get; set; }
        public Guid BdgaccountGroupId { get; set; }
        public string Bdgaccountgroup { get; set; }
        public Guid BdgdepartmentId { get; set; }
        public string Department { get; set; }
        public Guid YearsetupId { get; set; }
        public string Yearsetup { get; set; }
        public Guid BdgemployeeId { get; set; }
        public string Bdgemployee { get; set; }
        public Guid BdgemployeeunitId { get; set; }
        public string BdgemployeeUnit { get; set; }
    }
}
