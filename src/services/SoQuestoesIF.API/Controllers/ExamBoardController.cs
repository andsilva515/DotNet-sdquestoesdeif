using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.App.Interfaces;
using SoQuestoesIF.Domain.Services;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamBoardController : ControllerBase
    {
        private readonly IExamBoardService _examboardService;
        public ExamBoardController(IExamBoardService examBoardService)
        {
            _examboardService = examBoardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _examboardService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _examboardService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ExamBoardCreateDto dto)
        {
            var id = await _examboardService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(Guid id, [FromBody] ExamBoardUpdateDto dto)
        {            
            await _examboardService.UpdateAsync(id, dto);
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
