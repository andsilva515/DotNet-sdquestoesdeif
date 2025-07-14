using SoQuestoesIF.App.Interfaces;
using SoQuestoesIF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Services
{
    public class SubscriptionExpirationService : ISubscriptionExpirationService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SubscriptionExpirationService(
            ISubscriptionRepository subscriptionRepository,
            IUnitOfWork unitOfWork)
        {
            _subscriptionRepository = subscriptionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task ExpireExpiredSubscriptionsAsync()
        {
            var allActiveSubscriptions = await _subscriptionRepository.GetAllActiveAsync();
            var now = DateTime.UtcNow;

            foreach (var subscription in allActiveSubscriptions)
            {
                if (subscription.EndDate.HasValue && subscription.EndDate.Value < now)
                {
                    subscription.IsActive = false;
                    _subscriptionRepository.Update(subscription);
                }
            }

            await _unitOfWork.CommitAsync();
        }
    }

}
