
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Spectrum.Model.ModelDataTypes
{
    public class BRCategoryProfile : BaseEntity
    {
        public Int64 BusinessRequirementCategoryId { get; set; }
        public Guid CompanyId { get; set; }
        public Int64 ProjectId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public Int32? CategoryParentId { get; set; }
        public Int32 Dorder { get; set; }
        public Int32 NoofReqirements { get; set; }
        public  Int32 TotalRequirement { get; set; }
        public bool Active { get; set; }
        public List<BRCategoryProfile> BusinessSubCategoryProfile { get; set; }
        public List<BRSectionProfile> BusinessRequirementSectionProfile { get; set; }
        public List<TaskTypeProfile> TaskTypeProfile { get; set; }
        public List<BusinessRequirementProfile> BusinessRequirementType { get; set; }
        public IEnumerable<UserProfile> UserProfileList { get; set; }
        public List<BRWBSTaskCommentProfile> BRCommentProfile { get; set; }
        public ProjectTaskDetailProfile ProjectTaskDetailProfile { get; set; }
        public ProjectListProfile projectDetails { get; set; }
        public List<int> BRSnapshot { get; set; }        

        public List<ProjectStatusProfile> ProjectStatusProfiles  { get; set; }
        public List<ProjectTemplateProfile> ProjectTemplateProfile { get; set; }
        public IEnumerable<ProjectListProfile> ProjectListProfiles { get; set; }
        public List<TaskPriorityProfile> TaskPriorityProfiles { get; set; }

        public List<TaskTypeCategoryProfile> TaskTypeCategoryProfile { get; set; }
        public List<ModuleNavRightSide> ModuleNavRightSide { get; set; }


        public BRCategoryProfile()
        {
            BusinessSubCategoryProfile = new List<BRCategoryProfile>();
            BusinessRequirementSectionProfile = new List<BRSectionProfile>();
            TaskTypeProfile = new List<TaskTypeProfile>();
            BusinessRequirementType = new List<BusinessRequirementProfile>();
            UserProfileList = new List<UserProfile>();
            BRSnapshot = new List<int>();
            ProjectStatusProfiles = new List<ProjectStatusProfile>();
            ProjectTemplateProfile = new List<ProjectTemplateProfile>();
            ProjectListProfiles = new List<ProjectListProfile>();
            TaskPriorityProfiles = new List<TaskPriorityProfile>();
            TaskTypeCategoryProfile = new List<TaskTypeCategoryProfile>();
        }

    }
}
