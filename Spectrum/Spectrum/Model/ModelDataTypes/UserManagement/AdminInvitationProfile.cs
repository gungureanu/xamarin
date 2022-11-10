using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes.UserManagement
{
    public class AdminInvitationProfile : BaseEntity
    {
        public Int64 InvitationRequestID { get; set; }
        public Guid InvitationCode { get; set; }
        public Guid AccountID { get; set; }
        public Guid CompanyID { get; set; }
        public string FromEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RequestStatus { get; set; }
        public string ReturnMessage { get; set; }
        public DateTime CreatedDate { get; set; }
        public CustomMessage CustomMessage { get; set; }

    }
}
