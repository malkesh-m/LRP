using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class GltransactionlineAddView
    {
        public double? Amount { get; set; }
        public string FinalId { get; set; }
        public string Lm2Code { get; set; }
        public string Checkno { get; set; }
        public DateTime? Checkdate { get; set; }
        public string Jrnltype { get; set; }
        public string Fiscyr { get; set; }
        public Guid? LrpcompanyId { get; set; }
        public string Cpnyid { get; set; }
    }
}
