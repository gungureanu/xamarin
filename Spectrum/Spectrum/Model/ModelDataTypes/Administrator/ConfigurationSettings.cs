using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class ConfigurationSettings:BaseEntity
    {
        public Int32 SettingID { get; set;}
        public string SettingName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string NavigationSetting { get; set; }
    }
}
