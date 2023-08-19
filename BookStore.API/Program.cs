using BookStore.Core.Entities;
using BookStore.Services;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);


ConfigureServices.RegisterServices(builder.Services, builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddDbContext<nonstopioContext>(options =>
//{
 //   options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
//});
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

app.UseAuthorization();

app.MapControllers();

app.Run();
