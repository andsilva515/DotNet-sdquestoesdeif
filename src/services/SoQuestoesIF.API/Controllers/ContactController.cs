using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.App.Interfaces;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public ContatoController(IEmailService emailService)
        {
            _emailService = emailService;
        }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> EnviarFormulario([FromBody] ContactDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Nome) ||
            string.IsNullOrWhiteSpace(dto.Email) ||
            string.IsNullOrWhiteSpace(dto.Message))
        {
            return BadRequest("Todos os campos são obrigatórios.");
        }

            await _emailService.EnviarContatoAsync(dto);

            return Ok("Mensagem enviada com sucesso!");
        }
    }
}
