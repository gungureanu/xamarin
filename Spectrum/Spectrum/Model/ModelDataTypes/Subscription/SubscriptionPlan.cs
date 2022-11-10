using System;
using System.Collections.Generic;
using System.Text;
using Spectrum.Model.ModelDataTypes;

namespace Spectrum.Model.ModelDataTypes
{
    public class SubscriptionPlan
    {
        public int PlanID { get; set; }
        public int CostID { get; set; }
        public string PlanName { get; set; }
        public string PlanDescription { get; set; }
        public string PlanDescription2 { get; set; }
        public string PlanDetails { get; set; }
        public Decimal PlanAmount { get; set; }
        public Decimal ActualPlanAmount { get; set; }
        public Decimal DiscountCost { get; set; }
        public Decimal DiscountPercentage { get; set; }
        public int PlanQty { get; set; }
        public Decimal Amount { get; set; }
        public string FeatureValue { get; set; }
        public string FeatureType { get; set; }
        public bool IsAllow { get; set; }
        public bool IsBestPlan { get; set; }
        public decimal DiscountValue { get; set; }
        public string StripePlanID { get; set; }
        public string StripeSubscriptionItemID { get; set; }
        public string StripeProductID { get; set; }
        public string StripeSubscriptionID { get; set; }
        public int PlanDays { get; set; }
        public string ReturnMesage { get; set; }
        public int MonthlyDiscount { get; set; }
        public string CouponCode { get; set; }
        public int CouponID { get; set; }
        public decimal MonthlyDiscountAmount { get; set; }
        public string ModuleIDs { get; set; }
        public decimal Cost { get; set; }
        public int CostTypeID { get; set; }
        public int DiscountID { get; set; }
        public string PlanType { get; set; }
        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }
        public string CostTypeName { get; set; }
        public decimal RegularDiscountCost { get; set; }
        public Decimal UnitPrice { get; set; }
        public bool Active { get; set; }
        public bool IsExtraLicense { get; set; }
        public string PlanCssClassName { get; set; }
        public List<SubscriptionLicenses> SubscriptionLicensesList { get; set; }
    }
}
