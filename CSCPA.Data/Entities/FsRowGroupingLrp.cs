using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FsRowGroupingLrp
    {
        public int? Accatnum { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int DexRowId { get; set; }
        public string Companycode { get; set; }
        public string Status { get; set; }
        public string Department { get; set; }
        public string LookupValue { get; set; }
        public string RowNoFrx { get; set; }
    }
}
