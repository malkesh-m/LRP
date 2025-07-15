using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CSCPA.Model
{
    public class LRPCostCenterAddEditModel
    {
        public Guid? ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid? Lrplm2receiptCodeId { get; set; }
        public Guid? Lrplm2disbursementCodeId { get; set; }
        public string Description { get; set; }
    }

    public class LRPCostCenterListModel
    {
        public Guid ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        [Display(Name = "LM2 Receipt Code")]
        public Guid? Lrplm2receiptCodeId { get; set; }
        [Display(Name = "LM2 Disbursement Code")]
        public Guid? Lrplm2disbursementCodeId { get; set; }
        public string Description { get; set; }
    }
}
