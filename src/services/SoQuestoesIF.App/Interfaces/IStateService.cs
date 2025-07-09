using SoQuestoesIF.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface IStateService
    {
        Task<StateDto> GetByIdAsync(Guid id);
        Task<IEnumerable<StateDto>> GetAllAsync();
        Task<Guid> CreateAsync(StateCreateDto dto);
        Task UpdateAsync(Guid id, StateUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
