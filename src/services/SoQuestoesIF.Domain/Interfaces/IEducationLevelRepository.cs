using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface IEducationLevelRepository
    {
        Task<EducationLevel?> GetByIdAsync(Guid id);
        Task<IEnumerable<EducationLevel>> GetAllAsync();
        Task AddAsync(EducationLevel entity);
        void Update(EducationLevel entity);
        void Delete(EducationLevel entity);
    }
}
