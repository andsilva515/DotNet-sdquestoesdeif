using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Services
{
    public interface IAgencyService
    {
        Task<Agency> GetByIdAsync(Guid id);
        Task<IEnumerable<Agency>> GetAllAsync();
        Task AddAsync(Agency entity);
        Task UpdateAsync(Agency entity);
        Task DeleteAsync(Guid id);
    }
}
