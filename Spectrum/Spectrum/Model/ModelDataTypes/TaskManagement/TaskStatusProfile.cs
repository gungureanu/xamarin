using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
   public class TaskStatusProfile
    {
        public Int64 TaskStatusID { get; set; }
        public string TaskStatus { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        
    }
}
