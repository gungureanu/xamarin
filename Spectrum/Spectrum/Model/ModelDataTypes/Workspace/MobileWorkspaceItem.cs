using System;
using System.Collections.Generic;


namespace Spectrum.Model.ModelDataTypes
{
    public class MobileWorkspaceItem
    {
        public Guid AccountID { get; set; }
        public Guid CompanyID { get; set; }

        public int WorkSpaceID { get; set; }
        public string WorkspaceName { get; set; }
        public string WorkspaceDescription { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDefault { get; set; }
    }

}
