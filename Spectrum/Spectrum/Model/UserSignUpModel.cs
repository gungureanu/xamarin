using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model
{
    public class UserSignUpModel : BaseEntity
    {
        public string EmailID { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string UserIPAddress { get; set; }
        public int PlanID { get; set; }
        public string ReturnMessage { get; set; }

    }
}
