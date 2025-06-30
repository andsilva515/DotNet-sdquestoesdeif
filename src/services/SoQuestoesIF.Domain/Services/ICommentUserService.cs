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
        Task<CommentUser> GetByIdAsync(Guid id);
        Task<IEnumerable<CommentUser>> GetAllAsync();
        Task AddAsync(CommentUser entity);
        Task UpdateAsync(CommentUser entity);
        Task DeleteAsync(Guid id);
    }
}
