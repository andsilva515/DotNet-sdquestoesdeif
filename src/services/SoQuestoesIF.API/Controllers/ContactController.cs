using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.App.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.App.Interfaces;

namespace SoQuestoesIF.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // => /api/Contato
    public class ContatoController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public ContatoController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost] // POST /api/Contato
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

        // ✅ Mantém DENTRO da classe
        [HttpGet("config-check")] // GET /api/Contato/config-check
        [AllowAnonymous]
        public IActionResult ConfigCheck([FromServices] IConfiguration config)
        {
            return Ok(new
            {
                Host = config["Smtp:Host"],
                Port = config["Smtp:Port"],
                User = config["Smtp:User"],
                Destino = config["Smtp:Destino"],
                PasswordHasValue = !string.IsNullOrWhiteSpace(config["Smtp:Password"])
            });
        }
    }
}
