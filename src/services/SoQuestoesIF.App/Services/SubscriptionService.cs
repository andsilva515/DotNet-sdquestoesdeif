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
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PagSeguroPaymentService _paymentService; // Use DI para injetar
        private readonly IMapper _mapper;

        public SubscriptionService(
            ISubscriptionRepository subscriptionRepository,
            IPaymentRepository paymentRepository,
            IUnitOfWork unitOfWork,
            PagSeguroPaymentService paymentService,
            IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<string> CreateSubscriptionAndCheckoutAsync(Guid userId, SubscriptionCreateDto dto)
        {
            // Cria assinatura inativa
            var subscription = new Subscription
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Type = dto.Type,
                IsActive = false,
                Price = dto.Price,
                StartDate = DateTime.MinValue,
                EndDate = null
            };
            await _subscriptionRepository.AddAsync(subscription);

            // Cria checkout no gateway
            var checkoutUrl = await _paymentService.CreateCheckoutAsync(userId, subscription.Id);

            // Cria pagamento aguardando
            var payment = new Payment
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ProductId = subscription.Id,
                Amount = dto.Price,
                Method = EnumPaymentMethod.PagSeguro,
                GatewayTransactionId = subscription.Id.ToString(), // Ex: pode usar o ID como referência
                Status = "Aguardando",
                PaidAt = DateTime.MinValue
            };
            await _paymentRepository.AddAsync(payment);

            await _unitOfWork.CommitAsync();
            return checkoutUrl;
        }

        public async Task ActivateSubscriptionAsync(Guid subscriptionId)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(subscriptionId);
            if (subscription == null)
                throw new Exception("Assinatura não encontrada");

            subscription.IsActive = true;
            subscription.StartDate = DateTime.UtcNow;
            subscription.EndDate = subscription.Type == SubscriptionType.Monthly
                ? DateTime.UtcNow.AddMonths(1)
                : DateTime.UtcNow.AddYears(1);

            _subscriptionRepository.Update(subscription);
            await _unitOfWork.CommitAsync();
        }
    }

}
