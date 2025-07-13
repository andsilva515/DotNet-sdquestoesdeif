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
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Alternative> Alternatives { get; set; } = null!;
        public DbSet<Exam> Exams { get; set; } = null!;
        public DbSet<QuestionSet> QuestionSets { get; set; } = null!;
        public DbSet<QuestionSetQuestion> QuestionSetQuestions { get; set; } = null!;
        public DbSet<UserAnswer> UserAnswers { get; set; } = null!;  
        public DbSet<CommentUser> CommentUsers { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<Agency> Agencies { get; set; } = null!;
        public DbSet<ExamBoard> ExamBoards { get; set; } = null!;
        public DbSet<EducationLevel> EducationLevels { get; set; } = null!;
        public DbSet<Topic> Topics { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;  
        public DbSet<Year> Years { get; set; } = null!;
        public DbSet<State> States { get; set; } = null!;
        public DbSet<CommentTeacher> CommentTeachers { get; set; } = null!;
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; } = null!;
        public DbSet<ExamQuestion> ExamQuestions { get; set; } = null!;
        public DbSet<Subscription> Subscriptions { get; set; } = null!;
        public DbSet<Package> Packages { get; set; } = null!;
        public DbSet<PackagePurchase> PackagePurchases { get; set; } = null!;
        public DbSet<UserQuestionResolutionLog> UserQuestionResolutionLogs { get; set; } = null!;


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
            base.OnModelCreating(modelBuilder);

            // Índice único para impedir múltiplos registros por dia por usuário
            modelBuilder.Entity<UserQuestionResolutionLog>()
                .HasIndex(x => new { x.UserId, x.Date })
                .IsUnique();

            // Você pode ter outros configurations aqui
            // Por exemplo:
            // modelBuilder.Entity<Subscription>().Property(x => x.Type).HasConversion<string>();

        }

        public string ObterStringConexao()
        {
            return "Host=localhost;Port=5432;Database=soquestoes;Username=admin;Password=admin";
        }
    }
}
