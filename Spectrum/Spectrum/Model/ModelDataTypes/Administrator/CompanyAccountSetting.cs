using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    class CompanyAccountSetting
    {
        public List<UserProfile> UserList { get; set; }
        public List<CompanyProfile> CompanyList { get; set; }
        public List<LangaugeProfile> LanguageList { get; set; }
        public List<TimeZoneProfile> TimeZoneList { get; set; }
        public List<DateFormat> DateFormatList { get; set; }
    }
}
