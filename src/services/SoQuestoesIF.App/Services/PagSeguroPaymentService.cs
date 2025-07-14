using Microsoft.AspNetCore.Http;
using SoQuestoesIF.App.Interfaces;
using SoQuestoesIF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Services
{
    public class PagSeguroPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ISubscriptionService _subscriptionService;
        private readonly IUnitOfWork _unitOfWork;

        public PagSeguroPaymentService(
            IPaymentRepository paymentRepository,
            ISubscriptionService subscriptionService,
            IUnitOfWork unitOfWork)
        {
            _paymentRepository = paymentRepository;
            _subscriptionService = subscriptionService;
            _unitOfWork = unitOfWork;
        }

        public Task<string> CreateCheckoutAsync(Guid userId, Guid subscriptionId)
        {
            // TODO: Integração real com a API PagSeguro
            return Task.FromResult($"https://pagseguro.uol.com.br/checkout?reference={subscriptionId}");
        }

        public async Task HandleWebhookAsync(HttpRequest request)
        {
            // TODO: Validar assinatura do webhook (ex.: verificar HMAC, token de segurança etc.)

            // Obtém o transactionId de forma segura
            var transactionId = request.Query["reference"].FirstOrDefault();

            if (string.IsNullOrWhiteSpace(transactionId))
                throw new Exception("Identificador de transação ausente.");

            // Carrega o pagamento
            var payment = await _paymentRepository.GetByGatewayTransactionIdAsync(transactionId);
            if (payment == null)
                throw new Exception("Pagamento não encontrado.");

            // Atualiza dados do pagamento
            payment.Status = "Pago";
            payment.PaidAt = DateTime.UtcNow;
            _paymentRepository.Update(payment);

            // Aqui é importante confirmar: o ProductId representa a assinatura a ser ativada?
            // Se sim, tudo bem. Se não, ajuste para ativar corretamente.
            await _subscriptionService.ActivateSubscriptionAsync(payment.ProductId);

            // Commit
            await _unitOfWork.CommitAsync();
        }

    }
}

