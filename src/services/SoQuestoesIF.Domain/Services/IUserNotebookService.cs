using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Services
{
    public interface IUserNotebookService
    {
        Task<UserNotebook> GetByIdAsync(Guid id);
        Task<IEnumerable<UserNotebook>> GetAllAsync();
        Task AddAsync(UserNotebook entity);
        Task UpdateAsync(UserNotebook entity);
        Task DeleteAsync(Guid id);            
    }
}
