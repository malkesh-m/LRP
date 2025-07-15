using System;
using System.ComponentModel.DataAnnotations;

namespace CSCPA.Model
{
    public class LRPCompanyListModel
    {
        public Guid ObjectUID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string AddressLineI { get; set; }
        public string AddressLineII { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        [Display(Name = "Country")]
        public Guid? CountryId { get; set; }
        [Display(Name = "Country State")]
        public Guid? CountryStateId { get; set; }
        [Display(Name = "Parent Lrpcompany")]
        public Guid? ParentLrpcompanyId { get; set; }
        public string Description { get; set; }

    }
    public class LRPCompanyAddEditModel
    {
        public Guid? ObjectUID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string AddressLineI { get; set; }
        public string AddressLineII { get; set; }
        public string AddressLineIII { get; set; }
        public string PostalCode { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? CountryStateId { get; set; }
        public Guid? ParentLrpcompanyId { get; set; }
        public string Description { get; set; }
    }
}
