using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes

{
    public class ModuleMainPanel : BaseEntity
    {
        public int ModuleId { get; set; }
        public int ModuleTabId { get; set; }
        public int IconId { get; set; }
        public string IConFileName { set; get; }
        public string ModuleName { get; set; }
        public string Description { get; set; }
        public string ActionController { get; set; }
        public int DisplayOrder { get; set; }
        public bool Active { get; set; }
        public bool IsDefault { get; set; }

    }//== CLASS ENDS HERE
}
