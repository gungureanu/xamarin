using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class WorkflowResolution
    {
        public int WorkflowResolutionID { get; set; }
        public int WorkflowGroupID { get; set; }
        public string ResolutionName { get; set; }
        public string ColorCode { get; set; }
        public string BackgroundColorCode { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool Active { get; set; }
    }
}
