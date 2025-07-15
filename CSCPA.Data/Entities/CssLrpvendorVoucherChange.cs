using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssLrpvendorVoucherChange
    {
        public Guid? LrpvendorVoucherId { get; set; }
        public string VendorNo { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string Companyname { get; set; }
    }
}
