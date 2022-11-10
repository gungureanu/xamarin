using System;
using System.Collections.Generic;
namespace Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes
{
    public class RibbonBarTabsProfile : BaseEntity
    {
        public Int64 RibbonBarId { get; set; }
        public Int64 WorkspaceId { get; set; }
        public Int64 ModuleId { get; set; }
        public Int64 LangaugeId { get; set; }
        public Int64 WorkModuleIDspaceId { get; set; }
        public string TabName { get; set; }
        public string Description { get; set; }
        public string ActionController { get; set; }
        public bool Active { get; set; }
        public List<RibbonBarSectionsProfile> RibbonBarSectionsProfile { get; set; }
        public RibbonBarTabsProfile()
        {
            RibbonBarSectionsProfile = new List<RibbonBarSectionsProfile>();
        }
        

    }
}
