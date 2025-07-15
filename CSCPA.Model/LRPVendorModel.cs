using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Model
{
    public class LRPVendorAddEditModel
    {
        public Guid? ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string VendorNo { get; set; }
        public Guid? LrpvendorClassId { get; set; }
        public Guid? LrpvendorMasterId { get; set; }
        public Guid? LrpcompanyId { get; set; }
        public string ContactName { get; set; }
        public string AddressI { get; set; }
        public string AddressIi { get; set; }
        public string AddressIii { get; set; }
        public string City { get; set; }
        [Display(Name = "Country")]
        public Guid? CountryId { get; set; }
        [Display(Name = "Country State")]
        public Guid? CountryStateId { get; set; }
        public string PostalCode { get; set; }
        public string Userdef1 { get; set; }
        public Guid? LrpdepartmentId { get; set; }

    }
    public class LRPVendorListModel
    {
        public Guid ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string VendorNo { get; set; }
        [Display(Name ="Vendor class")]
        public Guid? LrpvendorClassId { get; set; }
        public Guid? LrpvendorMasterId { get; set; }
        public Guid? LrpcompanyId { get; set; }
        public string ContactName { get; set; }
        public string AddressI { get; set; }
        public string AddressIi { get; set; }
        public string AddressIii { get; set; }
        public string City { get; set; }
        [Display(Name = "Country")]
        public Guid? CountryId { get; set; }
        [Display(Name = "Country State")]
        public Guid? CountryStateId { get; set; }
        public string PostalCode { get; set; }
        [Display(Name ="Employee No")]
        public string Userdef1 { get; set; }
        [Display(Name = "Department")]

        public Guid? LrpdepartmentId { get; set; }

    }
}
