using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class TempEmployee
    {
        public Guid? Employeeid { get; set; }
        public string DeptMoveFrom { get; set; }
        public string DeptMoveTo { get; set; }
        public string Year { get; set; }
        public string Accountgroup { get; set; }
        public string Accountgroup1 { get; set; }
        public string Accountgroup2 { get; set; }
        public string Accountgroup3 { get; set; }
        public bool? Processed { get; set; }
        public int Recordid { get; set; }
    }
}
