using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes.SpectrumInvoice
{
   public class CustomerMesssage
    {
        public Int32 MessageTypeID { get; set; }
        public string Message { get; set; }
        public Guid AccountID { get; set; }
        public Int32 WorkspaceID { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid LastUpdatedBy { get; set; }
    }
}
