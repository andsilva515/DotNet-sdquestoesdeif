using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.App.Interfaces;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Services;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subjects = await _subjectService.GetAllAsync();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var subject = await _subjectService.GetByIdAsync(id);
            if (subject == null) return NotFound();
            return Ok(subject);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubjectCreateDto dto)
        {
            var id = await _subjectService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, null);    
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] SubjectUpdateDto dto)
        {
            await _subjectService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _subjectService.DeleteAsync(id);
            return NoContent();
        }
    }
}
