using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Services;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAnswerController : ControllerBase
    {
        private readonly IUserAnswerService _useranswerService;   
        public UserAnswerController(IUserAnswerService useranswerService)
        {
            _useranswerService = useranswerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _useranswerService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _useranswerService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserAnswer useranswer)
        {
            await _useranswerService.AddAsync(useranswer);
            return CreatedAtAction(nameof(GetById), new { id = useranswer.Id }, useranswer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UserAnswer useranswer)
        {
            if (id != useranswer.Id) return BadRequest();
            await _useranswerService.UpdateAsync(useranswer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _useranswerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
