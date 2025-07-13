using AutoMapper;
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
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubscriptionService(
            ISubscriptionRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubscriptionDto>> GetUserSubscriptionsAsync(Guid userId)
        {
            var subs = await _repository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<SubscriptionDto>>(subs);
        }

        public async Task<Guid> CreateSubscriptionAsync(Guid userId, SubscriptionCreateDto dto)
        {
            var sub = new Subscription
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Type = dto.Type,
                StartDate = DateTime.UtcNow,
                EndDate = dto.Type == SubscriptionType.Monthly ? DateTime.UtcNow.AddMonths(1) : DateTime.UtcNow.AddYears(1),
                IsActive = true,
                Price = dto.Price
            };

            await _repository.AddAsync(sub);
            await _unitOfWork.CommitAsync();
            return sub.Id;
        }

        public async Task<SubscriptionDto> GetByIdAsync(Guid id)
        {
            var subscription = await _repository.GetByIdAsync(id);
            if (subscription is null)
                throw new Exception("Assinatura não encontrada.");

            return _mapper.Map<SubscriptionDto>(subscription);
        }

    }

}
