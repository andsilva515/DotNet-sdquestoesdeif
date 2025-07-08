using SoQuestoesIF.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface IPositionService
    {
        Task<PositionDto> GetByIdAsync(Guid id);
        Task<IEnumerable<PositionDto>> GetAllAsync();
        Task<Guid> CreateAsync(PositionCreateDto dto);
        Task UpdateAsync(Guid id, PositionUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
