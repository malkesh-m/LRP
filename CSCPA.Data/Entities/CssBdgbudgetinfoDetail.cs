using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssBdgbudgetinfoDetail
    {
        public Guid ObjectUid { get; set; }
        public Guid BdgdepartmentId { get; set; }
        public Guid Yearsetupid { get; set; }
        public Guid? BdgaccountGroupId { get; set; }
    }
}
