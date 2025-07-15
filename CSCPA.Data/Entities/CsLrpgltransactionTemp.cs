using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CsLrpgltransactionTemp
    {
        public string Acct { get; set; }
        public double? Amount { get; set; }
        public string Bdgdepartmentname { get; set; }
        public string TranDate { get; set; }
        public Guid Bdgdeaprtmentid { get; set; }
        public Guid Bdgaccountgroupid { get; set; }
        public int BdgaccountgroupSortorder { get; set; }
        public string BdgaccountGroup { get; set; }
        public string BdgaccountGroupSubGroup { get; set; }
        public string BdgaccountGroupSubGroupSubGroup { get; set; }
        public string BdgaccountGroupSubGroupSubGroupSubGroup { get; set; }
        public string Cpnyid { get; set; }
        public string Fiscyr { get; set; }
    }
}
