using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class TeamWorkHourSummary
    {
        public string TodayHour { get; set; }
        public string YesterDayHour { get; set; }
        public string CurrentMonth { get; set; }
        public string LastMonth { get; set; }
    }
}
