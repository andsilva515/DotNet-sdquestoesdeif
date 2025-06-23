using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Services;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationLevelsController : ControllerBase
    {
        private readonly IEducationLevelService _educationlevelService;
        public EducationLevelsController(IEducationLevelService educationlevelService)
        {
            _educationlevelService = educationlevelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _educationlevelService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _educationlevelService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EducationLevel educationlevel)
        {
            await _educationlevelService.AddAsync(educationlevel);
            return CreatedAtAction(nameof(GetById), new { id = educationlevel.Id }, educationlevel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, EducationLevel educationlevel)
        {
            if (id != educationlevel.Id) return BadRequest();
            await _educationlevelService.UpdateAsync(educationlevel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _educationlevelService.DeleteAsync(id);
            return NoContent();
        }
    }
}
