using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgemployeeGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Department { get; set; }
        public string EmployeePosition { get; set; }
        public string EmployeeStatus { get; set; }
        public string EmployeeUnit { get; set; }
        public DateTime? HireDate { get; set; }
        public string InitialBudgetYear { get; set; }
        public decimal? AnnualSalary { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public Guid BdgcompanyId { get; set; }
    }
}
