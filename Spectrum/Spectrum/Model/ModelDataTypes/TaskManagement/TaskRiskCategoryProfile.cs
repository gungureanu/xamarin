using System;
using System.Collections.Generic;
using System.Text;
namespace Spectrum.Model.ModelDataTypes
{
  public  class TaskRiskCategoryProfile
    {
        public Int64 TaskRiskCategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }
        public bool Active { get; set; }


    }
}
