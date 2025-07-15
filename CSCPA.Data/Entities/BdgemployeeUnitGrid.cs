using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgemployeeUnitGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public decimal? ProposedBudgetFactor { get; set; }
        public string EffectiveSalaryMonth { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public Guid BdgcompanyId { get; set; }
    }
}
