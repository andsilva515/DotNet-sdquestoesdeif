using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SoQuestoesIF.App.Interfaces;
using SoQuestoesIF.App.Mappings;
using SoQuestoesIF.App.Services;
using SoQuestoesIF.Domain.Interfaces;
using SoQuestoesIF.Domain.Services;
using SoQuestoesIF.Infra.Data;
using SoQuestoesIF.Infra.Data.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configura JSON Web Tokens - JWT

var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Iterfaces e Repositórios
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
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
builder.Services.AddScoped<IQuestionSetRepository, QuestionSetRepository>();
builder.Services.AddScoped<IQuestionSetService, QuestionSetService>();
builder.Services.AddScoped<IUserAnswerRepository, UserAnswerRepository>();
builder.Services.AddScoped<IUserAnswerService, UserAnswerService>();
builder.Services.AddScoped<ICommentTeacherRepository, CommentTeacherRepository>();
builder.Services.AddScoped<ICommentTeacherService, CommentTeacherService>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<IYearRepository, YearRepository>();
builder.Services.AddScoped<IYearService, YearService>();

// Contexto Base

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configuração CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins(
                "https://sdquestoesdeif.vercel.app/"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

app.UseHttpsRedirection();

// Configuração CORS
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
