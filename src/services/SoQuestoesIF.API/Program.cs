using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SoQuestoesIF.API.Workers;
using SoQuestoesIF.App.Interfaces;
using SoQuestoesIF.App.Mappings;
using SoQuestoesIF.App.Services;
using SoQuestoesIF.Domain.Interfaces;
using SoQuestoesIF.Domain.Services;
using SoQuestoesIF.Infra.Data;
using SoQuestoesIF.Infra.Data.Repositories;
using SoQuestoesIF.Infra.DependencyInjection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ⚠️ Valida que a chave JWT está configurada e Validar se Issuer e Audience estão vazios.

var jwtKey = builder.Configuration["Jwt:Key"];
if (string.IsNullOrWhiteSpace(jwtKey))
    throw new InvalidOperationException("A configuração 'Jwt:Key' não foi definida.");

var jwtIssuer = builder.Configuration["Jwt:Issuer"];
if (string.IsNullOrWhiteSpace(jwtIssuer))
    throw new InvalidOperationException("A configuração 'Jwt:Issuer' não foi definida.");

var jwtAudience = builder.Configuration["Jwt:Audience"];
if (string.IsNullOrWhiteSpace(jwtAudience))
    throw new InvalidOperationException("A configuração 'Jwt:Audience' não foi definida.");

var key = Encoding.ASCII.GetBytes(jwtKey);

// ✅ Configura autenticação JWT (somente UMA vez)
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// Serviço de background (Worker) que roda de tempos em tempos (por exemplo, todo dia à meia-noite), Hosted Service.

builder.Services.AddHostedService<SubscriptionExpirationWorker>();
builder.Services.AddScoped<ISubscriptionExpirationService, SubscriptionExpirationService>();


// Adiciona controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("https://sdquestoesdeif.vercel.app")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

// UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Repositórios e Serviços
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IPasswordResetTokenRepository, PasswordResetTokenRepository>();
builder.Services.AddScoped<IPasswordResetTokenService, PasswordResetTokenService>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();

builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<IPackageService, PackageService>();
builder.Services.AddScoped<IPackagePurchaseRepository, PackagePurchaseRepository>();
builder.Services.AddScoped<IUserQuestionResolutionRepository, UserQuestionResolutionRepository>();
builder.Services.AddScoped<IQuestionAccessService, QuestionAccessService>();

builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IAlternativeRepository, AlternativeRepository>();
builder.Services.AddScoped<IAlternativeService, AlternativeService>();
builder.Services.AddScoped<IAgencyRepository, AgencyRepository>();
builder.Services.AddScoped<IAgencyService, AgencyService>();
builder.Services.AddScoped<IExamBoardRepository, ExamBoardRepository>();
builder.Services.AddScoped<IExamBoardService, ExamBoardService>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<IEducationLevelRepository, EducationLevelRepository>();
builder.Services.AddScoped<IEducationLevelService, EducationLevelService>();
builder.Services.AddScoped<ITopicRepository, TopicRepository>();
builder.Services.AddScoped<ITopicService, TopicService>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ISubjectService, SubjectService>();

builder.Services.AddScoped<IExamRepository, ExamRepository>();
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<ICommentUserRepository, CommentUserRepository>();
builder.Services.AddScoped<ICommentUserService, CommentUserService>();
builder.Services.AddScoped<ICommentTeacherRepository, CommentTeacherRepository>();
builder.Services.AddScoped<ICommentTeacherService, CommentTeacherService>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<IYearRepository, YearRepository>();
builder.Services.AddScoped<IYearService, YearService>();
builder.Services.AddScoped<IQuestionSetRepository, QuestionSetRepository>();
builder.Services.AddScoped<IQuestionSetService, QuestionSetService>();
builder.Services.AddScoped<IUserAnswerRepository, UserAnswerRepository>();
builder.Services.AddScoped<IUserAnswerService, UserAnswerService>();
builder.Services.AddScoped<IEmailSenderService, EmailSenderService>();
builder.Services.AddScoped<IPasswordResetTokenService, PasswordResetTokenService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPackageService, PackageService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<IPaymentService, PagSeguroPaymentService>();
builder.Services.AddScoped<IPaymentService, MercadoPagoPaymentService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped(typeof(Lazy<>), typeof(LazyResolver<>));

// Criação do app
var app = builder.Build();

// Pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS
app.UseCors(MyAllowSpecificOrigins);

// Autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
