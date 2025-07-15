using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssDistinctMaskingAccount
    {
        public string BdgdepartmentName { get; set; }
        public string BdgaccountGroupName { get; set; }
        public string BdgaccountGroupSubGroupName { get; set; }
        public string BdgaccountGroupSubGroupSubGroupName { get; set; }
        public string BdgaccountGroupSubGroupSubGroupSubGroupName { get; set; }
        public string AccountNo { get; set; }
        public Guid BdgdepartmentId { get; set; }
        public Guid? BdgaccountGroupId { get; set; }
        public Guid? BdgaccountGroupSubGroupId { get; set; }
        public Guid? BdgaccountGroupSubGroupSubGroupId { get; set; }
        public Guid? BdgaccountGroupSubGroupSubGroupSubGroupId { get; set; }
    }
}
