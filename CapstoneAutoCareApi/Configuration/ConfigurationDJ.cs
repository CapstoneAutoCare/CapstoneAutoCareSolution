using CapstoneAutoCareApi.Middlewares;
using Infrastructure.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using System.Text;

namespace CapstoneAutoCareApi.Configuration
{
    public static class ConfigurationDJ
    {
        public static IServiceCollection DependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            //var appConfiguration = configuration.GetSection("ConnectString").Get<AppConfiguration>();
            var jwt = configuration.GetSection("JWT").Get<JWToken>();

            services.AddDJJWT(jwt.JWTSecretKey, jwt.Issuer, jwt.Audience);
            services.AddSingleton(jwt);

            //services.AddDJService(appConfiguration.DatabaseConnection);
            //services.AddSingleton(appConfiguration);
            services.AddDJSwagger();
            // ADD MIDDLEWARE
            services.AddSingleton<GlobalExceptionMiddleware>();
            services.AddSwaggerGen();
            services.AddHealthChecks();
            services.AddSingleton<Stopwatch>();
            return services;
        }
        public static IServiceCollection AddDJSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web.WebApi", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyHeader().AllowAnyOrigin()
                           .AllowAnyMethod();
                });
            });
            return services;
        }
        public static IServiceCollection AddDJJWT(this IServiceCollection services, string JWTSecretKey, string Issuer, string Audience)
        {
            var secretKeyBytes = Encoding.UTF8.GetBytes(JWTSecretKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(jwtBearerOptions =>
           {
               jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = Issuer,
                   ValidAudience = Audience,
                   IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
                   ClockSkew = TimeSpan.Zero
               };
           });
            services.AddMemoryCache();
            return services;
        }
    }
}
