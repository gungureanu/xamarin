using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class WorkFlowGroup
    {
        public WorkFlowGroup()
        {
            WorkflowProfilesList = new List<WorkflowProfile>();
        }
        public int WorkflowGroupID { get; set; }
        public int AccountID { get; set; }
        public Int64 ProjectID { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public int SortOrder { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Int64 CreatedBy { get; set; }
        public Int64 LastUpdatedBy { get; set; }
        public List<WorkflowProfile> WorkflowProfilesList { get; set; }
    }
}
