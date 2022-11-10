using System;
using System.Collections.Generic;


namespace Spectrum.Model.ModelDataTypes
{
    public class MobileTeamProfile
    {
        public Guid AccountID { get; set; }
        public Guid CompanyID { get; set; }
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public int WorkScpaceID { get; set; }
        public List<MobileProjectListProfile> lstProject { get; set; }
        public MobileTeamProfile()
        {
            lstProject = new List<MobileProjectListProfile>();
        }
    }
}
