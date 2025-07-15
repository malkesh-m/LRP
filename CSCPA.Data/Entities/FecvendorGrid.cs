using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FecvendorGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string VendorIdentification { get; set; }
        public string AddressLineI { get; set; }
        public string AddressLineIi { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public Guid? FeccompanyId { get; set; }
    }
}
