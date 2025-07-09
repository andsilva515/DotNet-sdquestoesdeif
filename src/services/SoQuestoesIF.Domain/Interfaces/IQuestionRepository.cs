using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface IQuestionRepository
    {
        Task<Question> GetByIdAsync(Guid id);
        Task<IEnumerable<Question>> GetAllAsync();
        Task<IEnumerable<Question>> GetByFilterAsync(
            Guid? agencyId,
            Guid? examBoardId,
            Guid? positionId,
            Guid? subjectId,
            Guid? topicId,
            EnumQuestionDifficulty? difficulty,
            int? year);
        Task AddAsync(Question question);
        Task UpdateAsync(Question question);
        Task DeleteAsync(Guid Id);
    }
}
