using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CsBudgetallHeader
    {
        public string Departmentname { get; set; }
        public string Number { get; set; }
        public string Acctgroup { get; set; }
        public string AccountCode { get; set; }
        public int Recordid { get; set; }
        public decimal? BudgetAmount { get; set; }
        public decimal? ProposedBudgetAmount { get; set; }
        public decimal? EstimatedBudgetAmount { get; set; }
        public string Budgetname { get; set; }
        public string Yearname { get; set; }
        public string Grouptype { get; set; }
        public string Deptnumber { get; set; }
        public decimal? YtdactualAmount { get; set; }
    }
}
