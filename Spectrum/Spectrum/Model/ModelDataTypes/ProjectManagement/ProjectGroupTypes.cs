using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class ProjectGroupTypes : BaseEntity
    {
        public Guid AccountID { get; set; }
        public Guid CompanyID { get; set; }
        public Guid UserID { get; set; }
        public int WorkspaceID { get; set; }
        public Int64 ProjectID { get; set; }
        public int ModuleID { get; set; }
        public string RoleIDList { get; set; }
        public string IsSpecialLogin { get; set; }
        public bool IsCommandAdmin { get; set; }
        public int TeamID { get; set; }        
        public int GroupID { get; set; }
        public Int64 GroupTypeID { get; set; }
        public string GroupTypeName { get; set; }
        public Int64 GroupTypeParentID { get; set; }
        public string GroupTypeParentName { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public int CountGroutType { get; set; }
        public Int64 LanguageID { get; set; }
        public bool Active { get; set; }
        public string UserInGroup { get; set; }
        public int PageNo { get; set; }
        public List<ProjectTaskDetailProfile> TaskList { get; set; }
    }

    public class ProjectIPORRating : BaseEntity
    {
        public int IPORID { get; set; }
        public string IPORName { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public bool Active { get; set; }

    }
}
