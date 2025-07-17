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
    public class UserQuestionResolutionLogConfiguration : IEntityTypeConfiguration<UserQuestionResolutionLog>
    {
        public void Configure(EntityTypeBuilder<UserQuestionResolutionLog> builder)
        {
            builder.HasIndex(x => new { x.UserId, x.Date }).IsUnique();
        }
    }

}
