using System;
using System.Collections.Generic;
using System.Text;
namespace Spectrum.Model.ModelDataTypes
{
    public class MobileTaskViewModel
    {
        public Int64 ProjectID { get; set; }
        public string TaskName { get; set; }
        public int TaskTypeID { get; set; }
        public int TaskPriorityID { get; set; }
        public Guid ProjectManagerID { get; set; }
        public Guid TaskOwnerID { get; set; }
        public int TaskDescription { get; set; }
        public string TaskStartDate { get; set; }
        public string TaskSubmitDate { get; set; }
        public Guid CreatedBy { get; set; }
        public List<ProjectDetailList> lstProject { get; set; }
        public List<TaskTypeProfile> lstTaskType { get; set; }
        public List<TaskPriorityProfile> lstTaskPriority { get; set; }
        public List<UserProfile> lstProjectManager { get; set; }
        public List<UserProfile> lstTaskOwner { get; set; }
        public List<ProjectGroupsProfile> ProjectGroupsProfileList { get; set; }
        public MobileTaskViewModel()
        {
            lstProject = new List<ProjectDetailList>();
            lstTaskType = new List<TaskTypeProfile>();
            lstTaskPriority = new List<TaskPriorityProfile>();
            lstProjectManager = new List<UserProfile>();
            lstTaskOwner = new List<UserProfile>();
            ProjectGroupsProfileList = new List<ProjectGroupsProfile>();
        }
    }
}