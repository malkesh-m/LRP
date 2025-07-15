using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgdepartmentBdgaccountGroupGrid
    {
        public Guid ObjectUid { get; set; }
        public string AccountGroup { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public Guid BdgdepartmentId { get; set; }
    }
}
