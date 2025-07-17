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
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasOne(s => s.User)
                   .WithMany(u => u.Subscriptions)
                   .HasForeignKey(s => s.UserId);

            builder.HasOne(s => s.Package)
                   .WithMany(p => p.Subscriptions)
                   .HasForeignKey(s => s.PackageId);
        }
    }

}
