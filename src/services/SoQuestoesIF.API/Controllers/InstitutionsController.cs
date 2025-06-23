using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.Domain.Services;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionsController : ControllerBase
    {
        private readonly IInstitutionService _institutionService;
        public InstitutionsController(IInstitutionService institutionService)
        {
            _institutionService = institutionService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _institutionService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _institutionService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Institution institution)
        {
            await _institutionService.AddAsync(institution);
            return CreatedAtAction(nameof(GetById), new { id = institution.Id }, institution);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Institution institution)
        {
            if (id != institution.Id) return BadRequest();
            await _institutionService.UpdateAsync(institution);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _institutionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
