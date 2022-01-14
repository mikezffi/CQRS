using Domain.Models;
using Infrastructure.Configurations;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories;
using Services.Services;
using Services.Services.Interfaces;
using AutoMapper;
using Services.Mappings;
using Core.CQRS;
using Infrastructure.Bus;
using Domain.Commands;
using Domain.Handlers.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

builder.Services.AddDbContext<ConfigurationContext>(options => options.UseMySql(connectionString, serverVersion));

//AutoMapper Configuration
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IService, Service<Customer>>();
builder.Services.AddScoped<IRepository<Customer>, Repository<Customer>>();
builder.Services.AddScoped<IBus, InMemoryBus>();

builder.Services.AddScoped<IHandler<CreateCustomerCommand>, CustomerCommandHandler>();
builder.Services.AddScoped<IHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
builder.Services.AddScoped<IHandler<RemoveCustomerCommand>, CustomerCommandHandler>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();