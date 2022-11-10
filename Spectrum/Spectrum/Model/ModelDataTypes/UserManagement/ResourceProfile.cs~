using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;
//using System.ComponentModel.DataAnnotations;

namespace Spectrum.Model.ModelDataTypes
{
    public class ResourceProfile : BaseEntity
    {

        public Guid ResourceAccountID { get; set; }
        public Guid UserID { get; set; }
        public Guid AccountID { get; set; }
        public Guid PrimaryCompanyID { get; set; }
        public string ResourceName { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string EmailAddress { get; set; }
        public Int32 TimezoneID { get; set; }
        public int WorkspaceID { get; set; }
        public Int32? ProfileImageID { get; set; }
        public string ProfileImageName { get; set; }
        public string ProfilePath { get; set; }
        public Guid CompanyID { get; set; }
        public Guid CustodianID { get; set; }
        public Int64 TeamID { get; set; }
        public int RoleID { get; set; }
        public Int32 PlanID { get; set; }
        public bool IsDefaultDepartment { get; set; }
        public Int32 DepartmentID { get; set; }
        public Int32 ModuleID { get; set; }
        public DateTime LastLoginDate { get; set; }
        public int LanguageID { get; set; }
        public bool Active { get; set; }
        public bool Archived { get; set; }
        public bool ReturnMessage { get; set; }
        public CustomMessage CustomMessage = new CustomMessage();
        public bool IsGranted { get; set; }
        public bool Companydefault { get; set; }

        public List<UserImageProfile> UserImageList = new List<UserImageProfile>();
        public List<ModuleNavLevelThreeItem> NavLevelThreeItem = new List<ModuleNavLevelThreeItem>();

    }
}
