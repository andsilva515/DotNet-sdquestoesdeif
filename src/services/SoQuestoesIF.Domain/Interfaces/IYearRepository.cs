using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface IYearRepository
    {
        Task<Year?> GetByIdAsync(Guid id);
        Task<IEnumerable<Year>> GetAllAsync();
        Task AddAsync(Year entity);
        void Update(Year entity);
        void Delete(Year entity);
    }
}
