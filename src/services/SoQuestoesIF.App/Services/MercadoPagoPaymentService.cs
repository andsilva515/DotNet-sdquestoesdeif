using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Services
{
    public class MercadoPagoPaymentService
    {
        // para Pix, boleto, compra avulsa
        public Task<string> CreateCheckoutAsync(Guid userId, Guid productId)
        {
            // TODO: Integrar com a API do Mercado Pago Checkout
            return Task.FromResult("https://mercadopago.com/checkout?preference_id=FAKE_ID");
        }

        public Task HandleWebhookAsync(HttpRequest request)
        {
            // TODO: Processar webhook de pagamento
            return Task.CompletedTask;
        }
    }
}
