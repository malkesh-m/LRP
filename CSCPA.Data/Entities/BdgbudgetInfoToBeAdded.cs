using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgbudgetInfoToBeAdded
    {
        public Guid YearSetupId { get; set; }
        public Guid BdgdepartmentId { get; set; }
        public Guid BdgaccountGroupId { get; set; }
        public int SortOrder { get; set; }
        public Guid BdgcompanyId { get; set; }
    }
}
