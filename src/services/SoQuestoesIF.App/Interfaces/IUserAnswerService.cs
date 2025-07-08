using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface IUserAnswerService
    {
        Task<UserAnswerDto> GetByIdAsync(Guid id);
        Task<IEnumerable<UserAnswerDto>> GetAllByUserAsync(Guid userId);
        Task<Guid> CreateAsync(UserAnswerCreateDto dto);
    }
}
