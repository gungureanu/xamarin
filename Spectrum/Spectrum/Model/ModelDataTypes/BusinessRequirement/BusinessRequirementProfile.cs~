using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
namespace Spectrum.Model.ModelDataTypes
{
    public class BusinessRequirementProfile : BaseEntity
    {
        public Int64 BusinessRequirementID { get; set; }
        public Int64 BusinessRequirementsSectionID { get; set; }
        public Int64 BusinessRequiremntParentID { get; set; }
        public string BusinessRequirement { get; set; }
        public string Description { get; set; }
        public Int32 Dorder { get; set; }
        public bool Active { get; set; }

        public Int64 EstWorkHours { get; set; }
        public Int64 Status { get; set; }

        public string StatusText { get; set; }

        //==PROPERTY ONLY USED FOR EDITING PURPOSES

        public string SectionName { get; set; }

        public Int64 BusinessRequirementCategoryID { get; set; }

        public string CategoryName { get; set; }
        public Guid? ProjectAssigneeID { get; set; }

        public string ProjectAssigneeName { get; set; }

        public string ProjectAssigneeImageName { get; set; }
        public Int64 BusinessRequirementTypeID { get; set; }

        public string BusinessRequirementTypeName { get; set; }

        public string ReturnMessage { get; set; }

        public List<BRCommentProfile> BusinessRequirementCommentProfile { get; set; }

        public List<BusinessRequirementProfile> BusinessRequirementChildList { get; set; }

        public List<ProjectTaskDetailProfile> ProjectTaskDetailProfileList { get; set; }

        public string ReadStatus { get; set; }
        public int IndentPadding { get; set; }

        public int Level { get; set; }

        public BusinessRequirementProfile()
        {
            BusinessRequirementChildList = new List<BusinessRequirementProfile>();
            BusinessRequirementCommentProfile = new List<BRCommentProfile>();
            ProjectTaskDetailProfileList = new List<ProjectTaskDetailProfile>();
        }
        public int HaveTask { get; set; }
    }
}
