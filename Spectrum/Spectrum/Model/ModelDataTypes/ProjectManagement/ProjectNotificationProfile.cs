using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class ProjectNotificationProfile : BaseEntity
    {
        public Guid AccountID { get; set; }
        public int WorkspaceID { get; set; }
        public Int64 ProjectID { get; set; }
        public int ModuleID { get; set; }
        public int ProjectNotificationID { get; set; }
        public string RuleDescriptionPart1 { get; set; }
        public string RuleDescriptionPart2 { get; set; }
        public decimal ProjectNotificationValue { get; set; }
        public Int64 LanguageID { get; set; }
        public bool Active { get; set; }                
        public bool IsAllow { get; set; }

    }
}
