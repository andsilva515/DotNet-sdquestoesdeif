using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.Domain.Services;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinesController : ControllerBase
    {
        private readonly IDisciplineService _disciplineService;
        public DisciplinesController(IDisciplineService disciplineService)
        {
            _disciplineService = disciplineService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _disciplineService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _disciplineService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Discipline discipline)
        {
            await _disciplineService.AddAsync(discipline);
            return CreatedAtAction(nameof(GetById), new { id = discipline.Id }, discipline);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Discipline discipline)
        {
            if (id != discipline.Id) return BadRequest();
            await _disciplineService.UpdateAsync(discipline);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _disciplineService.DeleteAsync(id);
            return NoContent();
        }
    }
}
