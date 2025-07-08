using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Services
{
    public interface ICommentUserService
    {
        Task<CommentUserDto> GetByIdAsync(Guid id);
        Task<IEnumerable<CommentUserDto>> GetAllByQuestionAsync(Guid questionId);
        Task<Guid> CreateAsync(CommentUserCreateDto dto);
        Task UpdateAsync(Guid id, CommentUserUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
