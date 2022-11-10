using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
   public class ProjectStatusProfile : BaseEntity
    {
        public Int64 ProjectStatusID { get; set; }
        public Guid CompanyID { get; set; }
        public string StatusName { get; set; }
        public string Description { get; set; }
        public Int32 SortOrder { get; set; }        
        public bool Active { get; set; }
    }
}
