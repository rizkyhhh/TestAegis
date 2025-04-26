using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Setup Rotativa sebelum app.Run
RotativaConfiguration.Setup(
    Directory.GetCurrentDirectory(), 
    "Rotativa" 
);

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
