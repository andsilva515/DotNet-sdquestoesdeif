using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Services
{
    public interface IExamService
    {
        Task<Exam> GetByIdAsync(Guid id);
        Task<IEnumerable<Exam>> GetAllAsync();
        Task AddAsync(Exam entity);
        Task UpdateAsync(Exam entity);
        Task DeleteAsync(Guid id);
    }
}
