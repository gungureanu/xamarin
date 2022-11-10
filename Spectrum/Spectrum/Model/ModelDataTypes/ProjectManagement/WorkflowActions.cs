using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class WorkflowActions
    {
        public Int64 WorkflowActionID { get; set; }
        public int WorkflowStepID { get; set; }
        public string WorkflowActionName { get; set; }
        public string WorkflowActionDescription { get; set; }
        public int ActionRedirectWorkflowStep { get; set; }
        public string ActionRedirectWorkflowStepName { get; set; }
        public Guid ActionAssignedTo { get; set; }
        public Guid ActionAutoResponder { get; set; }
        public Guid ActionEscalation { get; set; }
        public bool Active { get; set; }
        public Guid UserID { get; set; }
        public Guid AccountID { get; set; }
        public int ModuleID { get; set; }
        public string ModifiedDate { get; set; }
        public string UserName { get; set; }
        public Guid LastUpdatedBy { get; set; }
        public string ReturnMessage { get; set; }
        public CustomMessage CustomMessage = new CustomMessage();
        public int LanguageID { get; set; }
    }
}
