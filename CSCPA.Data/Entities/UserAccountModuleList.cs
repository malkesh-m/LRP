using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class UserAccountModuleList
    {
        public Guid UserAccountId { get; set; }
        public Guid ModuleId { get; set; }
    }
}
