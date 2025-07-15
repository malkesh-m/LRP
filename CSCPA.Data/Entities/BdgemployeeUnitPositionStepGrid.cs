using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgemployeeUnitPositionStepGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid BdgemployeeUnitPositionId { get; set; }
        public string Name { get; set; }
        public decimal? Salary { get; set; }
        public decimal? PreviousYearSalary { get; set; }
        public decimal? CurrentYearSalary { get; set; }
        public string PositionType { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
