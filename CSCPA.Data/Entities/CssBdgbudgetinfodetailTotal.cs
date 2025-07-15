using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssBdgbudgetinfodetailTotal
    {
        public Guid BdgbudgetInfoid { get; set; }
        public decimal? Nextyearbudgetamount { get; set; }
        public decimal? Budgetamount { get; set; }
        public decimal? Currentyearbudgetamount { get; set; }
    }
}
