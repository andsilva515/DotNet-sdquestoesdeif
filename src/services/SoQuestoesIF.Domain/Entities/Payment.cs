using SoQuestoesIF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Amount { get; set; }
        public EnumPaymentMethod Method { get; set; }
        public string GatewayTransactionId { get; set; }
        public DateTime PaidAt { get; set; }
        public string Status { get; set; }
    }
}
