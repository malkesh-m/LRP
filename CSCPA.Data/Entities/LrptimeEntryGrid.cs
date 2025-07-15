using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrptimeEntryGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string Employee { get; set; }
        public string Code { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Percentage { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
