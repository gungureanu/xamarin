
using System;
using System.Collections.Generic;
using System.Text;
namespace Spectrum.Model.ModelDataTypes
{
    public class UserAccountSettingProfile : BaseEntityOptional
    {
        public Int64 AccountSettingID { get; set; }
        public Guid UserID { get; set; }
        public string SessionLifeTime { get; set; }
        public string AccountLifeTime { get; set; }
        public string AccountInActivityTime { get; set; }
        public string WarningTimeInActivity { get; set; }
        public bool RememberMe { get; set; }
        public bool ForgotPassword { get; set; }
        public bool AddUserAccount { get; set; }
        public bool AddSecurityGroup { get; set; }
        public string HoursFormat { get; set; }
        public string LoggedTimeBy { get; set; }
        public string DisplayComments { get; set; }
        public string NumberAlignment { get; set; }
        public bool UserTracking { get; set; }
        public bool ScreenShotAuditing { get; set; }
        public bool StrictSecurityMeasure { get; set; }
        public string ReportTrackingResultsUserId { get; set; }
        public Guid ReportTrackingUserId { get; set; }
    }
}
