using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class Utility : BaseEntityOptional
    {

        public Guid AccountID { get; set; }
        public Guid UserID { get; set; }
        public int LanguageID { get; set; }        
        public int ModuleID { get; set; }
        public string id { get; set; }
        public string tableName { get; set; }
        public string columnName { get; set; }
        public string columnValue { get; set; }
        public string condition { get; set; }
        
    }
}
