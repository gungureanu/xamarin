using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class WorkflowProfile : BaseEntity
    {
        public bool IsDefaultWorkflow { get; set; }
        public Int64 WorkflowID { get; set; }                       
        public Guid AccountID { get; set; }
        public Int64 ProjectID { get; set; }
        public int WorkflowGroupID { get; set; }
        public string WorkflowName { get; set; }
        public string WorkflowDescription { get; set; }
        public int SortOrder { get; set; }
        public bool Active { get; set; }
        public int ActiveWF { get; set; }
        public int ModuleID { get; set; }

        public List<WorkFlowStep> WorkflowStepList = new List<WorkFlowStep>();
        public List<WorkFlowGroup> workFlowGroupList = new List<WorkFlowGroup>();
        public List<WorkflowProfile> WorkflowProfileList = new List<WorkflowProfile>();
        public List<WorkflowComments> WorkflowCommentsList = new List<WorkflowComments>();
        public List<ModuleNavRightSide> ModuleNavRightSide = new List<ModuleNavRightSide>();
    }
}
