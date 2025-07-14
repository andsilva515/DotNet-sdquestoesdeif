using Microsoft.EntityFrameworkCore;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Infra.Data.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;
        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Payment payment)
            => await _context.Payments.AddAsync(payment);

        public async Task<Payment?> GetByGatewayTransactionIdAsync(string transactionId)
            => await _context.Payments
                .FirstOrDefaultAsync(p => p.GatewayTransactionId == transactionId);

        public void Update(Payment payment)
            => _context.Payments.Update(payment);
    }
}
