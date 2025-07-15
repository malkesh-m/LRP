using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class DynamicCodeGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string Args1 { get; set; }
        public string Args2 { get; set; }
        public string Args3 { get; set; }
        public string Args4 { get; set; }
        public string Args5 { get; set; }
        public string ArgsName1 { get; set; }
        public string ArgsName2 { get; set; }
        public string ArgsName3 { get; set; }
        public string ArgsName4 { get; set; }
        public string ArgsName5 { get; set; }
        public string Language { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
