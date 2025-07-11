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
        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Alternative> Alternatives { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<QuestionSet> QuestionSets { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<CommentUser> CommentUsers { get; set; }
        public DbSet<Subject> Subjects { get; set; }   
        public DbSet<Agency> Agencies { get; set; }           
        public DbSet<ExamBoard> ExamBoards { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<QuestionSetQuestion> QuestionSetQuestions { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<CommentTeacher> CommentTeachers { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackagePurchase> PackagePurchases { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);        }


        public string ObterStringConexao()
        {
            return "Host=localhost;Port=5432;Database=soquestoes;Username=admin;Password=admin";
        }
    }
}
