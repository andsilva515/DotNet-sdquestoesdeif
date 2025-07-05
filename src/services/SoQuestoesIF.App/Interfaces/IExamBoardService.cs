using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Services
{
    public interface IExamBoardService
    {
        Task<ExamBoard> GetByIdAsync(Guid id);
        Task<IEnumerable<ExamBoard>> GetAllAsync();
        Task AddAsync(ExamBoard entity);
        Task UpdateAsync(ExamBoard entity);
        Task DeleteAsync(Guid id);
    }
}
