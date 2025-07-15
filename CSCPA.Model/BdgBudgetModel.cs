using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Model
{
    public class BdgBudgetAddEditModel
    {
        public Guid? ObjectUID { get; set; }
        public decimal? YtdactualAmount { get; set; }
        public decimal? YtdprojectedAmount { get; set; }
        public decimal? PybudgetAmount { get; set; }
     /*   public Guid BdgcompanyId { get; set; }
        public Guid BdgaccountGroupId { get; set; }*/
        public Guid BdgdepartmentId { get; set; }
        public Guid YearSetupId { get; set; }
        public string AccountName { get; set; }
        public string AccountCode { get; set; }
    }
    public class BdgBudgetListModel
    {
        public Guid ObjectUID { get; set; }
        public string YearSetup { get; set; }
        public string Department { get; set; }
        public string AccountGroup { get; set; }
        public decimal? YtdactualAmount { get; set; }
        public decimal? YtdprojectedAmount { get; set; }
        public decimal? PybudgetAmount { get; set; }
        public decimal? CybudgetAmount { get; set; }
        public decimal? NybudgetAmount { get; set; }
        public decimal? DollarIncrease { get; set; }
        public decimal? PercentIncrease { get; set; }
        public bool Override { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public Guid BdgcompanyId { get; set; }
        public Guid BdgaccountGroupId { get; set; }
        public Guid BdgdepartmentId { get; set; }
        public Guid YearSetupId { get; set; }
        public int SortOrder { get; set; }
        public int Statusvalue { get; set; }
        public string AccountName { get; set; }
        public string Number { get; set; }
        public string AccountCode { get; set; }
        public string OrderNew { get; set; }
        public string Main { get; set; }
    }
}
