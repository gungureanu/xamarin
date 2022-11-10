using System;
namespace Spectrum.Model.Chat
{
    public partial class ChatTeamsModel
    {
        public string accountID { get; set; }
        public string companyID { get; set; }
        public object companyName { get; set; }
        public object teamLeaderID { get; set; }
        public int teamID { get; set; }
        public string teamName { get; set; }
        public string description { get; set; }
        public string leaderName { get; set; }
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
