using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class View2
    {
        public int? Total { get; set; }
        public Guid BdgdepartmentId { get; set; }
        public Guid? BdgaccountGroupId { get; set; }
        public Guid? BdgaccountGroupSubGroupId { get; set; }
        public Guid? BdgaccountGroupSubGroupSubGroupId { get; set; }
        public Guid? BdgaccountGroupSubGroupSubGroupSubGroupId { get; set; }
        public string MaskedAccountNo { get; set; }
        public Guid ObjectUid { get; set; }
    }
}
