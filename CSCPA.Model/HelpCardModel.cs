using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Model
{
    public class HelpCardAddEditModel
    {
        public Guid? ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string Description { get; set; }
    }
    public class HelpCardListModel
    {
        public Guid ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string Description { get; set; }
    }
}
