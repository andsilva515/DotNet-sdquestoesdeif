using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface IStateRepository
    {
        Task<State> GetByIdAsync(Guid id);
        Task<IEnumerable<State>> GetAllAsync();
        Task AddAsync(State entity);
        void Update(State entity);
        void Delete(State entity);
    }
}
