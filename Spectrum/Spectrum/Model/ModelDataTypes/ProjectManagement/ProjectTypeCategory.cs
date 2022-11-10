using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
   public class ProjectTypeCategory
    {
        public Int64 ProjectTypeCategoryID { get; set; }
        public string ProjectCategoryName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDefault { get; set; }
        public bool Active { get; set; }
        public List<ProjectTypeDetailProfile> ProjectTypeList { get; set; }
    }
}
