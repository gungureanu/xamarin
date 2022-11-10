using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model
{
    public class UserModel : BaseEntity
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string UserIPAddress { get; set; }
    }
}
