using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class MonthGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public int? EffectiveMonths { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
