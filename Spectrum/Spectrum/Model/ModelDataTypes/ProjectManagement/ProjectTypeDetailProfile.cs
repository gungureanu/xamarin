using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
   public class ProjectTypeDetailProfile : BaseEntity
    {
        public Int64 ProjectTypeID { get; set; }
        public  Int32 ProjectypeCategoryID { get; set; }
        public string FileName { get; set; }
        //public string ProjectTypeName { get; set; }        
        public string TypeName { get; set; }
        public string Description { get; set; }        
        public bool Active { get; set; }
    }
}
