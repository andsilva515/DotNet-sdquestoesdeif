using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface IEducationLevelService
    {           
        Task<EducationLevelDto> GetByIdAsync(Guid id);
        Task<IEnumerable<EducationLevelDto>> GetAllAsync();
        Task<Guid> CreateAsync(EducationLevelCreateDto dto);
        Task UpdateAsync(Guid id, EducationLevelUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
