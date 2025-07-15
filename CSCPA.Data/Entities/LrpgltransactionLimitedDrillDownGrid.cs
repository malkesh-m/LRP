using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrpgltransactionLimitedDrillDownGrid
    {
        public Guid ObjectUid { get; set; }
        public string AcctNoFull { get; set; }
        public string AcctDescription { get; set; }
        public string BatchNo { get; set; }
        public double? Amount { get; set; }
        public string VendorNo { get; set; }
        public string JeNo { get; set; }
        public string DocNumber { get; set; }
        public DateTime? GlpostingDate { get; set; }
        public string TransDescription { get; set; }
        public DateTime? Checkdate { get; set; }
        public string Checkno { get; set; }
        public string Company { get; set; }
        public string LineDescription { get; set; }
        public string AccountGroup { get; set; }
        public string Fsdepartment { get; set; }
        public string VendorName { get; set; }
        public Guid Yearsetupid { get; set; }
        public Guid? Bdgdepartmentid2 { get; set; }
        public Guid? Lrpcompanyid { get; set; }
    }
}
