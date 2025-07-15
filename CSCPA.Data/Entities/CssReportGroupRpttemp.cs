using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssReportGroupRpttemp
    {
        public string Acct { get; set; }
        public decimal? BudgetAmount { get; set; }
        public decimal? Amount { get; set; }
        public decimal? LastYearAmount { get; set; }
        public Guid? BdgdepartmentId { get; set; }
        public Guid? BdgaccountGroupId { get; set; }
        public Guid? BdgaccountGroupSubGroupId { get; set; }
        public Guid? BdgaccountGroupSubGroupSubGroupId { get; set; }
        public Guid? BdgaccountGroupSubGroupSubGroupSubGroupId { get; set; }
        public string Department { get; set; }
        public string AccountGroup { get; set; }
        public string AccountGroupSubGroup { get; set; }
        public string AccountGroupSubGroupSubGroup { get; set; }
        public string AccountGroupSubGroupSubGroupSubGroup { get; set; }
        public int? SortOrder { get; set; }
    }
}
