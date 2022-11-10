using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class UserGroup
    {
        public UserGroup() {
            UserGroupList = new List<UserGroup>();
        }
        public int CompanyID { get; set; }
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public int InviteUserDisplayOrder { get; set; }
        public int ParentID { get; set; }
        public bool IsAccessabletoEndUser { get; set; }
        public List<UserGroup> UserGroupList { get; set; }
        public string FileName { get; set; }
        public string IconAltText { get; set; }
    }
}
