using SoQuestoesIF.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface ISubscriptionService
    {
        Task<string> CreateSubscriptionAndCheckoutAsync(Guid userId, SubscriptionCreateDto dto);
        Task ActivateSubscriptionAsync(Guid subscriptionId);
    }
}
