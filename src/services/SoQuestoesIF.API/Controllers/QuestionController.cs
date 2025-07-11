using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.App.Interfaces;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Services;
using SoQuestoesIF.Infra.Helpers;
using System.Runtime.InteropServices;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IQuestionAccessService _questionAccessService;
        public QuestionController(IQuestionService questionService, IQuestionAccessService questionAccessService)
        {
            _questionService = questionService;
            _questionAccessService = questionAccessService;
        }        

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _questionService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _questionService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuestionCreateDto dto)
        {
            var id = await _questionService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] QuestionUpdateDto dto)
        {            
            await _questionService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _questionService.DeleteAsync(id);
            return NoContent();
        }

        [Authorize]
        [HttpPost("{id}/register-answer")]
        public async Task<IActionResult> RegisterAnswer(Guid id, [FromQuery] bool isCorrect)
        {
            await _questionService.RegisterAnswerAsync(id, isCorrect);
            return NoContent();
        }

        [Authorize]
        [HttpPost("{id}/cancel")]
        public  async Task<IActionResult> Cancel(Guid id)
        {
            await _questionService.CancelAsync(id);
            return NoContent();
        }

        [Authorize]
        [HttpPost("{id}/resolve")]
        public async Task<IActionResult> Resolve(Guid id)
        {
            var userId = User.GetUserId();

            // Verifica se usuário pode resolver mais questões hoje
            var canResolve = await _questionAccessService.CanResolveQuestionAsync(userId);
            if (!canResolve)
            {
                return BadRequest(new { message = "Limite diário de 10 questões atingido. Faça uma assinatura para acesso ilimitado." });
            }

            // Marca como respondida no controle de limite diário
            await _questionAccessService.IncrementResolutionCountAsync(userId);

            // (Opcional) Registrar resolução da questão no sistema
            // Exemplo: await _questionService.MarkAsResolvedAsync(userId, id);

            return Ok(new { message = "Questão registrada como resolvida com sucesso." });
        }


    }
}
