using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
   public class HelpText : BaseEntity
    {
        public  int HelpTextID { get; set; }
        public int LanguageID { get; set; }
        public string HelpTextEventName { get; set; }
        public string MainHeading { get; set; }
        public string SubHeading { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string FilePath { get; set; }
    }
}
