using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Services
{
    public interface IAgencyService
    {
        Task<AgencyDto> GetByIdAsync(Guid id);
        Task<IEnumerable<AgencyDto>> GetAllAsync();        
        Task<Guid> CreateAsync(AgencyCreateDto dto);
        Task AddAsync(Agency agency);
        Task UpdateAsync(Guid id, AgencyUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
