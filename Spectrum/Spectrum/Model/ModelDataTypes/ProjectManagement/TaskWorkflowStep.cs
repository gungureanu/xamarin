using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class TaskWorkflowStep
    {
        public Int64 WorkflowStepID { get; set; }
        public Int64 WorkflowResolutionID { get; set; }
        public int WorkflowStepNo { get; set; }
        public string WorkFlowStepName { get; set; }
        public string ResolutionName { get; set; }
        public string ColorCode { get; set; }
        public int WorkflowActionID { get; set; }
        public string WorkflowActionName { get; set; }
        public List<WorkflowActions> WorkflowActionList { get; set; }
    }
}
