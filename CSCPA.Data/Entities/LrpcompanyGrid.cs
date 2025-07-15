using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class LrpcompanyGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Phone { get; set; }
        public string AddressLineI { get; set; }
        public string AddressLineIi { get; set; }
        public string AddressLineIii { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ParentCompany { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
