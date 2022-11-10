using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
   public class ProjectPortfolio : BaseEntity
    {
        public Int64 ProjectPortfolioID { get; set; }
        public string PortfolioName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }

    public class StateFieldSettings : BaseEntity
    {
        public Int32 StateFieldControlID { get; set; }
        public string StateFieldControlName { get; set; }
        public string StateFieldControlFor { get; set; }
    }


}
