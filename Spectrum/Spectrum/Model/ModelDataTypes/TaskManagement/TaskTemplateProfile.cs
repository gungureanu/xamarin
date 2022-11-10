using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
   public class TaskTemplateProfile : BaseEntity
    {
        public Int64 TaskTemplateID { get; set; }        
        public string TaskTemplateName { get; set; }
        public string Description { get; set; }
        public Int64 LanguageID { get; set; }
        public bool Active { get; set; }

    }
}
