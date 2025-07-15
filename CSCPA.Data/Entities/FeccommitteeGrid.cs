using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FeccommitteeGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string TreasurerName { get; set; }
        public string CommitteeIdentification { get; set; }
        public string AddressLineI { get; set; }
        public string AddressLineIi { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string CommitteeType { get; set; }
        public string Party { get; set; }
        public string FilingFrequency { get; set; }
        public string InterestGroupCategory { get; set; }
        public string ConnectedOrganizationName { get; set; }
        public string CandidateIdentification { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public Guid? FeccompanyId { get; set; }
    }
}
