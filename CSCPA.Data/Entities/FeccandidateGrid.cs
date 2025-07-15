using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FeccandidateGrid
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string CandidateIdentification { get; set; }
        public string PartyDesignationI { get; set; }
        public string Filler { get; set; }
        public string PartyDesignationIii { get; set; }
        public string CandidateType { get; set; }
        public string FillerIi { get; set; }
        public string CandidateStatus { get; set; }
        public string AddressLineI { get; set; }
        public string AddressLineIi { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string PrincipalCampaignComm { get; set; }
        public string YearOfElection { get; set; }
        public string CurrentDistrict { get; set; }
        public string ElectionOffice { get; set; }
        public string ElectionState { get; set; }
        public string ElectionDistrict { get; set; }
        public string ElectionOtherIdentification { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public Guid FeccompanyId { get; set; }
    }
}
