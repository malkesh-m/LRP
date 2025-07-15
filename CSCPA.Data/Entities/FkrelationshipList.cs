using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FkrelationshipList
    {
        public string FkName { get; set; }
        public int ColOrder { get; set; }
        public string FkTable { get; set; }
        public string FkColumn { get; set; }
        public string PkTable { get; set; }
        public string PkColumn { get; set; }
        public string UpdateRule { get; set; }
        public string DeleteRule { get; set; }
    }
}
