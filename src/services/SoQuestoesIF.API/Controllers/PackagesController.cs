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
    public class PackagesController : ControllerBase
    {
        private readonly IPackageService _service;

        public PackagesController(IPackageService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var packages = await _service.GetAllPackagesAsync();
            return Ok(packages);
        }

        [HttpPost("purchase")]
        public async Task<IActionResult> Purchase([FromBody] PackagePurchaseDto dto)
        {
            var userId = User.GetUserId();
            var url = await _service.CreatePurchaseAndCheckoutAsync(userId, dto);
            return Ok(new { redirectUrl = url });
        }
    }
}
