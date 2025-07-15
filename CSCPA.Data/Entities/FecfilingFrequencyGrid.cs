using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FecfilingFrequencyGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public Guid FeccompanyId { get; set; }
    }
}
