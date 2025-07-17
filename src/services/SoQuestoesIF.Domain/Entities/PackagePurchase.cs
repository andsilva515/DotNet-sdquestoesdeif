using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Entities
{
    public class PackagePurchase
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid PackageId { get; set; }
        public Package Package { get; set; } = null!;
        public DateTime PurchaseDate { get; set; }  
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
