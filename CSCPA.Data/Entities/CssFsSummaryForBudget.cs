using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssFsSummaryForBudget
    {
        public int? Month { get; set; }
        public string Fiscyr { get; set; }
        public string Acct { get; set; }
        public int? Period { get; set; }
        public string NameBdgreportgroupid { get; set; }
        public double? Amount { get; set; }
        public Guid BdgreportGroupId { get; set; }
        public Guid BdgreportGroupBdgglaccountMappingid { get; set; }
        public string NAmeBdgreportGroupBdgglaccountMappingid { get; set; }
        public string Cpnyid { get; set; }
        public Guid BdgdepartmentId { get; set; }
        public Guid? BdgaccountGroupId { get; set; }
    }
}
