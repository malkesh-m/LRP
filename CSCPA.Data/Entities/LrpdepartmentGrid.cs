using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrpdepartmentGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string DepartmentNo { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
