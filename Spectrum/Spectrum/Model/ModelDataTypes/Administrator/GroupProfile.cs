using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Spectrum.Model.ModelDataTypes
{
    public class GroupProfile : BaseEntity
    {
        public GroupProfile()
        {
            UserGroupList = new List<UserGroup>();
        }
        public Guid CompanyID { get; set; }
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public bool IsSelected { get; set; }
        public string FileName { get; set; }
        public int ParentID { get; set; }
        public List<UserGroup> UserGroupList { get; set; }
        public List<GroupProfile> ChildGroupList = new List<GroupProfile>();
        public string IconAltText { get; set; }

    }
}
