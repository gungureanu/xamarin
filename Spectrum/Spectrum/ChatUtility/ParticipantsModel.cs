using System;
namespace Spectrum.ChatUtility
{
    public class ParticipantsModel
    {
        public Guid UserID { get; set; }
        public Guid AccountID { get; set; }
        public Int32 WorkSpaceID { get; set; }
        public string UserName { get; set; }
        public string ProfilePath { get; set; }
        public string ConnectionId { get; set; }
    }
}
