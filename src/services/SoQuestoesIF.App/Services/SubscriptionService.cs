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
        private readonly IEnumerable<IPaymentService> _paymentServices;
        private readonly IMapper _mapper;

        public SubscriptionService(
            ISubscriptionRepository subscriptionRepository,
            IPaymentRepository paymentRepository,
            IUnitOfWork unitOfWork,
            IEnumerable<IPaymentService> paymentServices,
            IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
            _paymentServices = paymentServices;
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
            var paymentMethod = dto.PaymentMethod;
            var paymentService = GetPaymentService(paymentMethod);
            var checkoutUrl = await paymentService.CreateCheckoutAsync(userId, subscription.Id);

            // Cria pagamento aguardando
            var payment = new Payment
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ProductId = subscription.Id,
                Amount = dto.Price,
                Method = paymentMethod,
                GatewayTransactionId = subscription.Id.ToString(), // Pode ser substituído por ID real da transação se houver
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
        private IPaymentService GetPaymentService(EnumPaymentMethod method)
        {
            return method switch
            {
                EnumPaymentMethod.PagSeguro => _paymentServices.FirstOrDefault(s => s is PagSeguroPaymentService),
                EnumPaymentMethod.MercadoPago => _paymentServices.FirstOrDefault(s => s is MercadoPagoPaymentService),
                _ => throw new ArgumentException("Método de pagamento inválido", nameof(method))
            };
        }

    }

}
