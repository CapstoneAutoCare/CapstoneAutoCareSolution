using Infrastructure.IService.Imp;
using Infrastructure.IService;
using Infrastructure.IUnitofWork.Imp;
using Infrastructure.IUnitofWork;
using Microsoft.Identity.Client;
using Domain.Entities;
using Application.IRepository;
using Application.IRepository.Imp;
using Application;
using Infrastructure.Common.Mapper;
using CapstoneAutoCareApi.Middlewares;
using Infrastructure.ISecurity;
using Infrastructure.ISecurity.Imp;
using CapstoneAutoCareApi.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();
builder.Services.DependencyInjection(configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IAccountRepository, AccountRepositoryImp>();
builder.Services.AddTransient<IAccountService, AccountServiceImp>();

builder.Services.AddTransient<IAdminRepository, AdminRepositoryImp>();
builder.Services.AddTransient<IAdminService, AdminServiceImp>();

builder.Services.AddTransient<ICustomerService, CustomerServiceImp>();

builder.Services.AddTransient<IVehicleModelRepository, VehicleModelRepositoryImp>();
builder.Services.AddTransient<IVehicleModelService, VehicleModelImp>();


builder.Services.AddTransient<IVehiclesBrandRepository, VehiclesBrandRepositoryImp>();
builder.Services.AddTransient<IVehicleBrandService, VehicleBrandImp>();

builder.Services.AddTransient<ICenterService, CenterServiceImp>();
builder.Services.AddTransient<IMaintenanceCenterRepository, MaintenanceCenterRepositoryImp>();

builder.Services.AddTransient<IStaffCareRepository, StaffCareRepositoryImp>();
builder.Services.AddTransient<IStaffCareService, StaffCareServiceImp>();

builder.Services.AddTransient<ICustomerCareRepository, CustomerCareRepositoryImp>();
builder.Services.AddTransient<ICustomerCareService, CustomerCareServiceImp>();


builder.Services.AddScoped<ITokensHandler, TokensHandler>();


builder.Services.AddAutoMapper(typeof(ApplicationMapper).Assembly);
builder.Services.AddHttpContextAccessor();


//builder.Services.AddCors(c => c
//            .AddDefaultPolicy(b => b
//            .AllowAnyHeader()
//            .AllowAnyMethod()
//            .AllowAnyOrigin()));
builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
