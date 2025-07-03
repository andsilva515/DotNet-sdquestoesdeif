using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Services
{
    public interface IQuestionService
    {      
            Task<QuestionDto> GetByIdAsync(Guid id);
            Task<IEnumerable<QuestionDto>> GetAllAsync();
            Task<IEnumerable<QuestionDto>> GetByFilterAsync(
                Guid? agencyId,
                Guid? examBoardId,
                Guid? positionId,
                Guid? subjectId,
                Guid? topicId,
                EnumQuestionDifficulty? difficulty,
                int? year);

            Task<Guid> CreateAsync(QuestionDto question);
            Task UpdateAsync(Guid id, QuestionDto question);
            Task DeleteAsync(Guid id);
            Task RegisterAnswerAsync(Guid questionId, bool isCorrect);
            Task CancelAsync(Guid id);
        }

    }
}
