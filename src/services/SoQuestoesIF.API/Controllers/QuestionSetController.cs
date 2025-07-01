using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.App.Services;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Services;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionSetController : ControllerBase
    {
        private readonly IQuestionSetService _questionsetService;
        public QuestionSetController(IQuestionSetService questionsetService)
        {
            _questionsetService = questionsetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _questionsetService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _questionsetService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuestionSet usernotebook)
        {
            await _questionsetService.AddAsync(usernotebook);
            return CreatedAtAction(nameof(GetById), new { id = usernotebook.Id }, usernotebook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, QuestionSet usernotebook)
        {
            if (id != usernotebook.Id) return BadRequest();
            await _questionsetService.UpdateAsync(usernotebook);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _questionsetService.DeleteAsync(id);
            return NoContent();
        }
    }
}
