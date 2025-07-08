using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface ICommentUserRepository
    {
        Task<CommentUser> GetByIdAsync(Guid id);
        Task<IEnumerable<CommentUser>> GetAllByQuestionAsync(Guid questionId);
        Task AddAsync(CommentUser entity);
        void Update(CommentUser entity);
        void Delete(CommentUser entity);
    }
}
