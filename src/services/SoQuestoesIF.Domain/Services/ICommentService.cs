using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Services
{
    public interface ICommentService
    {
        Task<Comment> GetByIdAsync(Guid id);
        Task<IEnumerable<Comment>> GetAllAsync();
        Task AddAsync(Comment entity);
        Task UpdateAsync(Comment entity);
        Task DeleteAsync(Guid id);
    }
}
