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
        Task<QuestionSetDto> GetByIdAsync(Guid id);
        Task<IEnumerable<QuestionSetDto>> GetAllAsync();
        Task<Guid> CreateAsync(QuestionSetCreateDto dto);
        Task UpdateAsync(Guid id, QuestionSetUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
}
