using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface IQuestionSetRepository
    {
        Task<QuestionSet?> GetByIdAsync(Guid id);
        Task<IEnumerable<QuestionSet>> GetAllAsync();
        Task AddAsync(QuestionSet entity);
        void Update(QuestionSet entity);
        void Delete(QuestionSet entity);
        Task SaveQuestionSetQuestionsAsync(QuestionSet set, List<Guid> questionIds);
    }
}
