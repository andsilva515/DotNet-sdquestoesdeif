using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.App.Interfaces;
using SoQuestoesIF.Infra.Helpers;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionService _service;

        public SubscriptionsController(ISubscriptionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserSubscriptions()
        {
            var userId = User.GetUserId();
            var subs = await _service.GetUserSubscriptionsAsync(userId);
            return Ok(subs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscription([FromBody] SubscriptionCreateDto dto)
        {
            var userId = User.GetUserId();
            var id = await _service.CreateSubscriptionAsync(userId, dto);
            return CreatedAtAction(nameof(GetUserSubscriptions), new { id }, null);
        }
    }
}
