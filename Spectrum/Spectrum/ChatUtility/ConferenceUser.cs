using System;
namespace Spectrum.ChatUtility
{
    public class ConferenceUser
    {
        public Guid AccountID { get; set; }
        public int WorkspaceID { get; set; }
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public int ConferenceCallID { get; set; }
        public string ProfilePath { get; set; }
        public string ConnectionId { get; set; }
        public bool InCall { get; set; }
        public bool IsVideoEnable { get; set; }
        public string RoomID { get; set; }
    }
}
