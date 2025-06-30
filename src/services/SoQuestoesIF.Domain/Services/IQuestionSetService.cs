using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Services
{
    public interface IQuestionSetService
    {
        Task<QuestionSet> GetByIdAsync(Guid id);
        Task<IEnumerable<QuestionSet>> GetAllAsync();
        Task AddAsync(QuestionSet entity);
        Task UpdateAsync(QuestionSet entity);
        Task DeleteAsync(Guid id);            
    }
}
