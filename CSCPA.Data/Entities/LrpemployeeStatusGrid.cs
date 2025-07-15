using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrpemployeeStatusGrid
    {
        public Guid ObjectUid { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public string Name { get; set; }
    }
}
