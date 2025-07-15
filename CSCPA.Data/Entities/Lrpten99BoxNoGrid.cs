using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Lrpten99BoxNoGrid
    {
        public Guid ObjectUid { get; set; }
        public string _1099TaxType { get; set; }
        public int? _1099BoxNo { get; set; }
        public string _1099BoxText { get; set; }
        public decimal? Dolramnt { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
