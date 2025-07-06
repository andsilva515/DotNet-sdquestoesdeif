using AutoMapper;
using Org.BouncyCastle.Crypto.Generators;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.App.Interfaces;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Enums;
using SoQuestoesIF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Services
{
    public class UserService : IUserService
   {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repositoty, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repositoty;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(entity);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<Guid> CreateAsync(UserCreateDto dto)
        {
            // Simples hash fake, substitua por um serviço de hash seguro
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var entity = new User
            {
                Id = Guid.NewGuid(),
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = passwordHash,
                Role = dto.Role,
                Status = EnumUserStatus.Active,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(Guid id, UserUpdateDto dto)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null)
                throw new Exception("Usuário não encontrado.");

            user.FullName = dto.FullName;
            user.Role = dto.Role;
            user.Status = dto.Status;

            if (!string.IsNullOrEmpty(dto.Password))
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            _repository.Update(user);
            await _unitOfWork.CommitAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Usuário não encontrado.");

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<UserDto> AuthenticateAsync(string email, string password)
        {
            var entity = await _repository.GetByEmailAsync(email);
            if (entity == null)
                throw new Exception("Usuário ou senha inválidos.");

            var isValid = BCrypt.Net.BCrypt.Verify(password, entity.PasswordHash);
            if (!isValid)
                throw new Exception("Usuário ou senha inválidos.");

            entity.LastLoginAt = DateTime.UtcNow;
            await _unitOfWork.CommitAsync();

            return _mapper.Map<UserDto>(entity);
        }

        public async Task AddAsync(User user)
        {
            await _repository.AddAsync(user);
            await _unitOfWork.CommitAsync();
        }
    }
}   
 