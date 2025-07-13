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

        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout(Guid userId, Guid productId, string method)
        {
            string url = method.ToLower() switch
            {
                "pagseguro" => await _pagSeguro.CreateCheckoutAsync(userId, productId),
                "mercadopago" => await _mercadoPago.CreateCheckoutAsync(userId, productId),
                _ => throw new Exception("Método inválido")
            };

            return Ok(new { redirectUrl = url });
        }

        [HttpPost("webhook/{method}")]
        public async Task<IActionResult> Webhook(string method)
        {
            if (method.ToLower() == "pagseguro")
                await _pagSeguro.HandleWebhookAsync(Request);
            else if (method.ToLower() == "mercadopago")
                await _mercadoPago.HandleWebhookAsync(Request);
            else
                return BadRequest("Método inválido");

            return Ok();
        }
    }
}