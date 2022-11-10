using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class DepartmentProfile : BaseEntity
    {
        public Guid CompanyID { get; set; }
        public Int32 DepartmentID { get; set; }
        public string Description { get; set; }
        public int WorkspaceID { get; set; }
        public string DepartmentName { get; set; }
        public bool Active { get; set; }
        public bool IsDefaultDepartment { get; set; }
        public Guid DepartmentSupervisorID { get; set; }
        public int LanguageID { get; set; }
        public string ReturnMessage { get; set; }
        public Guid AccountID { get; set; }
        public Int32 ModuleID { get; set; }
        public List<UserProfile> UserOfAllCompanyList { get; set; }
        public List<CompanyProfile> CompanyList { get; set; }
        public List<LangaugeProfile> LanguageList { get; set; }
        public List<TimeZoneProfile> TimeZoneList { get; set; }
        public List<DateFormat> DateFormatList { get; set; }
        public List<GroupProfile> GroupList { get; set; }
        public List<UserProfile> UserList { get; set; }
        public List<ResourceProfile> ResourceProfileList = new List<ResourceProfile>();

        public DepartmentProfile()
        {
            GroupList = new List<GroupProfile>();
            UserList = new List<UserProfile>();
            CompanyList = new List<CompanyProfile>();
            LanguageList = new List<LangaugeProfile>();
            TimeZoneList = new List<TimeZoneProfile>();
            DateFormatList = new List<DateFormat>();
            UserOfAllCompanyList = new List<UserProfile>();
        }


    }
}
