using CleanArchitectureWorkshop.Application;
using CleanArchitectureWorkshop.Domain.Entities;
using CleanArchitectureWorkshop.Domain.TeamAggregate;
using CleanArchitectureWorkshop.Infrastructure;
using CleanArchitectureWorkshop.Presentation.Api.Teams;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationLayerServices();
builder.Services.AddInfrastructureLayerService();
// builder.Configuration.GetConnectionString("SqlTestConnectionString");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}

app.UseBlazorFrameworkFiles();
app.MapFallbackToFile("index.html");
app.UseStaticFiles();

app.UseHttpsRedirection();

app.RegisterTeamsEndpoints();

app.Run();