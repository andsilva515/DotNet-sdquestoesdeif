using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using SoQuestoesIF.App.Mappings;
using SoQuestoesIF.App.Services;
using SoQuestoesIF.Domain.Interfaces;
using SoQuestoesIF.Domain.Services;
using SoQuestoesIF.Infra.Data;
using SoQuestoesIF.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuestionService, QuestionService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program));


object value = builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

var builder = WebApplication.CreateBuilder(args);



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
