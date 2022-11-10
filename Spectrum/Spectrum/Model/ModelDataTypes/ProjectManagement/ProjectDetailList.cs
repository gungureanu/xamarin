using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Spectrum.Model.ModelDataTypes
{
    public class ProjectDetailList : BaseEntityOptional
    {
        public Int64 ProjectID { get; set; }
        public Guid CompanyID { get; set; }
        public Guid AccountID { get; set; }
        public Int32 WorkSpaceID { get; set; }
        public int ModuleID { get; set; }
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
        public Int64 TeamID { get; set; }
        public Int64 ProjectTemplateID { get; set; }
        public Int64 ParentProjectID { get; set; }
        public Guid? DefaultTaskAssigneeID { get; set; }
        //=== FOR THE PURPOSE TO HOLD THE CLIENT ID ======
        public Guid? ClientId { get; set; }
        public Guid? CustomerID { get; set; }
        public bool IsUserBillableRate { get; set; }
        public bool IsTaskBillableRate { get; set; }
        //------------------------------------------------
        public string TeamName { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string ImportOptions { get; set; }
        public string ProjectKey { get; set; }
        public string TaskPrefixKey { get; set; }

        public Int32 NextTaskNumber { get; set; }
        public Int64 PortfolioID { get; set; }
        public Guid? ProjectStakeholderID { get; set; }
        public Guid? ProjectApproverID { get; set; }
        public Guid? TimeSheetApproverID { get; set; }
        public Guid? ProjectLeadID { get; set; }
        public string ProjectLeadName { get; set; }
        public Guid? ProjectContactID { get; set; }
        public Int64 ProjectTypeID { get; set; }
        public Int64 ProjectCategoryID { get; set; }
        public string ProjectTypeName { get; set; }
        public Int64 ProjectStatusID { get; set; }
        public string ProjectStatusName { get; set; }
        public string BudgetStatusName { get; set; }
        public Int64 WorkflowID { get; set; }
        public Int64 WorkflowStepID { get; set; }
        public Int64 TimezoneID { get; set; }
        public Int64 WorkingDaysID { get; set; }
        public Int64 LanguageID { get; set; }
        public Int64 PercentDoneID { get; set; }
        public string BudgetHours { get; set; }
        public decimal BudgetCost { get; set; }
        public decimal ActualHours { get; set; }
        public string TaskConsumedHours { get; set; }
        public decimal ActualCost { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime EstimatedStartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime ActualEndDate { get; set; }
        public bool Private { get; set; }
        public bool Confidential { get; set; }
        public bool Active { get; set; }
        public Int32 TotalTask { get; set; }
        public Int32 CompletedTask { get; set; }
        public decimal TaskPercetage { get; set; }
        public decimal ProjectPercetage { get; set; }
        public string ProjectManagerImage { get; set; }
        public string ReturnMessage { get; set; }
        public string ReadStatus { get; set; }
        //public List<ProjectTaskDetailProfile> ProjectTaskList = new List<ProjectTaskDetailProfile>();
        public int NumberOfTask { get; set; }
        //public List<ProgressBar> ProgressBarList = new List<ProgressBar>();
        public string DateFormatName { get; set; }
        public ProjectStateFields StateFields { get; set; }
        public bool IsGovernmentProject { get; set; }
        public bool FavoriteStatus { get; set; }
        public string FavoriteIconName { get; set; }
        public string ActiveStatus { get; set; }
        public bool TimeMaterials { get; set; }
        public bool FixedCost { get; set; }
        public bool NonBillable { get; set; }
        public Int64 TotalProjectHours { get; set; }
        public decimal ProjectHourlyRate { get; set; }
        public decimal ProjectMaterialCost { get; set; }
        public decimal ProjectActualMaterialCost { get; set; }
        public decimal BudgetHourlyRate { get; set; }
        public decimal StandardRate { get; set; }
        public decimal ProjectFixedCost { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public Int64 EstimateHoursOriginal { get; set; }
        public Int64 TotalTimeConsumed { get; set; }
        public string Where { get; set; }
        public bool IsBudgetReset { get; set; }
        public string ProjectCategoryName { get; set; }

        //===FOR THE PURPOSE OF THE MESSAGE HANDLING ====
        public CustomMessage CustomMessage { get; set; }
        public Guid? ClientID { get; set; }
        public int IPORRatingID { get; set; }
        public string IPORFileName { get; set; }

        public string LeaderName { get; set; }
        public string UserName { get; set; }
        public string ProjectChargeCode { get; set; }
        public int PaidInvoiceCount { get; set; }


    }
}