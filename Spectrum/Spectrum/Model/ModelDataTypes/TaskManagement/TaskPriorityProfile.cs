using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
   public class TaskPriorityProfile : BaseEntity
    {
        public Guid AccountID { get; set; }
        public int ModuleID { get; set; }
        public Int64 ProjectID { get; set; }
        public Int64 PriorityID { get; set; }
        public int LanguageID { get; set; }
        public string PriorityName { get; set; }
        public string Description { get; set; }        
        public bool Active { get; set; }
        public string ColorCode { get; set; }
        public string ReturnMessage { get; set; }
        public CustomMessage CustomMessageItem { get; set; }
    }
}
