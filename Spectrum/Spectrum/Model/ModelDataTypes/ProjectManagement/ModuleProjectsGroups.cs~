using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class ModuleProjectsGroups : BaseEntity
    {
        public Int64 GroupID { get; set; }
        public Int64 GroupTypeID { get; set; }
        public Int64 GroupStatusID { get; set; }
        public Int64 ProjectID { get; set; }
        public int GroupTypeParentID { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public DateTime EstimatedStartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        private bool isVisible = true;
        private bool IsLastChild { get; set; }
        public bool IsVisible { get { return isVisible; } set { isVisible = value; } }
        public bool Active { get; set; }
        public int TotalTaskInGroup { get; set; }
        public int TotalAssignedUserInGroup { get; set; }
        public string Status { get; set; }
        public List<ProjectTaskDetailProfile> TaskListInGroup { get; set; }
        public List<ModuleProjectsGroups> ModuleProjectsGroupsParentList { get; set; }
        public List<ModuleProjectsGroups> ModuleProjectsGroupsList { get; set; }
        public List<ProjectGroupTypes> ProjectGroupTypesList { get; set; }
        public List<ProjectsParentGroupProfile> ProjectDeliverableList { get; set; }
        public List<ReleaseProfile> ReleaseProfileList { get; set; }
        public List<ModuleProjectsGroupStatusTypes> ModuleProjectsGroupStatusTypesList { get; set; }
        public string GroupTypeName { get; set; }
        public string ReturnMessage { get; set; }
        public int ModuleID { get; set; }
        public int LanguageID { get; set; }
        public CustomMessage CustomMessage { get; set; }
        public decimal TotalPercentage { get; set; }
        public decimal TotalTimeConsumed { get; set; }
        public decimal TotalEstimateHours { get; set; }
        public int TotalPage { get; set; }
        public List<ProgressBar> ProgressBarList = new List<ProgressBar>();
        public decimal PercentageDone { get; set; }

        public ModuleProjectsGroups()
        {
            TaskListInGroup = new List<ProjectTaskDetailProfile>();
            ModuleProjectsGroupsList = new List<ModuleProjectsGroups>();
            ProjectGroupTypesList = new List<ProjectGroupTypes>();
            ModuleProjectsGroupStatusTypesList = new List<ModuleProjectsGroupStatusTypes>();
            ProjectGroupTypesList = new List<ProjectGroupTypes>();
            ModuleProjectsGroupsParentList = new List<ModuleProjectsGroups>();
        }
        public Guid AccountID { get; set; }

    }
}
