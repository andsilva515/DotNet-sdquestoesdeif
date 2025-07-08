using SoQuestoesIF.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface IAlternativeService
    {
        Task<AlternativeDto> GetByIdAsync(Guid id);
        Task<IEnumerable<AlternativeDto>> GetAllByQuestionAsync(Guid questionId);
        Task<Guid> CreateAsync(AlternativeCreateDto dto);
        Task UpdateAsync(Guid id, AlternativeUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
