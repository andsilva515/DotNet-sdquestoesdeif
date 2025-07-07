using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.App.Services;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Services;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyController : ControllerBase
    {
        private readonly IAgencyService _agencyService;
        public AgencyController(IAgencyService agencyService)
        {
            _agencyService = agencyService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _agencyService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _agencyService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AgencyCreateDto dto)
        {
           var id = await _agencyService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id}, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AgencyUpdateDto dto)
        {           
            await _agencyService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _agencyService.DeleteAsync(id);
            return NoContent();
        }
    }
}
