using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Services
{
    public class PagSeguroPaymentService
    {
        // para assinaturas

        public Task<string> CreateCheckoutAsync(Guid userId, Guid productId)
        {
            // TODO: Integrar com a API de planos e assinatura do PagSeguro
            return Task.FromResult("https://pagseguro.uol.com.br/v2/checkout/payment.html?code=FAKE_CODE");
        }

        public Task HandleWebhookAsync(HttpRequest request)
        {
            // TODO: Validar notificação e atualizar status do pagamento
            return Task.CompletedTask;
        }
}   }
