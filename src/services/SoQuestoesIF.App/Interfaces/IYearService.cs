using SoQuestoesIF.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface IYearService
    {
        Task<YearDto> GetByIdAsync(Guid id);
        Task<IEnumerable<YearDto>> GetAllAsync();
        Task<Guid> CreateAsync(YearCreateDto dto);
        Task UpdateAsync(Guid id, YearUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
