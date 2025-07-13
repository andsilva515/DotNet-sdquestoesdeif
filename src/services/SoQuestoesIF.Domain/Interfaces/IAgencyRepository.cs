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
        Task<Agency?> GetByIdAsync(Guid id);
        Task<IEnumerable<Agency>> GetAllAsync();
        Task AddAsync(Agency agency);
        void Delete(Agency agency);                  
        void Update(Agency agency);
    }
}
