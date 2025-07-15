using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssLrpgltransactionActualForBudget
    {
        public string BdgaccountGroup { get; set; }
        public string Bdgdepartment { get; set; }
        public double? Amount { get; set; }
        public string Fiscyr { get; set; }
    }
}
