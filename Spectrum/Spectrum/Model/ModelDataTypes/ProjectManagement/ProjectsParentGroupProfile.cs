using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class ProjectsParentGroupProfile : BaseEntity
    {
        public Int64 GroupID { get; set; }
        public Int64 GroupTypeID { get; set; }
        public Guid AccountID { get; set; }
        public int GroupTypeParentID { get; set; }
        public string GroupName { get; set; }
        public bool Active { get; set; }    
        public int TotalAction { get; set; }
        public int GroupStatusID { get; set; }
        public string Description { get; set; }
        public DateTime? EstimatedStartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public string ReturnMessage { get; set; }
        public int ModuleID { get; set; }
        public int LanguageID { get; set; }
        public CustomMessage CustomMessage { get; set; }
    }
}
