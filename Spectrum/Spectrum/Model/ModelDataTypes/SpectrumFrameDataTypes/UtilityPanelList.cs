using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes
{
    public class UtilityPanelList : BaseEntity
    {
        public Int32 WebUtilitiesID { set; get; }
        public Int32 IconID { set; get; }
        public string UtilitiesName { set; get; }
        public Int32 DisplayOrder { set; get; }
        public string MethodAction { get; set; }
        public bool Active { get; set; }
        public string IconCss { get; set; }
        public string icontype { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Position { get; set; }

    }//== CLASS ENDS HERE
}
