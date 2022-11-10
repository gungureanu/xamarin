using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class ProjectMilestone
    {
        public Int32 MilestoneID { get; set; }
        public Int64 ProjectID { get; set; }
        public string MilestoneName { get; set; }
        public bool Active { get; set; }    
        public int TotalAction { get; set; }

    }
}
