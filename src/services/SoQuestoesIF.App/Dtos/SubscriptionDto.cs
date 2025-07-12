using SoQuestoesIF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Dtos
{
    public class SubscriptionDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
    }

    public class SubscriptionCreateDto
    {
        public SubscriptionType Type { get; set; }
        public decimal Price { get; set; }
    }

    public class PackageDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DurationDays { get; set; }
        public string Type { get; set; } = string.Empty;
    }

    public class PackageCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DurationDays { get; set; }
        public PackageType Type { get; set; }
    }

    public class PackagePurchaseDto
    {
        public Guid PackageId { get; set; }
        public decimal Price { get; set; }
    }

}
