using Microsoft.EntityFrameworkCore;
using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Alternative> Alternatives { get; set; }
        public DbSet<CommentUser> CommentUsers { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamBoard> ExamBoards { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<QuestionSet> QuestionSets { get; set; }
        public DbSet<QuestionSetQuestion> QuestionSetQuestions { get; set; }  
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Topic> Topics { get; set; }    
        public DbSet<UserAnswer> UserAnswers { get; set; }

        //public DbSet<Product> Products { get; set; }

        //public DbSet<UserAccess> UserAccesses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
