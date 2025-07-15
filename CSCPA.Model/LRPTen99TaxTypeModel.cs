using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CSCPA.Model
{
    public class LRPTen99TaxTypeListModel
    {
        public Guid ObjectUID { get; set; }
        public string Display { get; set; }

        public string Name { get; set; }
        public string NameAlias { get; set; }

        [Display(Name = "Value_GP")]
        public string ValueGp { get; set; }

        [Display(Name = "Description_BP")]
        public string DescriptionBp { get; set; }
        public string Description { get; set; }
    }
    public class LRPTen99TaxTypeAddEditModel
    {
        public Guid? ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }

        [Display(Name = "Value GP")]
        public string ValueGp { get; set; }
        
        [Display(Name = "Description BP")]
        public string DescriptionBp { get; set; }
        public string Description { get; set; }
    }
}