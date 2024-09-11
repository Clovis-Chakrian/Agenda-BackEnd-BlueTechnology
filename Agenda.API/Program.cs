using System;
using Agenda.API.Data;
using Agenda.API.Repository;
using Agenda.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// var DB_USER = Environment.GetEnvironmentVariable("DB_USER") ?? throw new Exception("Env variable DB_USER");
// var DB_PASSWORD = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? throw new Exception("Env variable DB_PASSWORD");
// var DB_HOST = Environment.GetEnvironmentVariable("DB_HOST") ?? throw new Exception("Env variable DB_HOST");
// var DB_PORT = Environment.GetEnvironmentVariable("DB_PORT") ?? throw new Exception("Env variable DB_PORT");
// var DB_DATABASE = Environment.GetEnvironmentVariable("DB_DATABASE") ?? throw new Exception("Env variable DB_DATABASE");

// var connectionString = $"User id={DB_USER}; Password={DB_PASSWORD}; Host={DB_HOST}; Port={DB_PORT}; Database={DB_DATABASE}";
var connectionString = $"";

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ContactContext>(options => {
    options.UseNpgsql(connectionString);
});
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

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
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.Run();