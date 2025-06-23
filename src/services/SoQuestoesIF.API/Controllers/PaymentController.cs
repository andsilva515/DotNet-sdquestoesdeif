using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.Domain.Entities;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout(Guid productId, PaymentMethod method)
        {
            string url = method switch
            {
                PaymentMethod.PagSeguro => await _pagSeguroService.CreateCheckoutAsync(userId, productId),
                PaymentMethod.MercadoPago => await _mercadoPagoService.CreateCheckoutAsync(userId, productId),
                _ => throw new Exception("Método de pagamento não suportado.")
            };

            return Redirect(url); // ou return Ok(url);
        }

    }
}
