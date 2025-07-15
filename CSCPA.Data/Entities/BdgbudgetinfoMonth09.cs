using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgbudgetinfoMonth09
    {
        public double? Amount { get; set; }
        public string Bdgaccountgroup { get; set; }
        public string Bdgdepartment { get; set; }
        public Guid? Bdgbudgetinfoid { get; set; }
        public Guid? Bdgaccountgroupid { get; set; }
        public Guid? Bdgdepartmentid { get; set; }
        public Guid? Yearsetupid { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
    }
}
