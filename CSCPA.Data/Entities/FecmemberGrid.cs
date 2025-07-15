using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FecmemberGrid
    {
        public Guid ObjectUid { get; set; }
        public string Company { get; set; }
        public string MemberCode { get; set; }
        public string LocalUnion { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Prefix { get; set; }
        public string PhoneHome { get; set; }
        public string EmailPrimary { get; set; }
        public string AddressLineI { get; set; }
        public string AddressLineIi { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string JobTitle { get; set; }
        public string Employer { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public string Name { get; set; }
        public Guid FeccompanyId { get; set; }
        public string City { get; set; }
    }
}
