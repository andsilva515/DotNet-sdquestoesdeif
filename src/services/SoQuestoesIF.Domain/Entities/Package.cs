using SoQuestoesIF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Entities
{
    public class Package
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DurationDays { get; set; }
        public Guid PositionId { get; set; }
        public Guid SubjectId { get; set; }
        public PackageType Type { get; set; }
        public ICollection<PackagePurchase> PackagePurchases { get; set; } = new List<PackagePurchase>();
        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}
