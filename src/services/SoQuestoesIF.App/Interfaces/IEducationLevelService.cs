using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Services
{
    public interface IEducationLevelService
    {
        Task<EducationLevel> GetByIdAsync(Guid id);
        Task<IEnumerable<EducationLevel>> GetAllAsync();
        Task AddAsync(EducationLevel entity);
        Task UpdateAsync(EducationLevel entity);
        Task DeleteAsync(Guid id);
    }
}
