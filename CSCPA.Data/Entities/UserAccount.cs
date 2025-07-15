using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class UserAccount
    {
        public UserAccount()
        {
            ApplicationLogs = new HashSet<ApplicationLog>();
            Fecdistributions = new HashSet<Fecdistribution>();
            ReferenceAttachmentUserAccounts = new HashSet<ReferenceAttachmentUserAccount>();
            ReferenceUserAccounts = new HashSet<ReferenceUserAccount>();
            UserAccountBdgcompanies = new HashSet<UserAccountBdgcompany>();
            UserAccountBdgdepartments = new HashSet<UserAccountBdgdepartment>();
            UserAccountBdgreports = new HashSet<UserAccountBdgreport>();
            UserAccountBookmarks = new HashSet<UserAccountBookmark>();
            UserAccountFeccompanies = new HashSet<UserAccountFeccompany>();
            UserAccountFeclocalUnions = new HashSet<UserAccountFeclocalUnion>();
            UserAccountGrids = new HashSet<UserAccountGrid>();
            UserAccountLrpcompanies = new HashSet<UserAccountLrpcompany>();
            UserAccountModules = new HashSet<UserAccountModule>();
            UserAccountNotificationTypes = new HashSet<UserAccountNotificationType>();
            UserAccountPasswordLists = new HashSet<UserAccountPasswordList>();
            UserAccountRoles = new HashSet<UserAccountRole>();
        }

        public Guid ObjectUid { get; set; }
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
        public int DefaultPageSize { get; set; }
        public Guid LocalisationId { get; set; }
        public Guid? InitialRoleId { get; set; }
        public Guid? StartupMenuId { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsInactive { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int RecordId { get; set; }
        public int? OldRecordId { get; set; }
        public Guid? InstallationUid { get; set; }
        public string ImportedObjectUid { get; set; }

        public virtual Country Country { get; set; }
        public virtual CountryState CountryState { get; set; }
        public virtual Role InitialRole { get; set; }
        public virtual Localisation Localisation { get; set; }
        public virtual Menu StartupMenu { get; set; }
        public virtual ICollection<ApplicationLog> ApplicationLogs { get; set; }
        public virtual ICollection<Fecdistribution> Fecdistributions { get; set; }
        public virtual ICollection<ReferenceAttachmentUserAccount> ReferenceAttachmentUserAccounts { get; set; }
        public virtual ICollection<ReferenceUserAccount> ReferenceUserAccounts { get; set; }
        public virtual ICollection<UserAccountBdgcompany> UserAccountBdgcompanies { get; set; }
        public virtual ICollection<UserAccountBdgdepartment> UserAccountBdgdepartments { get; set; }
        public virtual ICollection<UserAccountBdgreport> UserAccountBdgreports { get; set; }
        public virtual ICollection<UserAccountBookmark> UserAccountBookmarks { get; set; }
        public virtual ICollection<UserAccountFeccompany> UserAccountFeccompanies { get; set; }
        public virtual ICollection<UserAccountFeclocalUnion> UserAccountFeclocalUnions { get; set; }
        public virtual ICollection<UserAccountGrid> UserAccountGrids { get; set; }
        public virtual ICollection<UserAccountLrpcompany> UserAccountLrpcompanies { get; set; }
        public virtual ICollection<UserAccountModule> UserAccountModules { get; set; }
        public virtual ICollection<UserAccountNotificationType> UserAccountNotificationTypes { get; set; }
        public virtual ICollection<UserAccountPasswordList> UserAccountPasswordLists { get; set; }
        public virtual ICollection<UserAccountRole> UserAccountRoles { get; set; }
    }
}
