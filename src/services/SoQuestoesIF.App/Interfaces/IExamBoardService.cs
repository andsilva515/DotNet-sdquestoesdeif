using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface IExamBoardService
    {
        Task<ExamBoardDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ExamBoardDto>> GetAllAsync();
        Task<Guid> CreateAsync(ExamBoardDto dto);
        Task AddAsync(ExamBoard dto);
        Task UpdateAsync(Guid id, ExamBoardUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
