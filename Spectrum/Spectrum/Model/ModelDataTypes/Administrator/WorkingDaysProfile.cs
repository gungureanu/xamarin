using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Spectrum.Model.ModelDataTypes
{
    public class WorkingDaysProfile 
    {
        public Int64 WorkingDaysID { get; set; }
        public string WorkDaysName { get; set; }
        public string Description { get; set; }
        public string SortOrder { get; set; }
        public bool Active { get; set; }
    }
}
