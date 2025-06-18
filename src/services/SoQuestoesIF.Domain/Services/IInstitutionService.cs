using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Services
{
    public interface IInstitutionService
    {
        Task<Institution> GetByIdAsync(Guid id);
        Task<IEnumerable<Institution>> GetAllAsync();
        Task AddAsync(Institution entity);

        Task UpdateAsync(IInstitutionService entity);
        Task DeleteAsync(Guid id);
    }
}
