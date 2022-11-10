using System;
namespace Spectrum.Model.ModelDataTypes.ProjectManagement
{
    public class ProjectModelMobile
    {
        public Guid AccountID { get; set; }
        public string isSpecialLogin { get; set; }
        public int WorkSpaceID { get; set; }
        public Guid CompanyID { get; set; }
        public int TeamID { get; set; }
        public string ProjectName { get; set; }
        public int ProjectTypeID { get; set; }
        public int ProjectTypeCategoryID { get; set; }

        public Guid ProjectManagerID { get; set; }
        public int ProjectStatusID { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectKey { get; set; }
        public int NextTaskNumber { get; set; }

        public Guid CreatedBy { get; set; }
    }
}
