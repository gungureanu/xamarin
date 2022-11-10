using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class TaskInbox
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string WorkflowStepName { get; set; }
        public string ReportingUserImg { get; set; }
        public string AssignedUserImg { get; set; }
        public string ReportingUserName { get; set; }
        public string Pending { get; set; }    
        public int HaveDocument { get; set; }
        public DateTime DueDate { get; set; }
        public string PendingStatus { get; set; }
        public string InprogressStatus { get; set; }
        public string TestingStatus { get; set; }
        public string DoneStatus { get; set; }
        public string PendingColorCode { get; set; }
        public string InprogressColorCode { get; set; }
        public string TestingColorCode { get; set; }
        public string DoneColorCode { get; set; }
        public int WorkflowStepID { get; set; }
        public string PriorityName { get; set; }
        public int IsRead { get; set; }
        public string ManagerActiveStatus { get; set; }
        public string AssignedUserActiveStatus { get; set; }
        public Guid AssignedUserID { get; set; }
        public string AssignedUserName { get; set; }
        public string TaskKey { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string BackgroundColorCode { get; set; }
        public string ImagePath { get; set; }
        public string FileName { get; set; }
        public int CommentsCount { get; set; }
        public bool IsCompelted { get; set; }
        public bool IsOverDue { get; set; }
    }
}
