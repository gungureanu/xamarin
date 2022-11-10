using System;
using System.Collections.Generic;
using System.Text;
using Spectrum.Model.ModelDataTypes;

namespace Spectrum.Model
{
    public class SubscriptionAccounts
    {
        public Guid AccountID { get; set; }
        public Guid UserID { get; set; }
        public int PlanID { get; set; }
        public string Account_Display_ID { get; set; }
        public Guid Primary_Company_ID { get; set; }
        public string PlanCssClassName { get; set; }
        public int Session_Lifetime { get; set; }
        public int Default_Account_Lifetime { get; set; }
        public int Stop_Timer_Activity_Time { get; set; }
        public int Warning_Time { get; set; }
        public bool Warnme_When_Leaving { get; set; }
        public bool Warnme_When_SessionExp { get; set; }
        public int Hour_Format { get; set; }
        public int Logged_Time { get; set; }
        public int Number_Alignment { get; set; }
        public int Display_Comment { get; set; }
        public bool Enable_TrackService { get; set; }
        public bool Enable_Screenshot_Auditing_Service { get; set; }
        public int PayPalID { get; set; }
        public int LanguageID { get; set; }
        public int TimeZoneID { get; set; }
        public int DateFormatID { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid LastUpdatedBy { get; set; }
        public Guid CompanyID { get; set; }

        public List<UserProfileMob> UserList { get; set; }
        //public List<CompanyProfile> CompanyList { get; set; }
        //public List<SubscriptionsAccountSettings> AccountSettingList { get; set; }

        //public List<LangaugeProfile> LanguageList { get; set; }
        //public List<TimeZoneProfile> TimeZoneList { get; set; }

        //public List<DateFormat> DateFormatList { get; set; }
        public string AuthenticateByIP { get; set; }
        public string KhameliaIntent { get; set; }
        public bool IsSubscriptionTrailMode { get; set; }
        public DateTime TrialStartDate { get; set; }
        public DateTime TrialEndDate { get; set; }
        public SubscriptionAccounts()
        {
            UserList = new List<UserProfileMob>();
            //CompanyList = new List<CompanyProfile>();
            //AccountSettingList = new List<SubscriptionsAccountSettings>();
            //LanguageList = new List<LangaugeProfile>();
            //TimeZoneList = new List<TimeZoneProfile>();
            //DateFormatList = new List<DateFormat>();

        }

    }
}
