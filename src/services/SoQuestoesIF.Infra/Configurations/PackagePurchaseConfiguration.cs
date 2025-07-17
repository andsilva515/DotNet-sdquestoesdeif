using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Infra.Configurations
{
    public class PackagePurchaseConfiguration : IEntityTypeConfiguration<PackagePurchase>
    {
        public void Configure(EntityTypeBuilder<PackagePurchase> builder)
        {
            builder.HasOne(pp => pp.User)
                   .WithMany(u => u.PackagePurchases)
                   .HasForeignKey(pp => pp.UserId);

            builder.HasOne(pp => pp.Package)
                   .WithMany(p => p.PackagePurchases)
                   .HasForeignKey(pp => pp.PackageId);
        }
    }

}
