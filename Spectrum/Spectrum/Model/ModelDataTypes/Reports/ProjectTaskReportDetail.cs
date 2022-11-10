using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes.Reports
{
    public class ProjectTaskReportDetail
    {
        public Int64 TaskID { get; set; }
        public Int64 ProjectID { get; set; }
        public string TaskKey { get; set; }
        public string TaskName { get; set; }
        public string PlannedFinishDate { get; set; }
        public decimal PlannedEffort { get; set; }
        public decimal TotalHoursWorked { get; set; }
        public decimal Cost { get; set; }
        public decimal PercentageComplete { get; set; }
        public Guid AssignedToID { get; set; }
        public string AssignedToName { get; set; }
    }
}
