using SoQuestoesIF.Domain.Interfaces;
using SoQuestoesIF.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository  _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepositoty repositoty, IUnitOfWork unitOfWork)
        {
            _repository = repositoty;
            _unitOfWork = unitOfWork;
        }
        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }               
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task AddAsync(User entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }
        public async Task UpdateAsync(User entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {     
                _repository.Delete(entity);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
