using System;
using System.Collections.Generic;

#nullable disable

namespace CSCPA.Data.Entities
{
    public partial class Bdgcompany
    {
        public Bdgcompany()
        {
            BdgaccountGroupTypes = new HashSet<BdgaccountGroupType>();
            BdgaccountGroups = new HashSet<BdgaccountGroup>();
            BdgbudgetGroupTypes = new HashSet<BdgbudgetGroupType>();
            BdgbudgetInfos = new HashSet<BdgbudgetInfo>();
            BdgcommitteeTypes = new HashSet<BdgcommitteeType>();
            BdgdepartmentGroups = new HashSet<BdgdepartmentGroup>();
            Bdgdepartments = new HashSet<Bdgdepartment>();
            BdgemployeeCategories = new HashSet<BdgemployeeCategory>();
            BdgemployeeEmployeeHistories = new HashSet<BdgemployeeEmployeeHistory>();
            BdgemployeePositions = new HashSet<BdgemployeePosition>();
            BdgemployeeStatuses = new HashSet<BdgemployeeStatus>();
            BdgemployeeTypes = new HashSet<BdgemployeeType>();
            BdgemployeeUnits = new HashSet<BdgemployeeUnit>();
            Bdgemployees = new HashSet<Bdgemployee>();
            BdgglaccountMappings = new HashSet<BdgglaccountMapping>();
            Bdggltransactions = new HashSet<Bdggltransaction>();
            BdgmeetingStatuses = new HashSet<BdgmeetingStatus>();
            BdgpositionTypes = new HashSet<BdgpositionType>();
            BdgprojectTypes = new HashSet<BdgprojectType>();
            BdgreportGroupTypes = new HashSet<BdgreportGroupType>();
            BdgreportGroups = new HashSet<BdgreportGroup>();
            BdgreportTypes = new HashSet<BdgreportType>();
            Bdgreports = new HashSet<Bdgreport>();
            InverseParentBdgcompany = new HashSet<Bdgcompany>();
            UserAccountBdgcompanies = new HashSet<UserAccountBdgcompany>();
        }

        public Guid ObjectUid { get; set; }
        public string Display { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public string Phone { get; set; }
        public string AddressLineI { get; set; }
        public string AddressLineIi { get; set; }
        public string AddressLineIii { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? CountryStateId { get; set; }
        public Guid? ParentBdgcompanyId { get; set; }
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
        public virtual Bdgcompany ParentBdgcompany { get; set; }
        public virtual ICollection<BdgaccountGroupType> BdgaccountGroupTypes { get; set; }
        public virtual ICollection<BdgaccountGroup> BdgaccountGroups { get; set; }
        public virtual ICollection<BdgbudgetGroupType> BdgbudgetGroupTypes { get; set; }
        public virtual ICollection<BdgbudgetInfo> BdgbudgetInfos { get; set; }
        public virtual ICollection<BdgcommitteeType> BdgcommitteeTypes { get; set; }
        public virtual ICollection<BdgdepartmentGroup> BdgdepartmentGroups { get; set; }
        public virtual ICollection<Bdgdepartment> Bdgdepartments { get; set; }
        public virtual ICollection<BdgemployeeCategory> BdgemployeeCategories { get; set; }
        public virtual ICollection<BdgemployeeEmployeeHistory> BdgemployeeEmployeeHistories { get; set; }
        public virtual ICollection<BdgemployeePosition> BdgemployeePositions { get; set; }
        public virtual ICollection<BdgemployeeStatus> BdgemployeeStatuses { get; set; }
        public virtual ICollection<BdgemployeeType> BdgemployeeTypes { get; set; }
        public virtual ICollection<BdgemployeeUnit> BdgemployeeUnits { get; set; }
        public virtual ICollection<Bdgemployee> Bdgemployees { get; set; }
        public virtual ICollection<BdgglaccountMapping> BdgglaccountMappings { get; set; }
        public virtual ICollection<Bdggltransaction> Bdggltransactions { get; set; }
        public virtual ICollection<BdgmeetingStatus> BdgmeetingStatuses { get; set; }
        public virtual ICollection<BdgpositionType> BdgpositionTypes { get; set; }
        public virtual ICollection<BdgprojectType> BdgprojectTypes { get; set; }
        public virtual ICollection<BdgreportGroupType> BdgreportGroupTypes { get; set; }
        public virtual ICollection<BdgreportGroup> BdgreportGroups { get; set; }
        public virtual ICollection<BdgreportType> BdgreportTypes { get; set; }
        public virtual ICollection<Bdgreport> Bdgreports { get; set; }
        public virtual ICollection<Bdgcompany> InverseParentBdgcompany { get; set; }
        public virtual ICollection<UserAccountBdgcompany> UserAccountBdgcompanies { get; set; }
    }
}
