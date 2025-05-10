using Acme.Ecommerce.Application.Interface;
using Acme.Ecommerce.Application.Main;
using Acme.Ecommerce.Domain.Core;
using Acme.Ecommerce.Domain.Interface;
using Acme.Ecommerce.Infrastructure.Data;
using Acme.Ecommerce.Infrastructure.Interface;
using Acme.Ecommerce.Infrastructure.Repository;
using Acme.Ecommerce.Services.WebApi.Settings;
using Acme.Ecommerce.Transversal.Common;
using Acme.Ecommerce.Transversal.Mapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

builder.Services.AddAutoMapper(x => x.AddProfile<MappingProfiles>());
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
    });

// AppSettings
AppSettings appSettings = builder.Configuration.Get<AppSettings>() ?? throw new Exception("Some settings are missing");
builder.Services.AddSingleton(appSettings);

builder.Services
    .AddSingleton<IConnectionFactory, ConnectionFactory>()
    .AddScoped<ICustomerApplication, CustomerApplication>()
    .AddScoped<ICustomerDomain, CustomerDomain>()
    .AddScoped<ICustomerRepository, CustomerRepository>()
    .AddScoped<IUserApplication, UserApplication>()
    .AddScoped<IUserDomain, UserDomain>()
    .AddScoped<IUserRepository, UserRepository>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(policyBuilder => policyBuilder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
