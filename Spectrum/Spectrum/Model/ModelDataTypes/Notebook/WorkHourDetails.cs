using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class WorkHourDetails
    {
        public Guid UserID { get; set; }
        public DateTime StartTime { get; set; }
        public decimal StartFromInPX { get; set; }
        public decimal StartFromInPXMain { get; set; }
        public int ActivityDurationInSecond { get; set; }
        public decimal HourCellInPX { get; set; }
        public string Status { get; set; }
        public bool IsOverTime { get; set; }
        public bool IsExtraTime { get; set; }
    }
}
