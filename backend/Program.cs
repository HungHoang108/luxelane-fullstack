using System.Text.Json.Serialization;
using Luxelane.Db;
using Luxelane.DTOs;
using Luxelane.DTOs.AddressDto;
using Luxelane.DTOs.OrderDto;
using Luxelane.DTOs.OrderProductDto;
using Luxelane.DTOs.ProductDto;
using Luxelane.DTOs.UserDto;
using Luxelane.Models;
using Luxelane.Services.Impl;
using Luxelane.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

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

//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Authetication
builder.Services
    .AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
    {
        options.Password.RequiredLength = 6;
    })
    .AddEntityFrameworkStores<DataContext>();

builder.Services.AddScoped<ICrudService<User, UserDTO, OutputUserDTO>, CrudService<User, UserDTO, OutputUserDTO>>();
builder.Services.AddScoped<ICrudService<Address, AddressDTO, OutputAddressDTO>, CrudService<Address, AddressDTO, OutputAddressDTO>>();
builder.Services.AddScoped<ICrudService<Order, OrderDTO, OutputOrderDTO>, CrudService<Order, OrderDTO, OutputOrderDTO>>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICrudService<Product, ProductDTO, OutputProductDTO>, CrudService<Product, ProductDTO, OutputProductDTO>>();
builder.Services.AddScoped<ICrudService<OrderProduct, OrderProductDTO, OutputOrderProductDTO>, CrudService<OrderProduct, OrderProductDTO, OutputOrderProductDTO>>();

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
