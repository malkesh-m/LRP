using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Gridlayout
    {
        public string Id { get; set; }
        public string Layoutname { get; set; }
        public string Userid { get; set; }
        public string Gridid { get; set; }
        public string Layout { get; set; }
        public string Creator { get; set; }
        public bool? Ispublic { get; set; }
    }
}
