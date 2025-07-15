using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CsBdgbudgetinfoDetailMonthlyProof
    {
        public decimal? Budgetamount { get; set; }
        public decimal? Monthamount { get; set; }
        public Guid BdgbudgetInfoid { get; set; }
        public Guid Objectuid { get; set; }
    }
}
