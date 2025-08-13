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
    [Route("api/[controller]")] // /api/Contato
    public class ContatoController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<ContatoController> _logger;

        public ContatoController(IEmailService emailService, ILogger<ContatoController> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> EnviarFormulario([FromBody] ContactDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nome) ||
                string.IsNullOrWhiteSpace(dto.Email) ||
                string.IsNullOrWhiteSpace(dto.Message))
                return BadRequest("Todos os campos são obrigatórios.");

            try
            {
                await _emailService.EnviarContatoAsync(dto);
                return Ok("Mensagem enviada com sucesso!");
            }
            catch (SmtpException ex)
            {
                _logger.LogError(ex, "Falha SMTP ao enviar contato.");
                // 502 ajuda a diferenciar problema de backend externo (SMTP)
                return StatusCode(StatusCodes.Status502BadGateway,
                    "Falha ao enviar e-mail (SMTP). Verifique credenciais/host/porta.");
            }
            catch (InvalidOperationException ex) // config ausente
            {
                _logger.LogError(ex, "Configuração SMTP ausente/incorreta.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Falha de configuração SMTP no servidor.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado ao enviar contato.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro interno ao processar sua solicitação.");
            }
        }

        [HttpGet("config-check")]
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
