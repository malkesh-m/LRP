using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class CssBdgemployeeMissing
    {
        public Guid? BdgbudgetinfoDetailid { get; set; }
        public Guid Bdgemployeeid { get; set; }
        public string Name { get; set; }
        public Guid? ObjectUid { get; set; }
        public string Yearsetupid { get; set; }
    }
}
