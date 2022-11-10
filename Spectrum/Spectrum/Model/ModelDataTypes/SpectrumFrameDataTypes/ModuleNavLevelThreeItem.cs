using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes
{
    public class ModuleNavLevelThreeItem
    {
        public Int64 ModulesNavLevelThreeID { get; set; }
        public string labeltext { get; set; }
        public string labelId { get; set; }//change data type for User GUID
        public string tableName { get; set; }
        public string FileName { get; set; }
        public string IconCSS { get; set; }
        public string IconType { get; set; }
        public bool Active { get; set; }
        public bool IsList { get; set; }
        public Int64  ProjectTypeID { get; set; }
        public string NavLevelClass { get; set; }
        //============================================================================
        //=== Used In Case of Company Binding to Check CompanyIsDefault or Not ======
        public bool IsDefault { get; set; }
        //=============================================================================
    }//== CLASS ENDS HERE
}
