using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgaccountGroupGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string Parent { get; set; }
        public bool IsGlobal { get; set; }
        public string GroupType { get; set; }
        public string AccountCode { get; set; }
        public decimal ProposedBudgetFactor { get; set; }
        public string EditPageLink { get; set; }
        public string ShowPageLink { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public Guid BdgcompanyId { get; set; }
    }
}
