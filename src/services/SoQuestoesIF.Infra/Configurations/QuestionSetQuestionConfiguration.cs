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
    public class QuestionSetQuestionConfiguration : IEntityTypeConfiguration<QuestionSetQuestion>
    {
        public void Configure(EntityTypeBuilder<QuestionSetQuestion> builder)
        {
            builder.HasKey(qsq => new { qsq.QuestionSetId, qsq.QuestionId });

            builder.HasOne(qsq => qsq.QuestionSet)
                   .WithMany(qs => qs.QuestionSetQuestions)
                   .HasForeignKey(qsq => qsq.QuestionSetId);

            builder.HasOne(qsq => qsq.Question)
                   .WithMany(q => q.QuestionSetQuestions)
                   .HasForeignKey(qsq => qsq.QuestionId);
        }
    }
}
