using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Spectrum.Model.ModelDataTypes.SpectrumFrameDataTypes;

namespace Spectrum.Model.ModelDataTypes
{
    public class TeamProfile : BaseEntity
    {
        public Guid AccountID { get; set; }
        public Guid CompanyID { get; set; }
        public string CompanyName { get; set; }
        public Guid? TeamLeaderID { get; set; }
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public bool Archive { get; set; }
        public bool IsDefault { get; set; }
        public bool IsProject_Based { get; set; }
        public bool OutSide_Based_Company { get; set; }
        public bool Team_As_Department { get; set; }
        public string ReturnMessage { get; set; }
        public ModuleNavLevelThreeItem ModuleNavLevelThreeItem { get; set; }
        public int ModuleID { get; set; }
        public int WorkScpaceID { get; set; }
        public CustomMessage customMessage = new CustomMessage();
        public string LeaderName { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string UserName { get; set; }
        public List<UserProfile2> UserList = new List<UserProfile2>();
        public List<UserProfile2> ResourceList = new List<UserProfile2>();
        public List<CompanyProfile> CompanyList = new List<CompanyProfile>();
        public List<TeamProfile> TeamProfileList = new List<TeamProfile>();
        public List<CommentProfile> CommentProfileList = new List<CommentProfile>();
    }
}
