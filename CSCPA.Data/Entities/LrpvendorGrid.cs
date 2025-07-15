using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrpvendorGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string VendorNo { get; set; }
        public string VendorClass { get; set; }
        public string VendorMaster { get; set; }
        public string Company { get; set; }
        public string ContactName { get; set; }
        public string AddressI { get; set; }
        public string AddressIi { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public Guid? LrpcompanyId { get; set; }
        public string EmployeeNo { get; set; }
        public string PayrollNo { get; set; }
    }
}
