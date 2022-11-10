using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
   public class ProjectUserPermissionProfile : BaseEntity
    {
        public Guid AccountID { get; set; }
        public int WorkspaceID { get; set; }
        public Int64 ProjectID { get; set; }
        public int GroupStatusID { get; set; }
        public bool IsAllow { get; set; }
        public Int64 LanguageID { get; set; }
        public bool Active { get; set; }
        public int ModuleID { get; set; }
        public string Column { get; set; }
        public int Value { get; set; }
        public int RoleID { get; set; }
        public bool IsResource { get; set; }

    }
}
