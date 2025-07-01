using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var items = await _agencyService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _agencyService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Agency agency)
        {
            await _agencyService.AddAsync(agency);
            return CreatedAtAction(nameof(GetById), new { id = agency.Id }, agency);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Agency agency)
        {
            if (id != agency.Id) return BadRequest();
            await _agencyService.UpdateAsync(agency);
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
