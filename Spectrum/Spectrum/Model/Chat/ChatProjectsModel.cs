using System;
namespace Spectrum.Model.Chat
{
    public partial class ChatProjectsModel
    {
        public int projectID { get; set; }
        public string companyID { get; set; }
        public string accountID { get; set; }
        public int workSpaceID { get; set; }
        public int moduleID { get; set; }
        public string companyName { get; set; }
        public string projectName { get; set; }
        public object description { get; set; }
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
