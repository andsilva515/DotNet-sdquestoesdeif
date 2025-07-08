using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface IExamService
    {
        Task<ExamDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ExamDto>> GetAllAsync();
        Task CreateAsync(ExamCreateDto dto);
        Task UpdateAsync(Guid id, ExamUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
