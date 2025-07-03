using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Services;
using System.Runtime.InteropServices;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
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

        [HttpPost("{id}/register-answer")]
        public async Task<IActionResult> RegisterAnswer(Guid id, [FromQuery] bool isCorrect)
        {
            await _questionService.RegisterAnswerAsync(id, isCorrect);
            return NoContent();
        }

        [HttpPost("{id}/cancel")]
        public  async Task<IActionResult> Cancel(Guid id)
        {
            await _questionService.CancelAsync(id);
            return NoContent();
        }
    }
}
