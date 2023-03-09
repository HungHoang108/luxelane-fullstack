using System.Text.Json.Serialization;
using Luxelane.Db;
using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Services.Impl;
using Luxelane.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        // Fix the JSON cycle issue
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddDbContext<DataContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICrudService<User, UserDTO>, CrudService<User, UserDTO>>();
builder.Services.AddScoped<ICrudService<Address, AddressDTO>, CrudService<Address, AddressDTO>>();
builder.Services.AddScoped<ICrudService<Order, OrderDTO>, CrudService<Order, OrderDTO>>();
builder.Services.AddScoped<IOrderService, OrderService>();


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
