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
    public class MercadoPagoPaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MercadoPagoPaymentService(
            IPaymentRepository paymentRepository,
            IUnitOfWork unitOfWork)
        {
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<string> CreateCheckoutAsync(Guid userId, Guid productId)
        {
            // TODO: Integração real com MercadoPago
            return Task.FromResult($"https://mercadopago.com/checkout?reference={productId}");
        }

        public async Task HandleWebhookAsync(HttpRequest request)
        {
            // TODO: Validar assinatura do webhook

            // Exemplo simples
            var transactionId = request.Query["reference"].FirstOrDefault();

            if (string.IsNullOrWhiteSpace(transactionId))
                throw new Exception("Identificador de transação ausente.");


            var payment = await _paymentRepository.GetByGatewayTransactionIdAsync(transactionId);
            if (payment == null)
                throw new Exception("Pagamento não encontrado");

            payment.Status = "Pago";
            payment.PaidAt = DateTime.UtcNow;
            _paymentRepository.Update(payment);

            await _unitOfWork.CommitAsync();
        }
    }
}
