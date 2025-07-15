using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class DynamicFieldValueGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid DynamicFieldId { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
