using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Spectrum.Model.ModelDataTypes
{
    public class RolePermissionProfile : BaseEntity
    {
        public int RoleID { get; set; }
        public int PermissionID { get; set; }
        public string PermissionName { get; set; }
        public bool pCreate { get; set; }
        public bool pDelete { get; set; }
        public bool pRead { get; set; }
        public bool pUpdate { get; set; }
    }

    public class ModuleNavRightSide : BaseEntity
    {
        public int ModuleNavRightSideID { get; set; }
        public string NavRightSidePanelName { get; set; }
        public string SubModuleName { get; set; }
        public string NavRightPanelKey { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string TooltipText1 { get; set; }
        public string TooltipText2 { get; set; }
        public string ModuleName { get; set; }
        public bool? IsGrant { get; set; }
        public bool Active { get; set; }
        public bool IsEnabled { get; set; }
        public List<ModuleNavRightSide> ModuleNavRightSideList { get; set; }
    }
}
