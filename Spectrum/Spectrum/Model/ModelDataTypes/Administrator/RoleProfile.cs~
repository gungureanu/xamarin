using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;

namespace Spectrum.Model.ModelDataTypes
{
    public class RoleProfile : BaseEntity
    {
        public Guid AccountID { get; set; }
        public Guid CompanyID { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public bool IsSelected { get; set; }
        public string CurrentRoleStatus { get; set; }
        public string ReturnMessage { get; set; }
        public string RoleImage { get; set; }
        public List<RoleProfile> RoleProfileList { get; set; }
        public List<RightPrivilegesDetails> RightPrivilegesDetailsList { get; set; }
        public List<ConfigurationSettings> ConfigurationSettingsList { get; set; }
        public List<ModuleNavRightSide> NavigationRightPanelList { get; set; }
        public ModuleNavLevelThreeItem ModuleNavLevelThreeItem { get; set; }
        public Int32 WorkSpaceID { get; set; }
        public RoleProfile()
        {
            RoleProfileList = new List<RoleProfile>();
            ConfigurationSettingsList = new List<ConfigurationSettings>();
        }
        public int ModuleID { get; set; }
        public string RoleInPlans { get; set; }
        public int TotalUser { get; set; }
        public bool IsUploadAll { get; set; }
        public bool IsDownloadAll { get; set; }
        public bool IsUpdateAll { get; set; }
        public bool IsDeleteAll { get; set; }

        public int TotalUploadAll { get; set; }
        public int TotalDownloadAll { get; set; }
        public int TotalUpdateAll { get; set; }
        public int TotalDeleteAll { get; set; }
    }
}
