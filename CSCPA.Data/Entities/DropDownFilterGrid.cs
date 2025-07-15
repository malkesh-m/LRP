using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class DropDownFilterGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string FilterColumn { get; set; }
        public string ComparisonOperator { get; set; }
        public string FilterValueLocation { get; set; }
        public string FilterValue { get; set; }
        public string DropDownNames { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public string PageLinks { get; set; }
        public string PageTableNames { get; set; }
        public string DropDownTableNames { get; set; }
    }
}
