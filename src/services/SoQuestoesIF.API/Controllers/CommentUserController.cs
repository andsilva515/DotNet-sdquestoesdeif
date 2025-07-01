using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Services;

namespace SoQuestoesIF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentUserController : ControllerBase
    {
        private readonly ICommentUserService _commentuserService;

        public CommentUserController(ICommentUserService commentUserService)
        {
            _commentuserService = commentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items await _commentuserService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _commentuserService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CommentUser comment)
        {
            await _commentuserService.AddAsync(comment);
            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CommentUser comment)
        {
            if (id != comment.Id) return BadRequest();
            await _commentuserService.UpdateAsync(comment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _commentuserService.DeleteAsync(id);
            return NoContent();
        }
    }
}
