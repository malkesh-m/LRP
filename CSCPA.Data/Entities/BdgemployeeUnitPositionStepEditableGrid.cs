using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgemployeeUnitPositionStepEditableGrid
    {
        public string Unit { get; set; }
        public string Position { get; set; }
        public string Step { get; set; }
        public Guid ObjectUid { get; set; }
        public decimal? PreviousYearSalary { get; set; }
        public decimal? CurrentYearSalary { get; set; }
        public Guid BdgcompanyId { get; set; }
    }
}
