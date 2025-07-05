using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface ISubjectService
    {
        Task<Subject> GetByIdAsync(Guid id);
        Task<IEnumerable<Subject>> GetAllAsync();
        Task AddAsync(Subject entity);
        Task UpdateAsync(Subject entity);
        Task DeleteAsync(Guid id);
    }
}
