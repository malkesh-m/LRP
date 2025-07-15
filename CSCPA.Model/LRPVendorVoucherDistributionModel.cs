using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Model
{
    public class LRPVendorVoucherDistributionAddEditModel
    {
        public Guid LrpvendorVoucherId { get; set; }
        public Guid? ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string AccountNo { get; set; }
        public string AccountDescription { get; set; }
        public decimal? DebitAmount { get; set; }
        public decimal? CreditAmount { get; set; }
        public string CssLinkLines { get; set; }
        public string Description { get; set; }
    }
    public class LRPVendorVoucherDistributionListModel
    {
        public Guid LrpvendorVoucherId { get; set; }
        public Guid ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string AccountNo { get; set; }
        public string AccountDescription { get; set; }
        public decimal? DebitAmount { get; set; }
        public decimal? CreditAmount { get; set; }
        public string CssLinkLines { get; set; }
        public string Description { get; set; }
    }
}
