using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes
{
    public class ModuleNavLevelFiveItem
    {
        public Int64 ModulesNavLevelFiveID { get; set; }
        public string labeltext { get; set; }
        public string labelId { get; set; }
        public string tableName { get; set; }
        public string FileName { get; set; }
        public string IconCSS { get; set; }
        public string IconType { get; set; }
        public bool Active { get; set; }
        public bool IsList { get; set; }
        public Int64 ProjectTypeID { get; set; }
        public string labelId2 { get; set; }
        public string ActionMethod { get; set; }
    }
}
