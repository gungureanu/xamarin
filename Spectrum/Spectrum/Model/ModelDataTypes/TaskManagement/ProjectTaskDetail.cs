using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes.TaskManagement
{
    public class ProjectTaskDetail : BaseEntityOptional
    {

        public Int64 TaskID { get; set; }

        public string TaskName { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public decimal EstimateHoursOriginal { get; set; }

        public decimal EstimateHoursCompleted { get; set; }

        public string WorkflowStepName { get; set; }

        public string ProjectAssignName { get; set; }


        public decimal EstimateHoursRemaining { get; set; }

        public decimal? RemainingHourPercentage { get; set; }

        public Guid? AssignedToID { get; set; }

        public string ProjectAssignImage { get; set; }

        public string ImagePath { get; set; }

        public DateTime? DueDate { get; set; }
        public Int64 TaskStatusID { get; set; }
        public int DisplayOrder { get; set; }

        public string TaskStatus { get; set; }
        public string ColorCode { get; set; }
        public string ReadStatus { get; set; }
        public string TaskPrefixKey { get; set; }
        public string Status { get; set; }


        public Int64 ActivityDurationInSecond { get; set; }


        public string IssueTypeName { get; set; }

        public int CountSubTask { get; set; }
        public string FileName { get; set; }
        public string DateFormatName { get; set; }
        public bool IsTaskAssigned { get; set; }
        public decimal PercentageDone { get; set; }
        public string PriorityColorCode { get; set; }
        public string TypeName { get; set; }
        public int TotalTaskCount { get; set; }
        public Guid? TaskOwnerID { get; set; }
        public string TaskOwnerName { get; set; }
        public string TaskDateName { get; set; }
        public string TaskTimeName { get; set; }
        public string MainListName { get; set; }
        public bool IsMainListVisible { get; set; }
        public double MainListHeight { get; set; }
        public string FullTaskName { get; set; }
        public bool IsRead { get; set; }
        public bool HasAttachment { get; set; }

    }
}