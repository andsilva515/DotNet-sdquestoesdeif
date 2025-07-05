using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface IPaymentService
    {
        Task<string> CreateCheckoutAsync(Guid userId, Guid productId);
        Task HandleWebhookAsync(HttpRequest request);
    }
}
