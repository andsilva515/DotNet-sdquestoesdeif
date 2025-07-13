using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface IUserAnswerRepository 
    {
        Task<UserAnswer?> GetByIdAsync(Guid id);
        Task<IEnumerable<UserAnswer>> GetAllByUserAsync(Guid userId);
        Task AddAsync(UserAnswer entity);

    }
}
