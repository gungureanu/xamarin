using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes.Reports
{
    public class ProjectTaskReportSummary
    {
        public Int64 ProjectID { get; set; }
        public string ProjectName { get; set; }
        public Guid ProjectManagerID { get; set; }
        public string ProjectManagerName { get; set; }
        public decimal Budget { get; set; }
        public decimal Cost { get; set; }
        public string PlannedStartDate { get; set; }
        public string PlannedFinishDate { get; set; }
        public string Scheduled { get; set; }
        public string Workloads { get; set; }
        public string ReportRunDate { get; set; }
    }
}
