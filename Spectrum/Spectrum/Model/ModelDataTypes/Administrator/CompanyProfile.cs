using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;

namespace Spectrum.Model.ModelDataTypes
{
    public class CompanyProfile : BaseEntity
    {
        public Guid CompanyID { get; set; }
        public int WorkspaceID { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string DomainName { get; set; }
        public bool Active { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public bool IsContractor { get; set; }
        public bool IsVendor { get; set; }
        public bool IsCustomer { get; set; }
        public int LanguageID { get; set; }
        public int TimeZoneID { get; set; }
        public int DateFormatID { get; set; }
        public bool CompanyDefault { get; set; }
        public List<UserProfile> UserList { get; set; }
        public string ReturnMessage { get; set; }
        public List<UserProfile> UserOfAllCompanyList { get; set; }
        public List<CompanyProfile> CompanyList { get; set; }
        public List<LangaugeProfile> LanguageList { get; set; }
        public List<TimeZoneProfile> TimeZoneList { get; set; }
        public List<DateFormat> DateFormatList { get; set; }
        public List<GroupProfile> GroupList { get; set; }
        public Guid AccountID { get; set; }
        public int PlanID { get; set; }
        public ModuleNavLevelThreeItem ModuleNavLevelThreeItem { get; set; }

        public CompanyProfile()
        {
            GroupList = new List<GroupProfile>();
            UserList = new List<UserProfile>();
            CompanyList = new List<CompanyProfile>();
            LanguageList = new List<LangaugeProfile>();
            TimeZoneList = new List<TimeZoneProfile>();
            DateFormatList = new List<DateFormat>();
            UserOfAllCompanyList = new List<UserProfile>();
        }

        public int ModuleID { get; set; }
        public List<WorkspaceItem> WorkspaceItemList { get; set; }
        public string ManagerName { get; set; }
        public string UserName { get; set; }
        public List<ResourceProfile> ResourceProfileList = new List<ResourceProfile>();
    }
}
