using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class GltransactionLineSummaryView
    {
        public string Code { get; set; }
        public string Year { get; set; }
        public string Id { get; set; }
        public decimal? ItemizedAmount { get; set; }
        public decimal? NonItemizedAmount { get; set; }
    }
}
