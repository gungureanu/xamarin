using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
   public class EventWebJobDetails
    {
        public Guid AccountID { get; set; }
        public string SenderEmail { get; set;}
        public string SenderPassword { get; set; }
        public string Subject { get; set; }
        public string BodyHeading { get; set; }
        public string UpdatedBody { get; set; }
        public bool SSLEnable { get; set; }
        public string SMTPServer { get; set; }
        public Int32 SMTPPort { get; set; }
        public string ReceiverEmail { get; set; }
        public Int64 EventWebJobID { get; set; }
        public string RecordID { get; set; }
        public Int32 IsAttachment { get; set; }
        public string FilePath { get; set; } 
        public bool IsEmailList { get; set; }
}
}
