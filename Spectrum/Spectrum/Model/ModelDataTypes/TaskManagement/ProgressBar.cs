using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class ProgressBar
    {
        public Guid UserID { get; set; }
        public Int64 TaskID { get; set; }
        public Int32 GroupID { get; set; }
        public Int64 ProjectID { get; set; }
        public int ResolutionID { get; set; }
        public int TotalTimeConsumed { get; set; }
        public decimal TotalPercentage { get; set; }
        public  decimal EstimateHoursOriginal { get; set; }
        public string ResolutionName { get; set; }
        public string ColorCode { get; set; }
        public string displayTotalTime { get; set; }
    }
}
