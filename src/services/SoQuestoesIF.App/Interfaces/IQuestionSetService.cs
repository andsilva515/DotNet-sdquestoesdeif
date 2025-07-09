using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface IQuestionSetService
    {
        Task<QuestionSetDto> GetByIdAsync(Guid id, Guid currentUserId);
        Task<PagedResult<QuestionSetDto>> GetAllAsync(QuestionSetFilterDto filter, Guid currentUserId);
        Task<Guid> CreateAsync(QuestionSetCreateDto dto, Guid currentUserId);
        Task UpdateAsync(Guid id, QuestionSetUpdateDto dto, Guid currentUserId);
        Task DeleteAsync(Guid id, Guid currentUserId);
    }
}

