using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrpgltransactionsGridDum
    {
        public int Recordid { get; set; }
        public Guid Objectuid { get; set; }
        public string AcctNoFull { get; set; }
        public string AcctDescription { get; set; }
        public string BatchNo { get; set; }
        public string FiscalYearEnded { get; set; }
        public decimal? Amount { get; set; }
        public string VendorNo { get; set; }
        public string JeNo { get; set; }
        public string DocNumber { get; set; }
        public string AuditNo { get; set; }
        public string Fund { get; set; }
        public string Main { get; set; }
        public string Employee { get; set; }
        public string Dept { get; set; }
        public string Project { get; set; }
        public DateTime? GlpostingDate { get; set; }
        public string TransDescription { get; set; }
        public string Lm2description { get; set; }
        public DateTime? Checkdate { get; set; }
        public string Checkno { get; set; }
        public string Company { get; set; }
        public Guid? Lrpcompanyid { get; set; }
        public string LineDescription { get; set; }
        public string AccountGroup { get; set; }
        public string Fsdepartment { get; set; }
        public string SubGroup { get; set; }
        public string SubSubGroup { get; set; }
        public string SubSubSubGroup { get; set; }
        public string VendorName { get; set; }
        public string GrantNo { get; set; }
    }
}
