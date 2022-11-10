using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class InAndOutBoard
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyPositionTitle { get; set; }
        public string ImageName { get; set; }
        public string ActiveStatus { get; set; }
        public DateTime ClockInNow { get; set; }
        public string BreakOut1 { get; set; }
        public string Lunch { get; set; }
        public string BreakOut2 { get; set; }
        public DateTime ClockOut { get; set; }
        public string RegularHours { get; set; }
        public string OvertimeHours { get; set; }
        public Boolean IsClockOut { get; set; }
        public string BreakStatus { get; set; }
        public int BreakConsumedTime { get; set; }
        public string TimerRunning { get; set; }
        public Boolean IsInBreak { get; set; }
        public int RegularHoursInSecond { get; set; }
        public int OvertimeInSecond { get; set; }
        public string ImagePath { get; set; }
        public decimal AveragePercentHours { get; set; }
        public int OverTimeMinutes { get; set; }
    }
}
