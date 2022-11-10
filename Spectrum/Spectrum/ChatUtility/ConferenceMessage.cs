using System;
using System.Collections.Generic;
namespace Spectrum.ChatUtility
{
    public class ConferenceMessage
    {
        public Guid AccountID { get; set; }
        public int WorkspaceID { get; set; }
        public int ModuleID { get; set; }
        public Guid UserID { get; set; }
        public Guid ToUserID { get; set; }
        public string ConnectionID { get; set; }
        public int ConferenceID { get; set; }
        public int LastConferenceID { get; set; }
        public string ToConnectionID { get; set; }
        public string FromUserName { get; set; }
        public Int64 FileID { get; set; }
        public string ProfileImage { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Message { get; set; }
        public DateTime MessageDateTime { get; set; }

        //public List<Participant> ParticipantList { get; set; }
        public List<ConferenceMessage> ConferenceMessageList { get; set; }

        public ConferenceMessage()
        {
            ConferenceMessageList = new List<ConferenceMessage>();
            //ParticipantList = new List<Participant>();
        }
    }
}
