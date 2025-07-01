using AutoMapper;
using MediaBrowser.Model.Dto;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Enums;
using SoQuestoesIF.Domain.Interfaces;
using SoQuestoesIF.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDto = SoQuestoesIF.App.Dtos.UserDto;

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
        public async Task<MediaBrowser.Model.Dto.UserDto> GetByIdAsync(Guid id)
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
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Usuário não encontrado.");

            entity.FullName = dto.FullName;
            entity.Role = dto.Role;
            entity.Status = dto.Status;

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
}





    //public async task<user> getbyidasync(guid id)
    //{
    //    return await _repository.getbyidasync(id);
    //}               
    //public async task<ienumerable<user>> getallasync()
    //{
    //    return await _repository.getallasync();
    //}
    //public async task addasync(user entity)
    //{
    //    await _repository.addasync(entity);
    //    await _unitofwork.commitasync();
    //}
    //public async task updateasync(user entity)
    //{
    //    _repository.update(entity);
    //    await _unitofwork.commitasync();
    //}
    //public async task deleteasync(guid id)
    //{
    //    var entity = await _repository.getbyidasync(id);
    //    if (entity != null)
    //    {     
    //        _repository.delete(entity);
    //        await _unitofwork.commitasync();
    //    }
}   
    }
}
