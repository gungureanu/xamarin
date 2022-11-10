using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Spectrum.Model.ModelDataTypes
{
    public class ModuleProfile : BaseEntity
    {
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
        public string Description { get; set; }
        public string ModuleUrl { get; set; }
        public List<UserProfile> UserList { get; set; }

        public List<ModuleProfile> ModuleList { get; set; }
        public ModuleProfile()
        {
            UserList = new List<UserProfile>();
            ModuleList = new List<ModuleProfile>();
        }
    }
}
