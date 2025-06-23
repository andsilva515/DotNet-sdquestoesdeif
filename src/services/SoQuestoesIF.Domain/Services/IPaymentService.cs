using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Services
{
    public interface IPaymentService
    {
        Task<string> CreateCheckoutAsync(Guid userId, Guid productId);
        Task HandleWebhookAsync(HttpRequest request);
    }
}
