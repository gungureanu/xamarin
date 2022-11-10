using System;
using System.Collections.Generic;
using Spectrum.Model.Chat;

namespace Spectrum.Model.ModelDataTypes
{
    public class MobileWorkSpaceViewModel
    {
        public List<MobileWorkspaceItem> lstWorkSpaces { get; set; }
        public List<MobileTeamProfile> lstTeams { get; set; }


        public MobileWorkSpaceViewModel()
        {
            lstWorkSpaces = new List<MobileWorkspaceItem>();
            lstTeams = new List<MobileTeamProfile>();
        }
    }
}
