using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
   public class ProjectGroupsProfile : BaseEntity
    {
        public Int64 GroupID { get; set; }
        public Int64 GroupTypeID { get; set; }
        public int GroupStatusID { get; set; }
        public int GroupTypeParentID { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public Int64 LanguageID { get; set; }
        public bool Active { get; set; }
        public bool IsLastGroupTypeChild { get; set; }
        public string ReturnMessage { get; set; }
        public List<ProjectTaskDetailProfile> ProjectTaskList = new List<ProjectTaskDetailProfile>();
        public string GroupTypeName { get; set; }
        public DateTime? EstimatedStartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public int EPICID { get; set; }
        public int ProjectID { get; set; }
        public int ProjectTypeID { get; set; }
        public CustomMessage CustomMessage { get; set; }
        public List<ProjectGroupsProfile> ProjectGroupList = new List<ProjectGroupsProfile>();


    }
}
