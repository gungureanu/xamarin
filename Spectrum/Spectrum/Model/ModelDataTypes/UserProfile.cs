using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class UserProfile : BaseEntity
    {
        public Guid AccountID { get; set; }
        public Guid UserID { get; set; }
        public int PlanID { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string CompanyName { get; set; }
        public string LicenseKey { get; set; }
        public string UserName { get; set; }
    }
}
