using FirstWebApi;
using FirstWebApi.Config;
using FirstWebApi.Data;
using FirstWebApi.Services;
using FirstWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddConfig(builder.Configuration)
    .AddMyDependencyGroup();

//builder.Services.AddScoped<ICategoryRepository, CategoryRepositoryInMemory>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
