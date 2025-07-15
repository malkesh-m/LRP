using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrpgltransactionLimitedGrid
    {
        public int RecordId { get; set; }
        public Guid ObjectUid { get; set; }
        public string AcctNoFull { get; set; }
        public string AcctDescription { get; set; }
        public string BatchNo { get; set; }
        public string FiscalYearEnded { get; set; }
        public double? Amount { get; set; }
        public string VendorNo { get; set; }
        public string JeNo { get; set; }
        public string DocNumber { get; set; }
        public string AuditNo { get; set; }
        public string Fund { get; set; }
        public string CostCenter { get; set; }
        public string Main { get; set; }
        public DateTime? GlpostingDate { get; set; }
        public string TransDescription { get; set; }
        public DateTime? Checkdate { get; set; }
        public string Checkno { get; set; }
        public string Company { get; set; }
        public Guid? LrpcompanyId { get; set; }
        public string LineDescription { get; set; }
        public string AccountGroup { get; set; }
        public string Fsdepartment { get; set; }
        public string VendorName { get; set; }
        public string GrantNo { get; set; }
        public Guid? BdgdepartmentId2 { get; set; }
        public Guid YearSetupId { get; set; }
    }
}
