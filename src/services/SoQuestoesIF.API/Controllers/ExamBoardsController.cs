using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.Domain.Services;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamBoardsController : ControllerBase
    {
        private readonly IExamBoardService _examboardService;
        public ExamBoardsController(IExamBoardService examBoardService)
        {
            _examboardService = examBoardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _examboardService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _examboardService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExamBoard examboard)
        {
            await _examboardService.AddAsync(examboard);
            return CreatedAtAction(nameof(GetById), new { id = examboard }, examboard);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(Guid id, ExamBoard examboard)
        {
            if (id != examboard.Id) return BadRequest();
            await _exambordService.UpdateAsync(examboard);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _examboardService.DeleteAsync(id);
            return NoContent();
        }
    }
}
