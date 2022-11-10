using System;
using System.Collections.Generic;
namespace Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes
{
    public class RibbonBarSectionsProfile : BaseEntity
    {
        public Int64 RibbonBarSectionId { get; set; }
        public Int64 RibbonBarId { get; set; }
        public string SectionName { get; set; }
        public Int64 SectionOrder { get; set; }
        public Int64 LanguageId { get; set; }
        public Int32 NoofColumn { get; set; }
        public Int32 NoofRows { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public List<RibbonBarButtonsProfile> RibbonBarButtonsProfile { get; set; }

        public RibbonBarSectionsProfile()
        {
            RibbonBarButtonsProfile = new List<RibbonBarButtonsProfile>();
        }

    }
}
