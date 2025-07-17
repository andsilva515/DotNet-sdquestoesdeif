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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            // Enum -> string
            builder.Property(q => q.QuestionType).HasConversion<string>();
            builder.Property(q => q.QuestionDifficulty).HasConversion<string>();
            builder.Property(q => q.QuestionStatus).HasConversion<string>();

            // Relações N:1
            builder.HasOne(q => q.Agency)
                   .WithMany()
                   .HasForeignKey(q => q.AgencyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(q => q.ExamBoard)
                   .WithMany()
                   .HasForeignKey(q => q.ExamBoardId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(q => q.Position)
                   .WithMany()
                   .HasForeignKey(q => q.PositionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(q => q.Subject)
                   .WithMany()
                   .HasForeignKey(q => q.SubjectId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(q => q.Topic)
                   .WithMany()
                   .HasForeignKey(q => q.TopicId)
                   .OnDelete(DeleteBehavior.Restrict);

            // 1:N com Alternatives
            builder.HasMany(q => q.Alternatives)
                   .WithOne(a => a.Question)
                   .HasForeignKey(a => a.QuestionId)
                   .OnDelete(DeleteBehavior.Cascade);

            // 1:N com CommentsUsers
            builder.HasMany(q => q.CommentsUsers)
                   .WithOne(c => c.Question)
                   .HasForeignKey(c => c.QuestionId)
                   .OnDelete(DeleteBehavior.Cascade);
        
        }
    }
}
