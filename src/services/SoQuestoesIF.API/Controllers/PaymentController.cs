using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.App.Services;
using SoQuestoesIF.Domain.Enums;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly PagSeguroPaymentService _pagSeguro;
        private readonly MercadoPagoPaymentService _mercadoPago;

        public CheckoutController(
            PagSeguroPaymentService pagSeguro,
            MercadoPagoPaymentService mercadoPago)
        {
            _pagSeguro = pagSeguro;
            _mercadoPago = mercadoPago;
        }

        [HttpPost("webhook/mercadopago")]
        public async Task<IActionResult> WebhookMercadoPago()
        {
            await _mercadoPago.HandleWebhookAsync(Request);
            return Ok();
        }

        [HttpPost("webhook/pagseguro")]
        public async Task<IActionResult> WebhookPagSeguro()
        {
            await _pagSeguro.HandleWebhookAsync(Request);
            return Ok();
        }
    }
}