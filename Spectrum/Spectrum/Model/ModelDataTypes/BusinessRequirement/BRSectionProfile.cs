using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Spectrum.Model.ModelDataTypes
{
    public class BRSectionProfile : BaseEntity
    {
        public Int64 BusinessRequirementsSectionID { get; set; }
        public Int64 BusinessRequirementCategoryID { get; set; }
        public string SectionName { get; set; }
        public string Description { get; set; }
        public Int32 Dorder { get; set; }
        public bool Active { get; set; }
        public List<BusinessRequirementProfile> BusinessRequirementProfile { get; set; }
        public BRSectionProfile()
        {
            BusinessRequirementProfile = new List<BusinessRequirementProfile>();
        }

    }
}
