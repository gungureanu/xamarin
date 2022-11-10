using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.ChatUtility
{
    public class Participant
    {
        public Guid AccountID { get; set; }
        public int WorkspaceID { get; set; }
        public Guid UserID { get; set; }
        public string ConnectionID { get; set; }

    }
}
