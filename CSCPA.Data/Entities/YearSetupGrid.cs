using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class YearSetupGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string YearStatus { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public string YearCode { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
    }
}
