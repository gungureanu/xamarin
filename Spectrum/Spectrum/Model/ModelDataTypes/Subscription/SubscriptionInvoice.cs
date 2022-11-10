using BusinessLogic.IBusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes.Subscription
{
    public class SubscriptionInvoice : BaseEntity
    {
        public List<SubscriptionPlan> SubscriptionPlanList { get; set; }
        public SpectrumInformation KhameliaInformation { get; set; }
        public List<InvoiceHistory> InvoiceHistoryList { get; set; }
    }
}
