using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrpglyearCodeGrid
    {
        public Guid ObjectUid { get; set; }
        public string YearSetup { get; set; }
        public string Code { get; set; }
        public string Report { get; set; }
        public decimal ItemizedAmount { get; set; }
        public decimal NonItemizedAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
