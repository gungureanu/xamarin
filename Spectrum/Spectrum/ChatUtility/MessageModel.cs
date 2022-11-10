using System;
namespace Spectrum.ChatUtility
{
    public class MessageModel
    {
        public string UserName { get; set; }
        public string MessageText { get; set; }
        public string MessageTime { get; set; }
        public bool IsOwnMessage { get; set; }
        public bool IsOtherMessage { get; set; }
        public bool IsSystemMessage { get; set; }
        public string UserID { get; set; }
        public string AccountID { get; set; }
        public string WorkSpaceID { get; set; }
        public string UserImage { get; set; }
    }
}
