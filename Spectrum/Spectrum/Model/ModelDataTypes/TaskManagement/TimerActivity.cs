using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class TimerActivity
    {
        public Int64 TaskTimerID { get; set; }
        public Guid UserID { get; set; }
        public Int64 TaskID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
        public string LastActivityStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid LastUpdatedBy { get; set; }
        public Int64 ActivityDurationInSecond { get; set; }
        public decimal EstimateHoursCompleted { get; set; }
        public Int64 CurrentDaySecond { get; set; }
        public Int64 CurrentWeekSecond { get; set; }
        public Int64 CurrentMonthSecond { get; set; }
        public string DayName { get; set; }
        public Int64 ElapsedSecond { get; set; }
    }
}
