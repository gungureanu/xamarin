using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Spectrum.Model.ModelDataTypes
{
    public class LangaugeProfile : BaseEntity
    {
        public Int32 LanguageID { get; set; }
        public string LanguageName { get; set; }
        public string Description { get; set; }
        public string SortOrder { get; set; }
        public bool Active { get; set; }
    }
}
