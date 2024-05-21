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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IAccountRepository,AccountRepositoryImp>();
builder.Services.AddTransient<IAdminRepository, AdminRepositoryImp>();
builder.Services.AddTransient<ICustomerService, CustomerServiceImp>();
builder.Services.AddTransient<IAdminService, AdminServiceImp>();
builder.Services.AddAutoMapper(typeof(ApplicationMapper).Assembly);

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
