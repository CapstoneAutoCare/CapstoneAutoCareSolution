using CapstoneAutoCareApi.Middlewares;
using Infrastructure.Common;
using Infrastructure.Common.Payment;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
            var email = configuration.GetSection("MailConfigurations").Get<SendEmail>();
            var paypal = configuration.GetSection("PayPal").Get<PaymentPayPall>();
            var vnPay = configuration.GetSection("VnPay").Get<ConfiVnPay>();
            services.AddScoped<VnPayLibrary>();
            services.AddSingleton<NotificationHub>();

            services.AddDJJWT(jwt.JWTSecretKey, jwt.Issuer, jwt.Audience);
            services.AddSingleton(jwt);
            services.AddSingleton(email);
            services.AddSingleton(paypal);
            services.AddSingleton(vnPay);
            services.AddSignalR(options =>
            {
                options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
                options.KeepAliveInterval = TimeSpan.FromSeconds(30);
            });

            //services.AddDJService(appConfiguration.DatabaseConnection);
            //services.AddSingleton(appConfiguration);
            services.AddDJSwagger();
            // ADD MIDDLEWARE
            services.AddSingleton<GlobalExceptionMiddleware>();
            services.AddSwaggerGen();
            services.AddHealthChecks();
            services.AddControllersWithViews();

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
                //c.OperationFilter<EnumSchemaFilter>();

                

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
            services.Configure<JsonSerializerSettings>(options =>
            {
                options.Converters.Add(new StringEnumConverter());
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins", builder =>
                {
                    builder.WithOrigins("http://localhost:3000", "http://localhost:3001", "https://webautocare.vercel.app") // Chỉ định các origin mà bạn muốn cho phép
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials(); // Chỉ cho phép credentials nếu cần
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
