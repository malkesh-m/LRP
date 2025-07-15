using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class UserAccountBdgdepartmentGrid
    {
        public Guid ObjectUid { get; set; }
        public Guid UserAccountId { get; set; }
        public string Department { get; set; }
        public bool AllowSubmit { get; set; }
        public bool AllowApprove { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public string Number { get; set; }
    }
}
