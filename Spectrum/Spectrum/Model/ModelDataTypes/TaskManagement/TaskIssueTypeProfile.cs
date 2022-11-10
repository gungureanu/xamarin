using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
   public class TaskIssueTypeProfile : BaseEntity
    {
        public Int64 IssueTypeID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public Int32 SortOrder { get; set; }
        public bool Active { get; set; }
        
    }
}
