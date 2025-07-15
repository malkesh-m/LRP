using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class EventTriggerGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string DynamicCode { get; set; }
        public int Frequency { get; set; }
        public DateTime? LastRan { get; set; }
        public string LastError { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
