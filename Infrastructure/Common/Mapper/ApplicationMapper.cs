using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.ModelSecurity;
using Infrastructure.Common.Request.MaintananceServices;
using Infrastructure.Common.Request.MaintenancePlan;
using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Request.RequestVehicles;
using Infrastructure.Common.Request.VehicleModel;
using Infrastructure.Common.Request.VehicleRequest;
using Infrastructure.Common.Response;
using Infrastructure.Common.Response.ReponseMaintenancePlan;
using Infrastructure.Common.Response.ReponseMaintenanceSchedule;
using Infrastructure.Common.Response.ReponseServicesCare;
using Infrastructure.Common.Response.ReponseSparePart;
using Infrastructure.Common.Response.ReponseVehicleModel;
using Infrastructure.Common.Response.ResponseAdmin;
using Infrastructure.Common.Response.ResponseCenter;
using Infrastructure.Common.Response.ResponseClient;
using Infrastructure.Common.Response.ResponseCustomerCare;
using Infrastructure.Common.Response.ResponseStaffCare;
using Infrastructure.Common.Response.ResponseVehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            //CREATE CLIENT

            CreateMap<CreateClient, Client>()
            .ForMember(c => c.Address, act => act.MapFrom(src => src.Address))
            .ForMember(c => c.FirstName, act => act.MapFrom(src => src.FirstName))
            .ForMember(c => c.LastName, act => act.MapFrom(src => src.LastName))
            .ForMember(c => c.Birthday, act => act.MapFrom(src => src.Birthday))
            .ForMember(p => p.Account, act => act.MapFrom(src => new Account
            {
                Logo = src.Logo,
                Gender = src.Gender,
                Password = src.Password,
                Phone = src.Phone,
                Email = src.Email
            }));


            //CREATE ADMIN

            CreateMap<CreateAdmin, Admin>()
            .ForMember(p => p.Account, act => act.MapFrom(src => new Account
            {
                Logo = src.Logo,
                Gender = src.Gender,
                Password = src.Password,
                Phone = src.Phone,
                Email = src.Email
            }));

            // CREATE CUSTOMER CARE
            CreateMap<CreateCustomerCare, CustomerCare>()
            .ForMember(c => c.Address, act => act.MapFrom(src => src.Address))
            .ForMember(c => c.FirstName, act => act.MapFrom(src => src.FirstName))
            .ForMember(c => c.LastName, act => act.MapFrom(src => src.LastName))
            .ForMember(c => c.Birthday, act => act.MapFrom(src => src.Birthday))
            .ForMember(p => p.Account, act => act.MapFrom(src => new Account
            {
                Logo = src.Logo,
                Gender = src.Gender,
                Password = src.Password,
                Phone = src.Phone,
                Email = src.Email
            }));


            // CREATE STAFF CARE
            CreateMap<CreateStaffCare, StaffCare>()
            .ForMember(c => c.Address, act => act.MapFrom(src => src.Address))
            .ForMember(c => c.FirstName, act => act.MapFrom(src => src.FirstName))
            .ForMember(c => c.LastName, act => act.MapFrom(src => src.LastName))
            .ForMember(c => c.Birthday, act => act.MapFrom(src => src.Birthday))
            .ForMember(p => p.Account, act => act.MapFrom(src => new Account
            {
                Logo = src.Logo,
                Gender = src.Gender,
                Password = src.Password,
                Phone = src.Phone,
                Email = src.Email
            }));


            CreateMap<CreateCenter, MaintenanceCenter>()
            .ForMember(c => c.Address, act => act.MapFrom(src => src.Address))
            .ForMember(c => c.MaintenanceCenterName, act => act.MapFrom(src => src.MaintenanceCenterName))
            .ForMember(c => c.MaintenanceCenterDescription, act => act.MapFrom(src => src.MaintenanceCenterDescription))
            .ForMember(c => c.District, act => act.MapFrom(src => src.District))
            .ForMember(c => c.City, act => act.MapFrom(src => src.City))
            .ForMember(c => c.Country, act => act.MapFrom(src => src.Country))
            .ForMember(p => p.Account, act => act.MapFrom(src => new Account
            {
                Logo = src.Logo,
                Gender = src.Gender,
                Password = src.Password,
                Phone = src.Phone,
                Email = src.Email
            }));


            CreateMap<Admin, ResponseAdmin>()
            .ForMember(c => c.Email, act => act.MapFrom(src => src.Account.Email))
            .ForMember(c => c.AccountId, act => act.MapFrom(src => src.AccountId))
            .ForMember(c => c.AdminId, act => act.MapFrom(src => src.AdminId))
            .ForMember(c => c.Password, act => act.MapFrom(src => src.Account.Password))
            .ForMember(c => c.Logo, act => act.MapFrom(src => src.Account.Logo))
            .ForMember(c => c.Status, act => act.MapFrom(src => src.Account.Status))
            .ForMember(c => c.CreatedDate, act => act.MapFrom(src => src.Account.CreatedDate))
            .ForMember(c => c.Gender, act => act.MapFrom(src => src.Account.Gender))
            .ForMember(c => c.Phone, act => act.MapFrom(src => src.Account.Phone))
            .ForMember(c => c.Role, act => act.MapFrom(src => src.Account.Role));



            CreateMap<Client, ResponseClient>()
            .ForMember(c => c.Email, act => act.MapFrom(src => src.Account.Email))
            .ForMember(c => c.AccountId, act => act.MapFrom(src => src.AccountId))
            .ForMember(c => c.ClientId, act => act.MapFrom(src => src.ClientId))
            .ForMember(c => c.Password, act => act.MapFrom(src => src.Account.Password))
            .ForMember(c => c.Logo, act => act.MapFrom(src => src.Account.Logo))
            .ForMember(c => c.Status, act => act.MapFrom(src => src.Account.Status))
            .ForMember(c => c.CreatedDate, act => act.MapFrom(src => src.Account.CreatedDate))
            .ForMember(c => c.Gender, act => act.MapFrom(src => src.Account.Gender))
            .ForMember(c => c.Phone, act => act.MapFrom(src => src.Account.Phone))
            .ForMember(c => c.Role, act => act.MapFrom(src => src.Account.Role))
            .ForMember(c => c.Address, act => act.MapFrom(src => src.Address))
            .ForMember(c => c.FirstName, act => act.MapFrom(src => src.FirstName))
            .ForMember(c => c.LastName, act => act.MapFrom(src => src.LastName))
            .ForMember(c => c.Birthday, act => act.MapFrom(src => src.Birthday));


            CreateMap<MaintenanceCenter, ResponseCenter>()
            .ForMember(c => c.Email, act => act.MapFrom(src => src.Account.Email))
            .ForMember(c => c.AccountId, act => act.MapFrom(src => src.AccountId))
            .ForMember(c => c.MaintenanceCenterId, act => act.MapFrom(src => src.MaintenanceCenterId))
            .ForMember(c => c.Password, act => act.MapFrom(src => src.Account.Password))
            .ForMember(c => c.Logo, act => act.MapFrom(src => src.Account.Logo))
            .ForMember(c => c.Status, act => act.MapFrom(src => src.Account.Status))
            .ForMember(c => c.CreatedDate, act => act.MapFrom(src => src.Account.CreatedDate))
            .ForMember(c => c.Gender, act => act.MapFrom(src => src.Account.Gender))
            .ForMember(c => c.Phone, act => act.MapFrom(src => src.Account.Phone))
            .ForMember(c => c.Role, act => act.MapFrom(src => src.Account.Role))
            .ForMember(c => c.Address, act => act.MapFrom(src => src.Address))
            .ForMember(c => c.MaintenanceCenterName, act => act.MapFrom(src => src.MaintenanceCenterName))
            .ForMember(c => c.MaintenanceCenterDescription, act => act.MapFrom(src => src.MaintenanceCenterDescription))
            .ForMember(c => c.City, act => act.MapFrom(src => src.City))
            .ForMember(c => c.District, act => act.MapFrom(src => src.District))
            .ForMember(c => c.Country, act => act.MapFrom(src => src.Country));


            // Resonse Staff Care
            CreateMap<StaffCare, ResponseStaffCare>()
            .ForMember(c => c.Email, act => act.MapFrom(src => src.Account.Email))
            .ForMember(c => c.AccountId, act => act.MapFrom(src => src.AccountId))
            .ForMember(c => c.StaffCareId, act => act.MapFrom(src => src.StaffCareId))
            .ForMember(c => c.Password, act => act.MapFrom(src => src.Account.Password))
            .ForMember(c => c.Logo, act => act.MapFrom(src => src.Account.Logo))
            .ForMember(c => c.Status, act => act.MapFrom(src => src.Account.Status))
            .ForMember(c => c.CreatedDate, act => act.MapFrom(src => src.Account.CreatedDate))
            .ForMember(c => c.Gender, act => act.MapFrom(src => src.Account.Gender))
            .ForMember(c => c.Phone, act => act.MapFrom(src => src.Account.Phone))
            .ForMember(c => c.Role, act => act.MapFrom(src => src.Account.Role))
            .ForMember(c => c.Address, act => act.MapFrom(src => src.Address))
            .ForMember(c => c.FirstName, act => act.MapFrom(src => src.FirstName))
            .ForMember(c => c.LastName, act => act.MapFrom(src => src.LastName))
            .ForMember(c => c.StaffCareDescription, act => act.MapFrom(src => src.StaffCareDescription))
            .ForMember(c => c.Birthday, act => act.MapFrom(src => src.Birthday));

            // Response Customer Care

            CreateMap<CustomerCare, ResponseCustomerCare>()
            .ForMember(c => c.Email, act => act.MapFrom(src => src.Account.Email))
            .ForMember(c => c.AccountId, act => act.MapFrom(src => src.AccountId))
            .ForMember(c => c.CustomerCareId, act => act.MapFrom(src => src.CustomerCareId))
            .ForMember(c => c.Password, act => act.MapFrom(src => src.Account.Password))
            .ForMember(c => c.Logo, act => act.MapFrom(src => src.Account.Logo))
            .ForMember(c => c.Status, act => act.MapFrom(src => src.Account.Status))
            .ForMember(c => c.CreatedDate, act => act.MapFrom(src => src.Account.CreatedDate))
            .ForMember(c => c.Gender, act => act.MapFrom(src => src.Account.Gender))
            .ForMember(c => c.Phone, act => act.MapFrom(src => src.Account.Phone))
            .ForMember(c => c.Role, act => act.MapFrom(src => src.Account.Role))
            .ForMember(c => c.Address, act => act.MapFrom(src => src.Address))
            .ForMember(c => c.FirstName, act => act.MapFrom(src => src.FirstName))
            .ForMember(c => c.LastName, act => act.MapFrom(src => src.LastName))
            .ForMember(c => c.CustomerCareDescription, act => act.MapFrom(src => src.CustomerCareDescription))
            .ForMember(c => c.Birthday, act => act.MapFrom(src => src.Birthday));


            CreateMap<AccessToken, AuthenResponseMessToken>()
                .ForMember(p => p.Token, act => act.MapFrom(src => src.Token))
                .ForMember(p => p.Expiration, act => act.MapFrom(src => src.ExpirationTicks))
                .ForMember(p => p.RefreshToken, act => act.MapFrom(src => src.RefreshToken.Token));
            //Vehicle Brand



            CreateMap<VehiclesBrand, VehicleBrandUpdate>().ForMember(p => p.BrandName, act => act.MapFrom(src => src.VehiclesBrandName));


            //VehicleModels

            CreateMap<CreateVehicleModel, VehicleModel>()
                .ForMember(p => p.VehicleModelName, act => act.MapFrom(src => src.VehicleModelName))
                .ForMember(p => p.VehiclesBrandId, act => act.MapFrom(src => src.VehiclesBrandId))
                .ForMember(p => p.Image, act => act.MapFrom(src => src.Image));


            CreateMap<VehicleModel, UpdateVehicleModel>()
                .ForMember(p => p.VehicleModelName, act => act.MapFrom(src => src.VehicleModelName))
                .ForMember(p => p.VehiclesBrandId, act => act.MapFrom(src => src.VehicleModelName))
                .ForMember(p => p.Image, act => act.MapFrom(src => src.Image));


            CreateMap<VehicleModel, ResponseVehicleModel>()
                .ForMember(p => p.VehiclesBrandName, act => act.MapFrom(src => src.VehiclesBrand.VehiclesBrandName))
                .ForMember(p => p.VehicleModelId, act => act.MapFrom(src => src.VehicleModelId))
                .ForMember(p => p.VehicleModelName, act => act.MapFrom(src => src.VehicleModelName))
                .ForMember(p => p.VehiclesBrandId, act => act.MapFrom(src => src.VehiclesBrandId))
                .ForMember(p => p.Image, act => act.MapFrom(src => src.Image))
                .ForMember(p => p.CreatedDate, act => act.MapFrom(src => src.CreatedDate))
                .ForMember(p => p.Status, act => act.MapFrom(src => src.Status));


            // Create Vehicle
            CreateMap<CreateVehicle, Vehicles>()
               //.ForMember(p => p.VehicleModelId, act => act.MapFrom(src => src.VehicleModelId))
               .ReverseMap();


            CreateMap<Vehicles, ResponseVehicles>()
               .ForMember(p => p.VehiclesBrandName, act => act.MapFrom(src => src.VehicleModel.VehiclesBrand.VehiclesBrandName))
               .ForMember(p => p.VehicleModelName, act => act.MapFrom(src => src.VehicleModel.VehicleModelName))
               .ForPath(p => p.VehiclesBrandId, act => act.MapFrom(src => src.VehicleModel.VehiclesBrandId))
               //.ForMember(p => p.Color, act => act.MapFrom(src => src.Color))
               //.ForMember(p => p.Description, act => act.MapFrom(src => src.Description))
               .ReverseMap();

            //Maintenance Schedule
            CreateMap<CreateMaintenanceSchedule, MaintananceSchedule>()
                .ForMember(p => p.Odo, act => act.MapFrom(src => src.Odo))
                .ForMember(p => p.Description, act => act.MapFrom(src => src.Description))
                .ForMember(p => p.VehicleModelId, act => act.MapFrom(src => src.VehicleModelId));

            CreateMap<MaintananceSchedule, ResponseMaintenanceSchedule>()
                .ForMember(p => p.MaintananceScheduleId, act => act.MapFrom(src => src.MaintananceScheduleId))
                .ForMember(p => p.Odo, act => act.MapFrom(src => src.Odo))
                .ForMember(p => p.Description, act => act.MapFrom(src => src.Description))
                .ForMember(p => p.CreateDate, act => act.MapFrom(src => src.CreateDate))
                .ForMember(p => p.VehicleModelId, act => act.MapFrom(src => src.VehicleModelId))
                .ForMember(p => p.VihecleModelName, act => act.MapFrom(src => src.VehicleModel.VehicleModelName));
            #endregion

            #region Maintanance Plan
            CreateMap<CreateMaintanancePlan, MaintenancePlan>()
                .ForMember(p => p.MaintenancePlanName, act => act.MapFrom(src => src.MaintenancePlanName))
                .ForMember(p => p.MaintenancePlanDescription, act => act.MapFrom(src => src.MaintenancePlanDescription))
                .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))
                .ForMember(p => p.MaintananceScheduleId, act => act.MapFrom(src => src.MaintananceScheduleId));

            CreateMap<MaintenancePlan, ResponseMaintenancePlan>()
                .ForMember(p => p.MaintenancePlanId, act => act.MapFrom(src => src.MaintenancePlanId))
                .ForMember(p => p.MaintenancePlanName, act => act.MapFrom(src => src.MaintenancePlanName))
                .ForMember(p => p.MaintenancePlanDescription, act => act.MapFrom(src => src.MaintenancePlanDescription))
                .ForMember(p => p.CreateDate, act => act.MapFrom(src => src.CreateDate))
                .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))
                .ForMember(p => p.MaintananceScheduleId, act => act.MapFrom(src => src.MaintananceScheduleId));
            #endregion

            #region Spare Part
            CreateMap<CreateSpareParts, SpareParts>()
                .ForMember(p => p.SparePartName, act => act.MapFrom(src => src.SparePartName))
                .ForMember(p => p.SparePartDescription, act => act.MapFrom(src => src.SparePartDescription))
                .ForMember(p => p.SparePartType, act => act.MapFrom(src => src.SparePartType))
                .ForMember(p => p.OriginalPrice, act => act.MapFrom(src => src.OriginalPrice))
                .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))
                .ForMember(p => p.MaintenancePlanId, act => act.MapFrom(src => src.MaintenancePlanId));
            CreateMap<SpareParts, ResponseSparePart>()
                .ForMember(p => p.SparePartId, act => act.MapFrom(src => src.SparePartId))
                .ForMember(p => p.SparePartName, act => act.MapFrom(src => src.SparePartName))
                .ForMember(p => p.SparePartDescription, act => act.MapFrom(src => src.SparePartDescription))
                .ForMember(p => p.SparePartType, act => act.MapFrom(src => src.SparePartType))
                .ForMember(p => p.CreatedDate, act => act.MapFrom(src => src.CreatedDate))
                .ForMember(p => p.OriginalPrice, act => act.MapFrom(src => src.OriginalPrice))
                .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))
                .ForMember(p => p.MaintenancePlanId, act => act.MapFrom(src => src.MaintenancePlanId))
                .ForMember(p => p.MaintenancePlanName, act => act.MapFrom(src => src.MaintenancePlan.MaintenancePlanName));
            #endregion

            #region Sparepart Item
            CreateMap<CreateSparePartsItem, SparePartsItem>()
                .ForMember(p => p.ActuralCost, act => act.MapFrom(src => src.ActuralCost))
                .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))
                .ForMember(p => p.SparePartsId, act => act.MapFrom(src => src.SparePartsId))
                .ForMember(p => p.MaintenanceCenterId, act => act.MapFrom(src => src.MaintenanceCenterId));
            CreateMap<SparePartsItem, ResponseSparePartsItem>()
                .ForMember(p => p.SparePartsItemtId, act => act.MapFrom(src => src.SparePartsItemtId))
                .ForMember(p => p.SparepartName, act => act.MapFrom(src => src.SpareParts.SparePartName))
                .ForMember(p => p.OriginalCost, act => act.MapFrom(src => src.SpareParts.OriginalPrice))
                .ForMember(p => p.ActuralCost, act => act.MapFrom(src => src.ActuralCost))
                .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))
                .ForMember(p => p.CreatedDate, act => act.MapFrom(src => src.CreatedDate))
                .ForMember(p => p.SparePartsId, act => act.MapFrom(src => src.SparePartsId))
                .ForMember(p => p.MaintenanceCenterId, act => act.MapFrom(src => src.MaintenanceCenterId))
                .ForMember(p => p.MaintenanceCenterName, act => act.MapFrom(src => src.MaintenanceCenter.MaintenanceCenterName));
            #endregion

            #region Services Care
            CreateMap<CreateServicesCare, ServiceCare>()
                .ForMember(p => p.ServiceCareName, act => act.MapFrom(src => src.ServiceCareName))
                .ForMember(p => p.ServiceCareDescription, act => act.MapFrom(src => src.ServiceCareDescription))
                .ForMember(p => p.ServiceCareType, act => act.MapFrom(src => src.ServiceCareType))
                .ForMember(p => p.OriginalPrice, act => act.MapFrom(src => src.OriginalPrice))
                .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))
                .ForMember(p => p.MaintenancePlanId, act => act.MapFrom(src => src.MaintenancePlanId));
            CreateMap<ServiceCare, ResponseServicesCare>()
                .ForMember(p => p.ServiceCareId, act => act.MapFrom(src => src.ServiceCareId))
                .ForMember(p => p.ServiceCareName, act => act.MapFrom(src => src.ServiceCareName))
                .ForMember(p => p.ServiceCareDescription, act => act.MapFrom(src => src.ServiceCareDescription))
                .ForMember(p => p.ServiceCareType, act => act.MapFrom(src => src.ServiceCareType))
                .ForMember(p => p.CreatedDate, act => act.MapFrom(src => src.CreatedDate))
                .ForMember(p => p.OriginalPrice, act => act.MapFrom(src => src.OriginalPrice))
                .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))
                .ForMember(p => p.MaintenancePlanId, act => act.MapFrom(src => src.MaintenancePlanId))
                .ForMember(p => p.MaintenancePlanName, act => act.MapFrom(src => src.MaintenancePlan.MaintenancePlanName));
            #endregion

            #region Maintanance Service
            CreateMap<CreateMaintananceServices, MaintenanceService>()
                .ForMember(p => p.MaintenanceServiceId, act => act.MapFrom(src => src.MaintenanceServiceId))
                .ForMember(p => p.ActuralCost, act => act.MapFrom(src => src.ActuralCost))
                .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))
                .ForMember(p => p.ServiceCareId, act => act.MapFrom(src => src.ServiceCareId))
                .ForMember(p => p.MaintenanceCenterId, act => act.MapFrom(src => src.MaintenanceCenterId));
            CreateMap<MaintenanceService, ResponseMaintananceServices>()
                .ForMember(p => p.MaintenanceServiceId, act => act.MapFrom(src => src.MaintenanceServiceId))
                .ForMember(p => p.ServicesCareName, act => act.MapFrom(src => src.ServiceCare.ServiceCareName))
                .ForMember(p => p.OriginalCost, act => act.MapFrom(src => src.ServiceCare.OriginalPrice))
                .ForMember(p => p.ActuralCost, act => act.MapFrom(src => src.ActuralCost))
                .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))
                .ForMember(p => p.CreatedDate, act => act.MapFrom(src => src.CreatedDate))
                .ForMember(p => p.ServiceCareId, act => act.MapFrom(src => src.ServiceCareId))
                .ForMember(p => p.MaintenanceCenterId, act => act.MapFrom(src => src.MaintenanceCenterId))
                .ForMember(p => p.MaintenanceCenterName, act => act.MapFrom(src => src.MaintenanceCenter.MaintenanceCenterName));
            #endregion
        }
    }
}
