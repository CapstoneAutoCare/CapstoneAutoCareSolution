﻿using Infrastructure.IService.Imp;
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
using Newtonsoft.Json.Converters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Infrastructure.Hubs;
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
//builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>();
#region ADD
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IVehiclesMaintenanceRepository, VehiclesMaintenanceRepositoryImp>();
builder.Services.AddTransient<IVehiclesMaintenanceService, VehiclesMaintenanceServiceImp>();

builder.Services.AddTransient<IAccountRepository, AccountRepositoryImp>();
builder.Services.AddTransient<IAccountService, AccountServiceImp>();

builder.Services.AddTransient<IFeedBackRepository, FeedBackRepositoryImp>();
builder.Services.AddTransient<IFeedBackService, FeedbackServiceImp>();
builder.Services.AddScoped<IEmailService, EmailServiceImp>();
builder.Services.AddScoped<IPaymentPayPalService, PaymentPayPalServiceImp>();

builder.Services.AddTransient<ICustomerService, CustomerServiceImp>();

builder.Services.AddTransient<IVehicleModelRepository, VehicleModelRepositoryImp>();
builder.Services.AddTransient<IVehicleModelService, VehicleModelImp>();


builder.Services.AddTransient<IVehiclesBrandRepository, VehiclesBrandRepositoryImp>();
builder.Services.AddTransient<IVehicleBrandService, VehicleBrandImp>();

builder.Services.AddTransient<ICenterService, CenterServiceImp>();
builder.Services.AddTransient<IMaintenanceCenterRepository, MaintenanceCenterRepositoryImp>();

builder.Services.AddTransient<ITechicianRepository, TechnicianRepositoryImp>();
builder.Services.AddTransient<ITechnicianService, TechicianServiceImp>();

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
builder.Services.AddTransient<IMaintenanceTaskRepository, MaintenanceTaskRepositoryImp>();
builder.Services.AddTransient<IMaintenanceTechinicanService, MaintenanceTechinicanServiceImp>();

builder.Services.AddTransient<ISparePartsItemCostRepository, SparePartsItemCostRepositoryImp>();
builder.Services.AddTransient<IMaintenanceServiceCostRepository, MaintenanceServiceCostRepositoryImp>();

builder.Services.AddTransient<ISparePartsItemCostService, SparePartsItemCostServiceImp>();
builder.Services.AddTransient<IMaintananceServicesCostService, MaintananceServicesCostServiceImp>();


builder.Services.AddTransient<IOdoHistoryRepository, OdoHistoryRepositoryImp>();
builder.Services.AddTransient<IOdoHistoryService, OdoHistoryServiceImp>();

builder.Services.AddTransient<IReceiptRepository, ReceiptRepositoryImp>();
builder.Services.AddTransient<IReceiptsService, ReceiptsServiceImp>();

builder.Services.AddTransient<IMaintenanceTaskServiceInfoRepository, MaintenanceTaskServiceInfoRepositoryImp>();
builder.Services.AddTransient<IMaintenanceTaskSparePartInfoRepository, MaintenanceTaskSparePartInfoRepositoryImp>();


builder.Services.AddTransient<IMaintenanceTaskServiceInfoService, MaintenanceTaskServiceInfoServiceImp>();

builder.Services.AddTransient<IMaintenanceTaskSparePartInfoService, MaintenanceTaskSparePartInfoServiceImp>();
builder.Services.AddTransient<ITransactionRepository, TransactionRepositoryImp>();
builder.Services.AddTransient<ITransactionService, TransactionServiceImp>();


builder.Services.AddTransient<INotificationRepository, NotificationRepositoryImp>();
builder.Services.AddTransient<INotificationSerivce, NotificationServiceImp>();

builder.Services.AddTransient<IMaintenancePlanService, MaintenancePlanServiceImp>();
builder.Services.AddTransient<IMaintenancePlanRepository, MaintenancePlanRepositoryImp>();

builder.Services.AddTransient<IMaintenanceVehiclesDetailService, MaintenanceVehiclesDetailServiceImp>();
builder.Services.AddTransient<IMaintenanceVehiclesDetailRepository, MaintenanceVehiclesDetailRepositoryImp>();


builder.Services.AddScoped<ITokensHandler, TokensHandler>();
#endregion

builder.Services.AddAutoMapper(typeof(ApplicationMapper).Assembly);
builder.Services.AddHttpContextAccessor();


//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(builder =>
//    {
//        builder.AllowAnyHeader()
//            .AllowAnyOrigin()
//            .AllowAnyMethod();
//    });
//});


builder.Services.AddHttpClient();
//builder.Services.AddSignalR();
//builder.Services.AddSignalRCore();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}
app.UseMiddleware<GlobalExceptionMiddleware>();


app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigins");
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
//app.MapHub<NotificationHub>("/notificationHub");
app.MapHub<VehicleHub>("/vehicleHub");


app.Run();
