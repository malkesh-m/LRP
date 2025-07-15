using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Model
{
    public class LRPTen99BoxNoListModel
    {
        public Guid ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        [Display(Name ="Ten99 Tax Type")]
        public Guid Lrpten99TaxTypeId { get; set; }
        [Display(Name = "Ten99 Box No")]
        public int? Ten99BoxNo { get; set; }
        [Display(Name = "Ten99 Box Text")]
        public string Ten99BoxText { get; set; }
        public decimal? Dolramnt { get; set; }
        public string Description { get; set; }
    }
    public class LRPTen99BoxNoAddEditModel
    {
        public Guid? ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid Lrpten99TaxTypeId { get; set; }
        public int? Ten99BoxNo { get; set; }
        public string Ten99BoxText { get; set; }
        public decimal? Dolramnt { get; set; }
        public string Description { get; set; }
    }
}
