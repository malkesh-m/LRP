using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class BdgreportGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string Bdgcompany { get; set; }
        public string ReportFile { get; set; }
        public string ServerName { get; set; }
        public string Dbname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public Guid BdgcompanyId { get; set; }
        public bool ShowInCrystalViewer { get; set; }
        public string NameAlias { get; set; }
        public string Display { get; set; }
    }
}
