using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface IAgencyRepository
    {
        Task AddAsync(Agency entity);
        void Delete(Agency entity);
        Task<IEnumerable<Agency>> GetAllAsync();

        // Métodos customizados para Institution
        Task<Agency> GetByIdAsync(Guid id);
        void Update(Agency entity);
    }
}
