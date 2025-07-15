using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Model
{
    public class SelectListModel
    {
        public Guid Value { get; set; }
        public string Text { get; set; }
        public Guid FilterValue { get; set; }
    }
}
