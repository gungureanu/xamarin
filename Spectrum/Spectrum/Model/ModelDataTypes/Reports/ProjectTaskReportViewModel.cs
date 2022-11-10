using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes.Reports
{
    public class ProjectTaskReportViewModel
    {
        public ProjectTaskReportSummary projectTaskSummary { get; set; }
        public List<ProjectTaskReportDetail> projectTaskDetail { get; set; }

        public ProjectTaskReportViewModel()
        {
            projectTaskSummary = new ProjectTaskReportSummary();
            projectTaskDetail = new List<ProjectTaskReportDetail>();
        }
    }
}
