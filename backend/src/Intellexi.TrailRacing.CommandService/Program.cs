using Intellexi.TrailRacing.Application;
using Intellexi.TrailRacing.CommandService;
using Intellexi.TrailRacing.Persistence;
using Intellexi.TrailRacing.RabbitMq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddWebApi()
    .AddErrorHandling()
    .AddMediator()
    .AddValidation()
    .AddPersistence(builder.Configuration)
    .AddRabbitMq(builder.Configuration)
    .AddCorsPolicy();

var app = builder.Build();

app
    .UseErrorHandling()
    .UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

namespace Intellexi.TrailRacing.CommandService
{
    public class Program
    {
    }
}