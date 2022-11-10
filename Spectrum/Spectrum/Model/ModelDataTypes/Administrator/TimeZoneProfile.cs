using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Spectrum.Model.ModelDataTypes
{
    public class TimeZoneProfile : BaseEntity
    {
        public int TimezoneID { get; set; }
        public string Abbreviation { get; set; }
        public string TimezoneName { get; set; }
        public string Location { get; set; }
        public string UTCoffset { get; set; }        
        public bool Active { get; set; }    
        //ADDED THIS FIELD FOR DISPLAY SELECT TIMEZONE
        public bool SelectUser { get; set; }
        public bool DayLightSavingEnabled { get; set; }
        public char FirstCharOFTimezoneName { get; set; }
        public DateTime UTCDate { get; set; }
    }
}
