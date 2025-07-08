using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface IPositionRepository
    {
        Task<Position> GetByIdAsync(Guid id);
        Task<IEnumerable<Position>> GetAllAsync();
        Task AddAsync(Position entity);
        void Update(Position entity);
        void Delete(Position entity);
    }
}
