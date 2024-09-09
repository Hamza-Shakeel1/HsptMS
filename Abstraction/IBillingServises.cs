
using HsptMS.Data.Models;

namespace HsptMS.Services
{
    public interface IBillingService
    {
        List<Billing> GetBillingList();
        void AddBilling(Billing billing);
        Billing GetBillingById(Guid id);
        void RemoveBillingById(Guid id);
        void UpdateBilling(Billing billing);
    }
}
