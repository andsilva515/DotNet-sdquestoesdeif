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
    public class CommentTeacherConfiguration : IEntityTypeConfiguration<CommentTeacher>
    {
        public void Configure(EntityTypeBuilder<CommentTeacher> builder)
        {
            builder.HasOne(ct => ct.Question)
                   .WithMany(q => q.CommentTeachers)
                   .HasForeignKey(ct => ct.QuestionId);
        }
    }
}
