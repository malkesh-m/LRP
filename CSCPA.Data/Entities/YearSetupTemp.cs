using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class YearSetupTemp
    {
        public Guid Objectuid { get; set; }
        public int Statusvalue { get; set; }
        public DateTime Dateprocess { get; set; }
        public DateTime Dateprocessend { get; set; }
    }
}
