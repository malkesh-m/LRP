using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class FeccontributionLimitGrid
    {
        public Guid ObjectUid { get; set; }
        public string ContributorCategory { get; set; }
        public decimal? LimitToEachCandidateCommitteePerElection { get; set; }
        public decimal? LimitToNationalPartyCommitteePerYear { get; set; }
        public decimal? LimitToStateDistrictLocalCommitteePerYear { get; set; }
        public decimal? LimitToOtherPoliticalCommitteePerYear { get; set; }
        public decimal? SpecialOverallBiennialLimitToAllCandidates { get; set; }
        public decimal? SpecialOverallBiennialLimitToPacandParties { get; set; }
        public decimal? SpecialLimitToSenateCandidatePerCampaign { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
