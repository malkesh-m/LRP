using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Model
{
    public class YearDepartmentModel
    {
        public Guid Year { get; set; }
        public List<Guid> Departments { get; set; }
    }
}
