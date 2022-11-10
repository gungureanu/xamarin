using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
   public class TaskTypeProfile : BaseEntity
    {
        public Int64 TaskTypeID { get; set; }
        public Int64 IconID { get; set; }
        public Int64 TaskTypeCategoryID { get; set; }
        public string FileName { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public bool IsBillable { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal CurHourlyRate { get; set; }
        public string ActivateClass { get; set; }
        public bool IsActivate { get; set; }
    }
}
