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
        // Interface única para todos os serviços de pagamento (PagSeguro e MercadoPago):
        Task<string> CreateCheckoutAsync(Guid userId, Guid productId);
        Task HandleWebhookAsync(HttpRequest request);
    }
}
