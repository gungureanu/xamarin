using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class InvitedUserAccountProfile 
    {
        public Guid UserID { get; set; }
        public Guid InvitationCode { get; set; }
        public Guid CompanyID { get; set; }
        public Guid AccountID { get; set; }
        public int GroupID { get; set; }
        public string CompanyName { get; set; }
        public string FromEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FromFirstName { get; set; }
        public string FromLastName { get; set; }
        public string Gender { get; set; }
        public string ToEmail { get; set; }
        public DateTime CreatedDate { get; set; }        
        public string ReturnMessage { get; set; }
        public string LicenseKey { get; set; }
        public string SendStatus { get; set; }
        public Int32 CompanyTypeID { get; set; }        
        public Int32 IndustryID { get; set; }
        public List<UserAccountProfile> AvailableCompanyType { get; set; }
        public List<UserAccountProfile> AvailableIndustry { get; set; }
        public CustomMessage CustomMessage { get; set; }
        public int WorkspaceID { get; set; }
        public int ModuleID { get; set; }
        public long InvitationID { get; set; }
    }
}
