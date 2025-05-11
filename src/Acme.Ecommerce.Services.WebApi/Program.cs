using System.Text;
using Acme.Ecommerce.Application.Interface;
using Acme.Ecommerce.Application.Main;
using Acme.Ecommerce.Domain.Core;
using Acme.Ecommerce.Domain.Interface;
using Acme.Ecommerce.Infrastructure.Data;
using Acme.Ecommerce.Infrastructure.Interface;
using Acme.Ecommerce.Infrastructure.Repository;
using Acme.Ecommerce.Services.WebApi.Settings;
using Acme.Ecommerce.Transverse.Common;
using Acme.Ecommerce.Transverse.Logging;
using Acme.Ecommerce.Transverse.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

// JSON Web Token configuration
byte[] key = Encoding.UTF8.GetBytes(appSettings.Security.Token.Secret);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                int userId = int.Parse(context.Principal.Identity.Name);
                return Task.CompletedTask;
            },
            OnAuthenticationFailed = context =>
            {
                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                {
                    context.Response.Headers.Add("Token-Expired", "true");
                }

                return Task.CompletedTask;
            }
        };
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = appSettings.Security.Token.Issuer,
            ValidateAudience = true,
            ValidAudience = appSettings.Security.Token.Audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services
    .AddSingleton<IConnectionFactory, ConnectionFactory>()
    .AddScoped<ICustomerApplication, CustomerApplication>()
    .AddScoped<ICustomerDomain, CustomerDomain>()
    .AddScoped<ICustomerRepository, CustomerRepository>()
    .AddScoped<IUserApplication, UserApplication>()
    .AddScoped<IUserDomain, UserDomain>()
    .AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Acme E-commerce API",
            Version = "v1",
            Description = "REST API for Acme E-commerce"
        });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme."
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                []
            }
        });
    });

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
