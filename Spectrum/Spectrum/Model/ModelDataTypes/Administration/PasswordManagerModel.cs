using System;
namespace Spectrum.Model.ModelDataTypes
{
    public class PasswordManagerModel : BaseEntity
    {
        public string UserID { get; set; }
        public string AccountID { get; set; }
        public string CompanyID { get; set; }
        public string Password { get; set; }
    }
}
