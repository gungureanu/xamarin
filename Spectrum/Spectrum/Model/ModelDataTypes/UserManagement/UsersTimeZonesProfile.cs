using System;
using System.Collections.Generic;
using System.Text;
namespace Spectrum.Model.ModelDataTypes
{
    public class UsersTimeZonesProfile : BaseEntityOptional
    {
        public Int64 TimeZoneSettingID { get; set; }
        public Guid UserID { get; set; }
        public int TimezoneID { get; set; }
        public bool enabled { get; set; }
        public bool DayLightSavingEnabled { get; set; }
    }
}