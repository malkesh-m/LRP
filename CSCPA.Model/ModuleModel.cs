using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Model
{
    public class ModuleAddEditModel
    {
        public Guid? ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid? HelpCardId { get; set; }
        public bool IsPrimaryEntity { get; set; }
        public string Description { get; set; }
    }
    public class ModuleListModel
    {
        public Guid ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid? HelpCardId { get; set; }
        public bool IsPrimaryEntity { get; set; }
        public string Description { get; set; }
    }
}
