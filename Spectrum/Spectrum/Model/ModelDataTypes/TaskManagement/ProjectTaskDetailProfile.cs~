using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class ProjectTaskDetailProfile : BaseEntityOptional
    {
        public ProjectTaskDetailProfile()
        {
            ProgressBarList = new List<ProgressBar>();
            GanttChartBarList = new List<GanttChartBar>();
        }
        public Int64 TaskID { get; set; }
        public Int64 GroupID { get; set; }
        public Int64 TeamID { get; set; }
        public Int64 GroupTypeID { get; set; }
        public Int64 TaskTypeID { get; set; }
        public Int64 ProjectID { get; set; }
        public Guid CompanyID { get; set; }
        public Guid AccountID { get; set; }
        public Guid UserID { get; set; }
        public int ModuleID { get; set; }
        public Int64 LanguageID { get; set; }
        public Int64 PriorityID { get; set; }
        public Int64 TaskStatusID { get; set; }
        public Guid? AssignedToID { get; set; }
        public Guid? ReportingID { get; set; }
        public Guid? AssignedID { get; set; }
        public Guid? AssignedToIDBackup { get; set; }
        public string CompanyName { get; set; }
        public Int64 TaskTemplateID { get; set; }
        public Guid? RequestedByID { get; set; }
        public Int64 ParentTaskID { get; set; }
        public Int64 EmailMessageID { get; set; }
        public Int64 VideoMessageID { get; set; }
        public Int64 BusinessRequirementID { get; set; }
        public string TaskName { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string TaskPrefixKey { get; set; }
        public string ProjectAssignName { get; set; }
        public string ProjectAssignImage { get; set; }
        public string ImportOptions { get; set; }
        public decimal EstimateHoursOriginal { get; set; }
        public decimal EstimateHoursCompleted { get; set; }
        public decimal EstimateHoursRemaining { get; set; }
        public decimal RemainingHourPercentage { get; set; }
        public Guid? AssignedToIDUnitTest { get; set; }
        public Guid? AssignedToIDQATest { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ActualDueDate { get; set; }

        string taskStatus = string.Empty;
        public string TaskStatus { get; set; }

        public string IssueTypeName { get; set; }
        public string ProjectName { get; set; }
        public string PriorityName { get; set; }
        public string LocationURL { get; set; }
        public DateTime OrignalDate { get; set; }
        public Guid? BackOfficeAssignedToID { get; set; }

        public Int64 CategoryID { get; set; }

        public Int64 WorkflowStepID { get; set; }

        public Int64 WorkflowID { get; set; }
        public Guid? BackOfficeAssignedToIDBackup { get; set; }
        public string BackOfficeTaskDescription { get; set; }
        public string WorkflowStepName { get; set; }
        public string Versions { get; set; }

        public Int32 ReleaseID { get; set; }
        public bool Private { get; set; }
        public bool Active { get; set; }
        public bool Confidential { get; set; }

        public string ReturnMessage { get; set; }

        public string ReadStatus { get; set; }

        public bool FavoriteStatus { get; set; }

        public int IndentPadding { get; set; }

        public string Status { get; set; }

        public Int64 ActivityDurationInSecond { get; set; }

        public Int32 Hours { get; set; }

        public Int32 Minutes { get; set; }

        public Int32 Seconds { get; set; }

        public Int64 TotalHoursTaken { get; set; }
        public DateTime? EstimatedStartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public Guid? EstimatedbyID { get; set; }
        public Int32 DeliverableID { get; set; }
        public Int32 MilestoneID { get; set; }
        public string FileName { get; set; }
        public string ColorCode { get; set; }
        string taskDonePercent = string.Empty;
        public string TeamName { get; set; }
        public string TaskLinkType { get; set; }
        public string ImagePath { get; set; }
        public Boolean drag { get; set; } = true;
        public int DisplayOrder { get; set; }
        public int KanbanDisplayorder { get; set; }
        public Int64 ReferenceTaskID { get; set; }
        public Int64 PageNo { get; set; }
        public List<Int64> TaskIDInGroup = new List<Int64>();
        public int CurrentIndex { get; set; }
        public int TotalTaskCount { get; set; }

        public string TaskDonePercent
        {
            get { return CalculateTaskPercent(EstimateHoursCompleted, EstimateHoursOriginal * 60); }
            set { taskDonePercent = value; }
        }

        public string EstimatedHourDisplay
        {
            get
            {
                return EstimateHoursOriginal > 999 ? Convert.ToString(EstimateHoursOriginal).Split('.')[0] : Convert.ToString(EstimateHoursOriginal).Replace(".", ":");
            }
            set { EstimatedHourDisplay = value; }
        }

        private string CalculateTaskPercent(decimal EstimateHoursCompleted, decimal estimateHoursOriginal)
        {
            return estimateHoursOriginal == 0 ? "0" : ((EstimateHoursCompleted / estimateHoursOriginal) * 100).ToString();
            //return ((estimateHoursRemaining / estimateHoursOriginal) * 100).ToString();
        }
        public List<ProgressBar> ProgressBarList { get; set; }
        public string DateFormatName { get; set; }

        public List<ProjectGroupsProfile> ProjectGroupsProfileList { get; set; }
        public string DisplayEstimateHoursRemaining { get; set; }


        public int GraphInitiateFrom { get; set; }

        public int GraphEndTo { get; set; }

        public int CountSubTask { get; set; }

        public int IndentLevel { get; set; }

        public string Successor { get; set; }

        public string DisplaySuccessor { get; set; }

        public string DisplayPreDecessor { get; set; }

        public string PreDecessor { get; set; }

        public int TaskKey { get; set; }

        public List<GanttChartBar> GanttChartBarList { get; set; }

        public DateTime GanttDateFrom { get; set; }
        public DateTime GanttDateTo { get; set; }
        public bool IsWFApprovalRequired { get; set; }
        public bool IsWFApprovalRequestSubmited { get; set; }
        public bool IsUserApprover { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDeclined { get; set; }
        public bool IsAllApproved { get; set; }
        public bool IsTaskAssigned { get; set; }
        public decimal PercentageDone { get; set; }
        public int TotalMinuteTaken { get; set; }
        public bool IsImportprocess { get; set; }
        public int WorkspaceID { get; set; }
        public bool IsFirstRowHeader { get; set; }
        public int TotalPage { get; set; }
        public string TotalRunningTimer { get; set; }
        public bool Milestone { get; set; }
        public decimal Cost { get; set; }
        public decimal ActualCost { get; set; }
        public string PriorityColorCode { get; set; }
        public Guid? ProjectLeadID { get; set; }
        public string ProjectManagerName { get; set; }
        public string TypeName { get; set; }
        public string TaskMode { get; set; }
        public decimal ActualHours { get; set; }
        public decimal HourlyRate { get; set; }

        public bool IsConstraint { get; set; }
        public bool IsKanbanAvailable { get; set; }
        public bool IsMilestoneAvailable { get; set; }
        public bool IsGanttChartAvailable { get; set; }
        public string ProjectManagerNotes { get; set; }
        public int PriorityNumber { get; set; }
        public string WBS { get; set; }
        public string BCDRImpact { get; set; }
        public string OCMImpact { get; set; }
        public bool IsBCDRImpact { get; set; }
        public bool IsOCMImpact { get; set; }
        public string ChargeCode { get; set; }
        public string BillingTag { get; set; }
        public string ProjectCustomer { get; set; }
        public string DepartmentName { get; set; }
        public string ProjectChargeCode { get; set; }
        public int LinkTaskID { get; set; }
        public int DurationPlanned { get; set; }
        public int DurationActual { get; set; }
        public bool BilledStatus { get; set; }
    }
    public class GanttChartBar
    {
        public int VerticleGanttChartBar { get; set; }
        public int HorizontalGanttChartBar { get; set; }
        public string Direction { get; set; }
    }

    public class GroupItemDetail
    {
        public int TotalUsers { get; set; }
        public decimal PercentageDone { get; set; }
    }
}
