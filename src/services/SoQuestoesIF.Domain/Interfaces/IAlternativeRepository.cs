using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface IAlternativeRepository
    {
        Task<Alternative?> GetByIdAsync(Guid id);
        Task<IEnumerable<Alternative>> GetAllByQuestionIdAsync(Guid questionId);
        Task AddAsync(Alternative alternative);
        void Update(Alternative alternative);
        void Delete(Alternative alternative);
    }
}
