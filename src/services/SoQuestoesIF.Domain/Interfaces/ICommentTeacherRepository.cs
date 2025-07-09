using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface ICommentTeacherRepository
    {
        Task<CommentTeacher> GetByIdAsync(Guid id);
        Task<IEnumerable<CommentTeacher>> GetAllByQuestionAsync(Guid questionId);
        Task AddAsync(CommentTeacher entity);
        void Delete(CommentTeacher entity);
    }
}
