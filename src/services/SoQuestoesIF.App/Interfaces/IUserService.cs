using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface IUserService
    {     
        Task AddAsync(User user);
        Task UpdateAsync(Guid id, UserUpdateDto dto);
        Task DeleteAsync(Guid id);
        Task<UserDto> GetByIdAsync(Guid id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<Guid> CreateAsync(UserCreateDto dto);       
        Task<UserDto> AuthenticateAsync(string email, string password);
    }
}
