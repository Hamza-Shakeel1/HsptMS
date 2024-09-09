using HMS.Data.Extensions;
using HsptMS.Abstraction;
using HsptMS.Data.Models;

namespace HsptMS.Services
    {
        public class BillingService : IBillingService
        {


            private readonly HmsContext _hmscontext;
            public BillingService(HmsContext hmscontext)
            {
                _hmscontext = hmscontext;
            }

            public List<Billing> GetBillingList()
            {
            return _hmscontext.Billings
                    .ToList();
            }
            public void AddBilling(Billing billing)
            {
            billing.Id = GuidExtension.GetGuid();
                _hmscontext.Billings.Add(billing);
            }
            public Billing GetBillingById(Guid id)
            {
                return _hmscontext.Billings.FirstOrDefault(x => x.Id == id);
            }
            public void RemoveBillingById(Guid id)
            {
                var  billings = _hmscontext.Billings.FirstOrDefault(d => d.Id == id);
                if (billings != null)
                {
                    _hmscontext.Billings.Remove(billings);
                }
            }



            public void UpdateBilling(Billing billing)
        {
                var existingBilling = _hmscontext.Billings.FirstOrDefault(x => x.Id == billing.Id);
                if (existingBilling != null)
                {
                _hmscontext.Billings.Remove(existingBilling);
                _hmscontext.Billings.Add(billing);
                }
            }

        }
    }


