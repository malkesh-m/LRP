using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CsActualsPerMonthPerAcct
    {
        public double? Amount { get; set; }
        public string Acct { get; set; }
        public int? Month1 { get; set; }
        public string Date1 { get; set; }
    }
}
