using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.Domain.Services;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _examService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _examService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Exam exam)
        {
            await _examService.AddAsync(exam);
            return CreatedAtAction(nameof(GetById), new { id = exam.Id }, exam);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Exam exam)
        {
            if (id != exam.Id) return BadRequest();
            await _examService.UpdateAsync(exam);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _examService.DeleteAsync(id);
            return NoContent();
        }
    }
}
