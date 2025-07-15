using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class UserAccountGrid1
    {
        public Guid ObjectUid { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsUserAccountLocked { get; set; }
        public DateTime? PasswordExpirationDate { get; set; }
        public int InvalidAttemptCount { get; set; }
        public int DefaultPageSize { get; set; }
        public string Localisation { get; set; }
        public string InitialRole { get; set; }
        public string StartUpMenu { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
    }
}
