using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface ISubscriptionExpirationService
    {
        Task ExpireExpiredSubscriptionsAsync();
    }
}
