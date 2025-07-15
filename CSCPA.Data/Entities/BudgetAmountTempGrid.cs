using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BudgetAmountTempGrid
    {
        public Guid ObjectUid { get; set; }
        public string Department { get; set; }
        public string AccountGroup { get; set; }
        public string SubGroup { get; set; }
        public string SubSubGroup { get; set; }
        public string SubSubSubGroup { get; set; }
        public decimal? Amount { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public string Year { get; set; }
    }
}
