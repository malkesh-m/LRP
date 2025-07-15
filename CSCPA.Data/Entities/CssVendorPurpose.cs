using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssVendorPurpose
    {
        public Guid ObjectUid { get; set; }
        public string VendorNo { get; set; }
        public string CompanyCode { get; set; }
        public string DolPurpose { get; set; }
        public string PurposeSource { get; set; }
        public string ScheduleNo { get; set; }
        public int DexRowId { get; set; }
    }
}
