using FluentAssertions.Common;
using SoQuestoesIF.App.Mappings;
using SoQuestoesIF.Domain.Interfaces;
using SoQuestoesIF.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
services.AddScoped<IUserRepository, UserRepository>();


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
