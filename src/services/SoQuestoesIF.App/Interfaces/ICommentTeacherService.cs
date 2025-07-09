using SoQuestoesIF.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface ICommentTeacherService
    {
        Task<CommentTeacherDto> GetByIdAsync(Guid id);
        Task<IEnumerable<CommentTeacherDto>> GetAllByQuestionAsync(Guid questionId);
        Task<Guid> CreateAsync(CommentTeacherCreateDto dto);
        Task DeleteAsync(Guid id);
    }

}
