using System;
namespace Spectrum.Model.ModelDataTypes
{
    public class MobileProjectListProfile
    {
        public Int64 ProjectID { get; set; }
        public string ProjectName { get; set; }
        public Int32 WorkSpaceID { get; set; }
        public Guid CompanyID { get; set; }
        public Guid AccountID { get; set; }
        public Int64 TeamID { get; set; }
        public Int64 TaskCount { get; set; }
        public Int64 TotalTask { get; set; }
        public Int64 CompletedTask { get; set; }
    }
}
