using System;
using System.Collections.Generic;
using System.Text;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;

namespace Spectrum.Model.ModelDataTypes
{
    public class ProjectManagementViewModel
    {
        public ProjectListProfile ProjectListProfile { get; set; }
        public TaskWorkflowStep TaskWorkflowSteps { get; set; }
        public ProjectTaskDetailProfile ProjectTaskDetailProfile { get; set; }
        public IEnumerable<ProjectListProfile> ProjectList { get; set; }
        public IEnumerable<ProjectGroupsProfile> projectGroupList { get; set; }
        public IEnumerable<ProjectTaskDetailProfile> projectTaskList { get; set; }
        public IEnumerable<UserProfile> ddlProjectUser { get; set; }
        public List<TaskPriorityProfile> taskPriority { get; set; }
        public IEnumerable<TaskTimeSheetDate> taskTimeSheetDateList { get; set; }
        public IEnumerable<TaskTimeSheet> taskTimeSheetList { get; set; }
        public List<UserProfile> ddlUserList { get; set; }
        public List<TaskTypeCategoryProfile> TaskTypeCategoryList { get; set; }
        public List<ProjectStatusProfile> ProjectStatusList { get; set; }
        public List<ProjectTypeDetailProfile> ProjectTypeList { get; set; }
        public List<LangaugeProfile> LanguageList { get; set; }
        public List<TimeZoneProfile> TimeZoneList { get; set; }
        public List<CompanyProfile> CompanyList { get; set; }
        public List<TeamProfile> DepartmentTeamList { get; set; }
        public List<WorkflowProfile> WorkFlowList { get; set; }
        public List<WorkingDaysProfile> WorkingDaysList { get; set; }
        public List<ProjectCommentProfile> ProjectCommentList { get; set; }
        public List<TaskTemplateProfile> TaskTemplateList { get; set; }
        public List<TaskTypeProfile> TaskTypeList { get; set; }
        public List<TaskPriorityProfile> TaskPriorityList { get; set; }
        public List<TaskStatusProfile> TaskStatusList { get; set; }
        public List<CompanyProfile> companyProfilesList { get; set; }
        public IEnumerable<TaskTimeSheetApproval> taskTimeSheetApprovals { get; set; }
        public List<TaskCommentProfile> TaskCommentList { get; set; }
        public List<ProjectTypeCategory> ProjectTypeCategoryList { get; set; }
        public List<PortfolioProfile> ProjectPortfolioList { get; set; }
        public List<FilterColumnProfile> FilterColumnList { get; set; }
        public List<FilterDetails> FilterDetailsList { get; set; }
        public List<ProjectsParentGroupProfile> ProjectDeliverableList { get; set; }
        public List<ProjectMilestone> ProjectMileStoneList { get; set; }
        public List<ProgressBar> ProgressBarList { get; set; }
        public List<ModuleNavRightSide> ModuleNavRightSide { get; set; }
        public ModuleNavLevelThreeItem ModuleNavLevelThreeItem { get; set; }
        public List<WorkFlowGroup> WorkFlowGroupList = new List<WorkFlowGroup>();
        public List<HelpText> HelpTextList { get; set; }
        public List<ReleaseProfile> ReleaseProfileList { get; set; }
        public List<ProjectGroupsProfile> ProjectGroupsProfileList { get; set; }
        public List<TaskMonthList> TaskMonthLists { get; set; }
        public ProjectStateFields objStatefieldData { get; set; }
        public List<ProjectIPORRating> ProjectIPORRatingList = new List<ProjectIPORRating>();
        public List<ProjectScheduleFrom> ProjectScheduleList = new List<ProjectScheduleFrom>();
        public CustomMessage CustomMessage { get; set; }
    }
}
