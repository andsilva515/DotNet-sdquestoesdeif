using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.Domain.Services;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserNotebooksController : ControllerBase
    {
        private readonly IQuestionSetService _usernotebookService;
        public UserNotebooksController(IQuestionSetService usernotebookService)
        {
            _usernotebookService = usernotebookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _usernotebookService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _usernotebookService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserNotebook usernotebook)
        {
            await _usernotebookService.AddAsync(usernotebook);
            return CreatedAtAction(nameof(GetById), new { id = usernotebook.Id }, usernotebook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UserNotebook usernotebook)
        {
            if (id != usernotebook.Id) return BadRequest();
            await _usernotebookService.UpdateAsync(usernotebook);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _usernotebookService.DeleteAsync(id);
            return NoContent();
        }
    }
}
