using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Model
{
    public class UserAccountAddEditModel
    {
        public Guid? ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Password and confirm password should be same.")]
        public string ConfirmPassword { get; set; }
        public string AddressLineI { get; set; }
        public string AddressLineIi { get; set; }
        public string AddressLineIii { get; set; }
        public string City { get; set; }
        public Guid? CountryStateId { get; set; }
        public string PostalCode { get; set; }
        public Guid? CountryId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int InvalidAttemptCount { get; set; }
        public bool IsUserAccountLocked { get; set; }
        public DateTime? PasswordExpirationDate { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public int DefaultPageSize { get; set; }
        public Guid LocalisationId { get; set; }
        public Guid? InitialRoleId { get; set; }
        public Guid? StartupMenuId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Localisation { get; set; }

    }
    public class UserAccountListModel
    {
        public Guid ObjectUID { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string AddressLineI { get; set; }
        public string AddressLineIi { get; set; }
        public string AddressLineIii { get; set; }
        public string City { get; set; }
        public Guid? CountryStateId { get; set; }
        public string PostalCode { get; set; }
        public Guid? CountryId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int InvalidAttemptCount { get; set; }
        public bool IsUserAccountLocked { get; set; }
        public DateTime? PasswordExpirationDate { get; set; }
    } 
}
