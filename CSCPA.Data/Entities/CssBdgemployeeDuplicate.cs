using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssBdgemployeeDuplicate
    {
        public Guid? BdgemployeeId { get; set; }
        public string Employeename { get; set; }
        public string Deptname { get; set; }
        public int? Count1 { get; set; }
        public Guid BdgdepartmentId { get; set; }
    }
}
