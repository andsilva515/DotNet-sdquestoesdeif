using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.App.Interfaces;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordResetController : ControllerBase
    {
        private readonly IPasswordResetTokenService _resetService;

        public PasswordResetController(IPasswordResetTokenService resetService)
        {
            _resetService = resetService;
        }

        [HttpPost("request-password-reset")]
        [AllowAnonymous]
        public async Task<IActionResult> RequestPasswordReset([FromBody] PasswordResetTokenDto dto)
        {
            await _resetService.RequestResetAsync(dto.Email);
            return Ok(); // Sempre 200
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordTokenDto dto)
        {
            await _resetService.ResetPasswordAsync(dto.Token, dto.NewPassword);
            return Ok();
        }
    }
}
