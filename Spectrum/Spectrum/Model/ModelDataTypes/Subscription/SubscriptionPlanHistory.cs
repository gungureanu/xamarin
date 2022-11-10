using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes.Subscription
{
    public class SubscriptionPlanHistory : BaseEntity
    {
        public Guid AccountID { get; set; }
        public int PlanID { get; set; }
        public DateTime? PlanStartDate { get; set; }
        public DateTime? PlanEndDate { get; set; }
        public DateTime? TrialStartDate { get; set; }
        public DateTime? TrialEndDate { get; set; }
        public string SubscriptionType { get; set; }
        public string ReturnMessage { get; set; }

    }
}
