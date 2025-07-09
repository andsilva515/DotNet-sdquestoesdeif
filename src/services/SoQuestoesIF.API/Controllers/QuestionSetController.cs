using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.App.Interfaces;
using SoQuestoesIF.App.Services;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Services;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class QuestionSetsController : ControllerBase
    {
        private readonly IQuestionSetService _service;

        public QuestionSetsController(IQuestionSetService service)
        {
            _service = service;
        }

        // Este endpoint pode exigir autenticação para obter o UserId logado.
        // Ex: [Authorize] ou um middleware que injete o UserId.
        // Para simplificação, passamos um userId mockado ou do contexto da requisição.
        private Guid GetCurrentUserId()
        {
            // **IMPORTANTE:** Em uma aplicação real, você obteria o ID do usuário
            // do contexto de segurança (ex: ClaimsPrinciple após autenticação JWT).
            // Este é um mock para fins de demonstração.
            return new Guid("d2e9b0a1-c3f4-5a6b-7c8d-9e0f1a2b3c4d"); // Exemplo de um UserID fixo
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QuestionSetFilterDto filter)
        {
            try
            {
                var userId = GetCurrentUserId();
                var result = await _service.GetAllAsync(filter, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Logar a exceção
                return StatusCode(500, "Ocorreu um erro interno ao buscar os cadernos.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var userId = GetCurrentUserId();
                var dto = await _service.GetByIdAsync(id, userId);
                return Ok(dto);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message); // Retorna 403 Forbidden
            }
            catch (Exception ex)
            {
                // Logar a exceção
                return StatusCode(500, "Ocorreu um erro interno ao buscar o caderno.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuestionSetCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var userId = GetCurrentUserId();
                var id = await _service.CreateAsync(dto, userId);
                return CreatedAtAction(nameof(GetById), new { id }, null);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                // Logar a exceção
                return StatusCode(500, "Ocorreu um erro interno ao criar o caderno.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] QuestionSetUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var userId = GetCurrentUserId();
                await _service.UpdateAsync(id, dto, userId);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                // Logar a exceção
                return StatusCode(500, "Ocorreu um erro interno ao atualizar o caderno.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var userId = GetCurrentUserId();
                await _service.DeleteAsync(id, userId);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                // Logar a exceção
                return StatusCode(500, "Ocorreu um erro interno ao deletar o caderno.");
            }
        }
    }
