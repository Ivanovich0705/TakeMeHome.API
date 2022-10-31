using System.Configuration;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using TakeMeHome.API.TakeMeHome.Domain.Models;
using TakeMeHome.API.TakeMeHome.Domain.Repositories;
using TakeMeHome.API.TakeMeHome.Domain.Services;
using TakeMeHome.API.TakeMeHome.Mapping;
using TakeMeHome.API.TakeMeHome.Persistence.Contexts;
using TakeMeHome.API.TakeMeHome.Persistence.Repositories;
using TakeMeHome.API.TakeMeHome.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
        options => options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors());

//Add lower case routes
builder.Services.AddRouting(options=> options.LowercaseUrls = true);

//Dependency Injection Configuration
builder.Services.AddScoped<IUserRepository, CategoryRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
builder.Services.AddScoped<IOrderStatusService, OrderStatusService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile), 
    typeof(ResourceToModelProfile));

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