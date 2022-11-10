using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class SubscriptionLicenses : BaseEntity
    {
        public Guid AccountID { get; set; }
        public string CompanyName { get; set; }
        public string StripeSubscriptionID { get; set; }
        public string StripeProductID { get; set; }
        public int PlanID { get; set; }
        public string PlanName { get; set; }
        public int KeyDetailsID { get; set; }
        public string StripePlanID { get; set; }
        public string LicenseKey { get; set; }
        public Guid? UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? EffectiveFromDate { get; set; }
        public DateTime? EffectiveuptoDate { get; set; }
        public int UsedLicense { get; set; }
        public int TotalLicense { get; set; }
        public bool AccountSuspended { get; set; }
        public bool isCancel { get; set; }
        public int CostTypeID { get; set; }
    }
}
