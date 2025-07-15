using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssBdgreportGroupBdgglaccountMappingSummary
    {
        public int? Month { get; set; }
        public int? Period { get; set; }
        public double? Amount { get; set; }
        public string Fiscyr { get; set; }
        public string Acct { get; set; }
        public string Cpnyid { get; set; }
    }
}
