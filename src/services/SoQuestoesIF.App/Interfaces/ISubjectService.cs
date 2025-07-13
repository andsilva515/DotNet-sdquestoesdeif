using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDto>> GetAllAsync();
        Task<SubjectDto> GetByIdAsync(Guid id);
        Task CreateAsync(SubjectCreateDto dto);
        Task UpdateAsync(Guid id, SubjectUpdateDto dto);
        Task DeleteAsync(Guid id);
        
 
    }
}
