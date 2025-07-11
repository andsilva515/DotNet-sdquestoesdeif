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
        Task<IEnumerable<SubscriptionDto>> GetUserSubscriptionsAsync(Guid userId);
        Task<Guid> CreateSubscriptionAsync(Guid userId, SubscriptionCreateDto dto);
    }
}
