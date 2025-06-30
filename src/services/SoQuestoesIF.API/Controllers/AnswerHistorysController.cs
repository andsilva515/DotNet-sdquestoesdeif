using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.Domain.Services;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerHistorysController : ControllerBase
    {
        private readonly IUserAnswerService _answerhistoryService;   
        public AnswerHistorysController(IUserAnswerService answerhistoryService)
        {
            _answerhistoryService = answerhistoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _answerhistoryService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _answerhistoryService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnswerHistory answerhistory)
        {
            await _answerhistoryService.AddAsync(answerhistory);
            return CreatedAtAction(nameof(GetById), new { id = answerhistory.Id }, answerhistory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, AnswerHistory answerhistory)
        {
            if (id != answerhistory.Id) return BadRequest();
            await _answerhistoryService.UpdateAsync(answerhistory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _answerhistoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
