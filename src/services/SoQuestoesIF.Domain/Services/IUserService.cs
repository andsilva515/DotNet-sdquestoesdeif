using MediaBrowser.Model.Dto;
using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Services
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User entity);
        Task UpdateAsync(User entity);
        Task DeleteAsync(Guid id);
        Task<UserDto> GetByIdAsync(Guid id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<Guid> CreateAsync(UserCreateDto dto);       
        Task<UserDto> AuthenticateAsync(string email, string password);
    }
}
