using Infrastructure.IService.Imp;
using Infrastructure.IService;
using Infrastructure.IUnitofWork.Imp;
using Infrastructure.IUnitofWork;
using Microsoft.Identity.Client;
using Domain.Entities;
using Application.IRepository;
using Application.IRepository.Imp;
using Application;
using CapstoneAutoCareApi.Middlewares;
using Infrastructure.ISecurity;
using Infrastructure.ISecurity.Imp;
using CapstoneAutoCareApi.Configuration;
using Infrastructure.Common.Mapper;

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

//Maintenance Schedule
builder.Services.AddTransient<IMaintananceScheduleRepository, MaintananceScheduleRepositoryImp>();
builder.Services.AddTransient<IMaintenanceScheduleService, MaintenanceScheduleServiceImp>();


//Vehicles 
builder.Services.AddTransient<IVehiclesRepository, VehiclesRepositoryImp>();
builder.Services.AddTransient<IVehiclesService, VehiclesServiceImp>();


// Booking 
builder.Services.AddTransient<IBookingRepository, BookingRepositoryImp>();
builder.Services.AddTransient<IBookingService, BookingServiceImp>();


//SparePart
builder.Services.AddTransient<ISparePartsRepository, SparePartsRepositoryImp>();
builder.Services.AddTransient<ISparePartsService, SparePartsServiceImp>();

//SparePartItem
builder.Services.AddTransient<ISparePartsItemRepository, SparePartsItemRepositoryImp>();
builder.Services.AddTransient<ISparePartsItemService, SparePartsItemServiceImp>();


//Services Care
builder.Services.AddTransient<IServiceCareRepository, ServiceCareRepositoryImp>();
builder.Services.AddTransient<IServiceCaresService, ServicesCaresSerivceImp>();

//Maintanance Services
builder.Services.AddTransient<IMaintenanceServiceRepository, ServiceCareCostRepositoryImp>();
builder.Services.AddTransient<IMaintananceServicesService, MaintananceServicesServiceImp>();

//Maintanance Information
builder.Services.AddTransient<IMaintenanceInformationService, MaintenanceInformationServiceImp>();
builder.Services.AddTransient<IInformationMaintenanceRepository, InformationMaintenanceRepositoryImp>();

//Maintanance Information MSI
builder.Services.AddTransient<IMaintenanceServiceInfoRepository, MaintenanceServiceInfoRepositoryImp>();
builder.Services.AddTransient<IMaintenanceServiceInfoService, MaintenanceServiceInfoServiceImp>();

builder.Services.AddTransient<ISparePartsItemCostRepository, SparePartsItemCostRepositoryImp>();
builder.Services.AddTransient<IMaintenanceServiceCostRepository, MaintenanceServiceCostRepositoryImp>();

//Maintanance Information MSPI
builder.Services.AddTransient<IMaintenanceSparePartInfoRepository, MaintenanceSparePartInfoRepositoryImp>();
builder.Services.AddTransient<IMaintenanceHistoryStatusService, MaintenanceHistoryStatusServiceImp>();

builder.Services.AddTransient<IMaintenanceSparePartInfoService, MaintenanceSparePartInfoServiceImp>();

//Maintanance Technican  
builder.Services.AddTransient<ITechnicianRepository, TechnicianMnRepositoryImp>();
builder.Services.AddTransient<IMaintenanceTechinicanService, MaintenanceTechinicanServiceImp>();

builder.Services.AddTransient<ISparePartsItemCostRepository, SparePartsItemCostRepositoryImp>();
builder.Services.AddTransient<IMaintenanceServiceCostRepository, MaintenanceServiceCostRepositoryImp>();

builder.Services.AddTransient<ISparePartsItemCostService, SparePartsItemCostServiceImp>();
builder.Services.AddTransient<IMaintananceServicesCostService, MaintananceServicesCostServiceImp>();


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
