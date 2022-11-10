using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
   public class TaskTypeCategoryProfile
    {
        public Int64 TaskTypeCategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }
        public bool Active { get; set; }        
        public List<TaskTypeProfile> TaskTypeList { get; set; }

        public TaskTypeCategoryProfile()
        {
            TaskTypeList= new List<TaskTypeProfile>();
        }

    }
}
