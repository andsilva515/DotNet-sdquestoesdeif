using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Services
{
    public interface IAnswerHistoryService
    {
        Task<AnswerHistory> GetByIdAsync(Guid id);
        Task<IEnumerable<AnswerHistory>> GetAllAsync();
        Task AddAsync(AnswerHitory entity);
        Task UpdateAsync(AnswerHistory entity);
        Task DeleteAsync(Guid id);
    }
}
