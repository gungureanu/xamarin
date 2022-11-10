using System;
using System.Collections.Generic;
namespace Spectrum.Model.ModelDataTypes
{
    public class FilterColumnProfile
    {
        public int FilterColumnID { get; set; }
        public int ModuleID { get; set; }
        public string DisplayColumnName { get; set; }
        public string ColumnName { get; set; }
        public string ColumnType { get; set; }
        public int DisplayOrder { get; set; }
        public bool Active { get; set; }

    }

}
