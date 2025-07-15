using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Model
{
    public class MenuAddEditModel
    {
        public Guid? ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
    }
    public class MenuListModel
    {
        public Guid ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
    }
}
