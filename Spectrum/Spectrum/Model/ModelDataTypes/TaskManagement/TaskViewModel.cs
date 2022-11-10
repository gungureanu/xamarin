using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
   public class TaskViewModel
    {
        public List<ProjectTaskDetailProfile> TaskList { get; set; }
        public List<ProgressBar> ProgressBarList { get; set; }
        public List<ModuleProjectsGroups> ModuleProjectsGroups { get; set; }
        public List<ModuleNavRightSide> ModuleNavRightSide { get; set; }
        public int TotalUsers { get; set; }
        public decimal PercentageDone { get; set; }
        public GroupItemDetail GroupItemDetail = new GroupItemDetail();
    }
}
