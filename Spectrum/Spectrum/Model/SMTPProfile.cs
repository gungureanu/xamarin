using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model
{
    public class SMTPProfile : BaseEntity
    {
        public Int32 SMTPId { get; set; }
        public string SMTPServer { get; set; }
        public Int32 SMTPPort { get; set; }
        public bool SSLEnable { get; set; }
        public string SenderEmail { get; set; }
        public string SenderPassword { get; set; }
    }
}
