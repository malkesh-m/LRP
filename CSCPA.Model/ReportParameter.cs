using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Model
{
    public class ReportParameter
    {
        public string TableName { get; set; }
        public string ReportName { get; set; }
        public string ParameterName { get; set; }
        public string ParameterDefaultValue { get; set; }
        public string ParameterType { get; set; }
        public string DropdownText { get; set; }
        public string DropDownValue { get; set; }
    }
}
