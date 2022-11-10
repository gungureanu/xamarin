using System;
using System.Collections.Generic;

namespace Spectrum.Model.Chat
{
    public class ChatDashboardSectionModel
    {
        public int SectionID { get; set; }
        public string SectionName { get; set; }
        public string SectionDisplayName { get; set; }
        public string AccountID { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        public int WorkSpaceID { get; set; }
        public int ModuleID { get; set; }
    }
}
