using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssGltransactionLine
    {
        public string CheckNumber { get; set; }
        public decimal? Totalamount { get; set; }
        public string Code { get; set; }
        public Guid Glyearcodeid { get; set; }
    }
}
