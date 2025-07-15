using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Model
{
    public class RoleModuleAddEditModel
    {
        public Guid RoleId { get; set; }
        public Guid? ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid ModuleId { get; set; }
        public string Description { get; set; }
        public bool CustomA { get; set; }
        public bool CustomB { get; set; }
        public bool CustomC { get; set; }
        public bool CustomD { get; set; }
    }
    public class RoleModuleListModel
    {
        public Guid RoleId { get; set; }
        public Guid ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid ModuleId { get; set; }
        public string Description { get; set; }
    }
}
