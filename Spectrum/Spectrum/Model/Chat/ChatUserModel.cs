using System;
using System.Collections.Generic;

namespace Spectrum.Model.Chat
{
    public class ChatUserModel
    {
        public string accountID { get; set; }
        public string userID { get; set; }
        public int planID { get; set; }
        public object password { get; set; }
        public string emailAddress { get; set; }
        public object companyName { get; set; }
        public object licenseKey { get; set; }
        public string userName { get; set; }
        public int id { get; set; }
        public bool active { get; set; }
        public object name { get; set; }
        public string userId { get; set; }
        public int createBy { get; set; }
        public string createdBy { get; set; }
        public DateTime creationDate { get; set; }
        public int lastModifiedBy { get; set; }
        public DateTime lastModificationDate { get; set; }


    }
}
