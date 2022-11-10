using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class ErrorLog : BaseEntity
    {
        public Int32 ModuleID { get; set; }
        public Guid AccountID { get; set; }
        public Guid UserID { get; set; }
        public string ErrorMode { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorPage { get; set; }
        public bool IsActive { get; set; }
        public string ErrorMessage { get; set; }
        public string Description { get; set; }
        public string MethodName { get; set; }
    }
}
