using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Services
{
    public interface IDisciplineService
    {
        Task<Discipline> GetByIdAsync(Guid id);   
        Task<IEnumerable<Discipline>> GetAllAsync();
        Task AddAsync(IDiscipline entity);
        Task UpdateAsync(IDiscipline entity);

        Task DeleteAsync(Guid id);
    }
}
