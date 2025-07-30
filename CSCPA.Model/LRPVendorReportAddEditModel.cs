using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Model
{
    public class LRPVendorReportAddEditModel
    {
        public Guid ObjectUID { get; set; }
        public string? AddressI_Reporting { get; set; }
        public string? AddressII_Reporting { get; set; }
        public string? AddressIII_Reporting { get; set; }
        public string? City_Reporting { get; set; }
        public string? PostalCode_Reporting { get; set; }
        public Guid? CountryID { get; set; }
        public string CountryName { get; set; }
        public string CountryStateName { get; set; }
        public Guid? Country_StateID { get; set; }
        public string? Userdef1_Reporting { get; set; }
        public string? Userdef2_Reporting { get; set; }
        public string? Description { get; set; }
        public int SortOrder { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public int RecordID { get; set; }
        public int? OldRecordID { get; set; }
        public Guid? InstallationUID { get; set; }
        public string? ImportedObjectUID { get; set; }
    }
}
