using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgdepartmentGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string DepartmentGroup { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public Guid BdgcompanyId { get; set; }
    }
}
