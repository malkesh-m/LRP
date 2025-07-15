using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Model
{
    public class BdgreportAddEditModel
    {
        public Guid? ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid BdgcompanyId { get; set; }
        public string ReportFile { get; set; }
        public string ServerName { get; set; }
        public string Dbname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public IFormFile Source { get; set; }
        public Guid? PortalId { get; set; }
        public bool ShowInCrystalViewer { get; set; }
    }
    public class BdgreportListModel
    {
        public Guid ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public Guid BdgcompanyId { get; set; }
        public string ReportFile { get; set; }
        public string ServerName { get; set; }
        public string Dbname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public bool ShowInCrystalViewer { get; set; }
    }
}
