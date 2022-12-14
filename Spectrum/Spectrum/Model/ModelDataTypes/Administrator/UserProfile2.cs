using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;

namespace Spectrum.Model.ModelDataTypes
{
    public class UserProfile2 : BaseEntityOptional
    {
        public Guid UserID { get; set; }
        public Guid AccountID { get; set; }
        public Guid PrimaryCompanyID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string CompanyPositionTitle { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsDefaultDepartment { get; set; }
        public Int32 TimezoneID { get; set; }
        public Int32 WebsiteID { get; set; }
        public Int32? ProfileImageID { get; set; }
        public string ProfileImageName { get; set; }
        public string ProfilePath { get; set; }
        public Guid CompanyID { get; set; }
        public Int32 LangaugeID { get; set; }
        public bool Active { get; set; }
        public int DateTimeFormat { get; set; }
        public Guid? SupervisorID { get; set; }
        public bool GrantAdminAccess { get; set; }
        public bool GrantEmployeeAccess { get; set; }
        public bool GuestAccess { get; set; }
        public bool AccountSuspended { get; set; }
        public bool AccountDeleted { get; set; }
        public bool AccountDisabled { get; set; }
        public bool AccountLocked { get; set; }
        public string LockedTimeLeft { get; set; }
        public bool CookieStatus { get; set; }
        public bool HeighlightUser { get; set; }
        public string UserExists { get; set; }
        public Int32 UserFailedcount { get; set; }
        public string ActiveStatus { get; set; }
        public string RoleIDList { get; set; }
        public Int64 TeamID { get; set; }
        public Int32 PlanID { get; set; }
        public Int32 ModuleID { get; set; }
        public DateTime LastLoginDate { get; set; }
        //Added by Prashant for Role & Permission 
        public bool IsGranted { get; set; }
        public bool IsDenied { get; set; }
        public bool ChangePasswordNextLogin { get; set; }
        public string IsSpecialLogin { get; set; }
        public string CompanyName { get; set; }
        public Int32 CompanyTypeID { get; set; }
        public Int32 CompanyIndustryID { get; set; }

        public bool Companydefault { get; set; }
        public bool HasEmployee { get; set; }
        public Int32 DepartmentID { get; set; }
        public List<UserProfile> UserList { get; set; }
        //public List<CompanyProfile> CompanyList { get; set; }
        //public List<LangaugeProfile> LanguageList { get; set; }
        //public List<TimeZoneProfile> TimeZoneList { get; set; }
        //public List<DateFormat> DateFormatList { get; set; }
        //public List<UserProfile> UserListByTeamId { get; set; }
        public List<UserImageProfile> UserImageProfileList { get; set; }
        //public List<TeamProfile> TeamProfileList { get; set; }
        //public TeamProfile TeamProfile { get; set; }
        //Added field to bind role list on user authentication
        //public List<RoleProfile> RoleList { get; set; }
        public string DateFormatName { get; set; }
        public bool IsCommandAdmin { get; set; }
        //public List<WorkHourDetails> WorkHourDetailList { get; set; }
        public int TrialDays { get; set; }
        public ModuleNavLevelThreeItem ModuleNavLevelThreeItem { get; set; }
        public CustomMessage CustomMessage = new CustomMessage();
        public string LicenseKey { get; set; }
        public int WorkspaceID { get; set; }
        public string AccountStatus { get; set; }
        public bool IsPayMode { get; set; }
        public string UserInGroup { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal OverTime { get; set; }
        public decimal CurHourlyRate { get; set; }
        public decimal CurOverTime { get; set; }
        public int RoleID { get; set; }
        public Int64 ProjectID { get; set; }
        public int LanguageID { get; set; }
        public bool IsUpload { get; set; }
        public bool IsDownload { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
        public string ReturnMessage { get; set; }
        public int GroupID { get; set; }
        public string RedirectType { get; set; }
        public bool IsResourceAccount { get; set; }
        public bool IsForceTrialAccount { get; set; }
        public string PlanName { get; set; }

    }
}
