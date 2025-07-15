using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class DynamicFieldGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid ModuleId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string PossibleValues { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
