using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssDistinctMaskingAccountTemp
    {
        public string Company { get; set; }
        public string AccountNo { get; set; }
        public string MaskedAccountNo { get; set; }
        public string Bdgdepartment { get; set; }
        public string BdgaccountGroup { get; set; }
        public string BdgaccountGroupSubGroup { get; set; }
        public string BdgaccountGroupSubGroupSubGroup { get; set; }
        public string BdgaccountGroupSubGroupSubGroupSubGroup { get; set; }
        public Guid? Bdgdepartmentid { get; set; }
        public Guid? BdgaccountGroupid { get; set; }
    }
}
