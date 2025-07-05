using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface IUserAnswerService
    {
        Task<UserAnswer> GetByIdAsync(Guid id);
        Task<IEnumerable<UserAnswer>> GetAllAsync();
        Task AddAsync(UserAnswer entity);
        Task UpdateAsync(UserAnswer entity);
        Task DeleteAsync(Guid id);
    }
}
