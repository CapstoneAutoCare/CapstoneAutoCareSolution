﻿using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.ModelSecurity;
using Infrastructure.Common.Request;
using Infrastructure.Common.Request.MaintananceServices;
using Infrastructure.Common.Request.MaintenancePlan;
using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Request.ReceiptRequest;
using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Request.RequestBooking;
using Infrastructure.Common.Request.RequestFb;
using Infrastructure.Common.Request.RequestMaintenanceHistoryStatus;
using Infrastructure.Common.Request.RequestMaintenanceInformation;
using Infrastructure.Common.Request.RequestMaintenanceServiceCost;
using Infrastructure.Common.Request.RequestMaintenanceServiceInfo;
using Infrastructure.Common.Request.RequestMaintenanceSparePartInfor;
using Infrastructure.Common.Request.RequestMaintenanceTechinican;
using Infrastructure.Common.Request.RequestMainVehicleDetail;
using Infrastructure.Common.Request.RequestOdo;
using Infrastructure.Common.Request.RequestSparePartsItemCost;
using Infrastructure.Common.Request.RequestVehicleBrandRequest;
using Infrastructure.Common.Request.RequestVehicles;
using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Request.VehicleBrandRequest;
using Infrastructure.Common.Request.VehicleModel;
using Infrastructure.Common.Response;
using Infrastructure.Common.Response.ClientResponse;
using Infrastructure.Common.Response.OdoResponse;
using Infrastructure.Common.Response.ReceiptResponse;
using Infrastructure.Common.Response.ReponseVehicleModel;
using Infrastructure.Common.Response.ResponseAdmin;
using Infrastructure.Common.Response.ResponseBooking;
using Infrastructure.Common.Response.ResponseCost;
using Infrastructure.Common.Response.ResponseCustomerCare;
using Infrastructure.Common.Response.ResponseFb;
using Infrastructure.Common.Response.ResponseHistoryStatus;
using Infrastructure.Common.Response.ResponseMainInformation;
using Infrastructure.Common.Response.MaintenancePlanResponse;
using Infrastructure.Common.Response.ResponseMaintenanceSchedule;
using Infrastructure.Common.Response.ResponseMaintenanceService;
using Infrastructure.Common.Response.ResponseMaintenanceSparePart;
using Infrastructure.Common.Response.ResponseMVD;
using Infrastructure.Common.Response.ResponseServicesCare;
using Infrastructure.Common.Response.ResponseSparePart;
using Infrastructure.Common.Response.ResponseStaffCare;
using Infrastructure.Common.Response.ResponseTechnicanMain;
using Infrastructure.Common.Response.VehiclesResponse;
using Microsoft.AspNetCore.ResponseCompression;
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
            CreateMap<CreateTechnician, Technician>()
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
            CreateMap<Technician, ResponseTechnician>()
            .ForMember(c => c.Email, act => act.MapFrom(src => src.Account.Email))
            .ForMember(c => c.AccountId, act => act.MapFrom(src => src.AccountId))
            .ForMember(c => c.TechnicianId, act => act.MapFrom(src => src.TechnicianId))
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
            .ForMember(c => c.TechnicianDescription, act => act.MapFrom(src => src.TechnicianDescription))
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
            .ForMember(c => c.CentreId, act => act.MapFrom(src => src.CenterId))
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


            CreateMap<VehicleModel, ReponseVehicleModels>()
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
                .ForMember(p => p.Description, act => act.MapFrom(src => src.Description))
                .ForMember(p => p.MaintenancePlanId, act => act.MapFrom(src => src.MaintenancePlanId))
                .ReverseMap();

            CreateMap<MaintananceSchedule, ResponseMaintenanceSchedules>()

                .ForMember(p => p.MaintenancePlanId, act => act.MapFrom(src => src.MaintenancePlanId))
                .ForMember(p => p.MaintenancePlanName, act => act.MapFrom(src => src.MaintenancePlan.MaintenancePlanName))

                .ForMember(p => p.VehicleModelId, act => act.MapFrom(src => src.MaintenancePlan.VehicleModel.VehicleModelId))
                .ForMember(p => p.VehicleModelName, act => act.MapFrom(src => src.MaintenancePlan.VehicleModel.VehicleModelName))
                .ForMember(p => p.VehiclesBrandId, act => act.MapFrom(src => src.MaintenancePlan.VehicleModel.VehiclesBrandId))
                .ForMember(p => p.VehiclesBrandName, act => act.MapFrom(src => src.MaintenancePlan.VehicleModel.VehiclesBrand.VehiclesBrandName))
                .ReverseMap();


            #region Booking

            CreateMap<RequestBooking, Booking>()
                .ForMember(p => p.VehicleId, act => act.MapFrom(src => src.VehicleId))
                .ForMember(p => p.MaintenanceCenterId, act => act.MapFrom(src => src.MaintenanceCenterId))
                //.ForMember(p => p.MaintananceScheduleId, act => act.MapFrom(src => src.MaintananceScheduleId))


                .ReverseMap();

            CreateMap<CreateBookingPackage, Booking>()
                //.ForMember(p => p.VehicleId, act => act.MapFrom(src => src.VehicleId))
                //.ForMember(p => p.MaintenanceCenterId, act => act.MapFrom(src => src.MaintenanceCenterId))
                //.ForMember(p => p.MaintananceScheduleId, act => act.MapFrom(src => src.MaintananceScheduleId))

                .ReverseMap();

            CreateMap<CreateMaintenanceBooking, Booking>()
               //.ForMember(p => p.MaintananceScheduleId, act => act.MapFrom(src => src.MaintananceScheduleId))
               .ReverseMap();


            CreateMap<RequestBookingHaveItems, Booking>()
                .ForMember(p => p.MaintenanceInformations, act => act.MapFrom(src => src.CreateMaintenanceInformationHaveItemsByClient))
                //.ForMember(p => p.MaintananceScheduleId, act => act.MapFrom(src => src.MaintananceScheduleId))
                .ReverseMap();
            CreateMap<Booking, ResponseBooking>()
                .ForMember(p => p.ResponseMaintenanceInformation, act => act.MapFrom(src => src.MaintenanceInformations.ToList()))
                .ForMember(p => p.MaintenancePlanName, act => act.MapFrom(src => src.MaintenancePlan.MaintenancePlanName))
                .ForMember(p => p.ResponseClient, act => act.MapFrom(src => src.Client))
                .ForMember(p => p.ResponseCenter, act => act.MapFrom(src => src.MaintenanceCenter))
                .ForMember(p => p.ResponseVehicles, act => act.MapFrom(src => src.Vehicles))
                .ReverseMap();
            #endregion


            #region Spare Part
            CreateMap<CreateSpareParts, SpareParts>()
                .ReverseMap();
            CreateMap<SpareParts, ResponseSparePart>()
                .ForMember(p => p.ReponseVehicleModel, act => act.MapFrom(src => src.VehicleModel))
                .ReverseMap();

            CreateMap<UpdateSparePart, SpareParts>()
                .ReverseMap();
            #endregion

            #region Sparepart Item
            CreateMap<CreateSparePartsItem, SparePartsItem>()
                //.ForMember(p => p.ActuralCost, act => act.MapFrom(src => src.ActuralCost))
                .ForMember(p => p.SparePartsId, act => act.MapFrom(src => src.SparePartsId))

                //.ForMember(p => p.MaintenanceCenterId, act => act.MapFrom(src => src.MaintenanceCenterId))
                .ReverseMap();

            CreateMap<UpdateSparePartItem, SparePartsItem>()
                .ReverseMap();

            CreateMap<SparePartsItem, ResponseSparePartsItem>()
                .ForMember(p => p.ResponseSparePartsItemCosts, act => act.MapFrom(src => src.SparePartsItemCost))
                .ForMember(p => p.MaintenanceCenterId, act => act.MapFrom(src => src.MaintenanceCenterId))
                .ForMember(p => p.MaintenanceCenterName, act => act.MapFrom(src => src.MaintenanceCenter.MaintenanceCenterName))
                .ForMember(p => p.VehiclesBrandName, act => act.MapFrom(src => src.SpareParts.VehicleModel.VehiclesBrand.VehiclesBrandName))
                .ForMember(p => p.VehicleModelName, act => act.MapFrom(src => src.SpareParts.VehicleModel.VehicleModelName))
                .ForMember(p => p.VehicleModelId, act => act.MapFrom(src => src.SpareParts.VehicleModelId))
                .ForMember(p => p.VehiclesBrandId, act => act.MapFrom(src => src.SpareParts.VehicleModel.VehiclesBrandId))
                .ReverseMap();
            ;
            #endregion

            #region Services Care
            CreateMap<CreateServicesCare, ServiceCares>()
                .ForMember(p => p.ServiceCareName, act => act.MapFrom(src => src.ServiceCareName))
                .ForMember(p => p.ServiceCareDescription, act => act.MapFrom(src => src.ServiceCareDescription))
                .ForMember(p => p.ServiceCareType, act => act.MapFrom(src => src.ServiceCareType))
                .ForMember(p => p.OriginalPrice, act => act.MapFrom(src => src.OriginalPrice))
                .ForMember(p => p.MaintananceScheduleId, act => act.MapFrom(src => src.MaintananceScheduleId));

            CreateMap<ServiceCares, ResponseServicesCare>()
                .ForMember(p => p.MaintananceScheduleId, act => act.MapFrom(src => src.MaintananceScheduleId))
                .ForMember(p => p.MaintananceScheduleName, act => act.MapFrom(src => src.MaintananceSchedule.MaintananceScheduleName))
                .ForMember(p => p.MaintenancePlanId, act => act.MapFrom(src => src.MaintananceSchedule.MaintenancePlanId))
                .ForMember(p => p.MaintenancePlanName, act => act.MapFrom(src => src.MaintananceSchedule.MaintenancePlan.MaintenancePlanName))
                .ForMember(p => p.ReponseVehicleModel, act => act.MapFrom(src => src.MaintananceSchedule.MaintenancePlan.VehicleModel));
            CreateMap<UpdateServies, ServiceCares>()
                .ReverseMap();
            #endregion

            #region Maintanance Service
            CreateMap<CreateMaintananceServices, MaintenanceService>()
                //.ForMember(p => p.ActuralCost, act => act.MapFrom(src => src.ActuralCost))
                //.ForMember(p => p.MaintenanceServiceName, act => act.MapFrom(src => src.MaintenanceServiceName))
                //.ForMember(p => p.MaintenanceCenterId, act => act.MapFrom(src => src.MaintenanceCenterId))
                .ReverseMap();
            CreateMap<UpdateMaintananceServices, MaintenanceService>()
                .ReverseMap();
            CreateMap<MaintenanceService, ResponseMaintananceServices>()
                .ForMember(p => p.ResponseMaintenanceServiceCosts, act => act.MapFrom(src => src.MaintenanceServiceCosts))
                .ForMember(p => p.MaintenanceCenterName, act => act.MapFrom(src => src.MaintenanceCenter.MaintenanceCenterName))
                .ForMember(p => p.VehiclesBrandName, act => act.MapFrom(src => src.VehicleModel.VehiclesBrand.VehiclesBrandName))
                .ForMember(p => p.VehicleModelName, act => act.MapFrom(src => src.VehicleModel.VehicleModelName))
                .ForMember(p => p.MaintananceScheduleName, act => act.MapFrom(src => src.ServiceCare.MaintananceSchedule.MaintananceScheduleName))
                .ForMember(p => p.MaintananceScheduleId, act => act.MapFrom(src => src.ServiceCare.MaintananceSchedule.MaintananceScheduleId))
                .ForMember(p => p.VehicleModelId, act => act.MapFrom(src => src.VehicleModelId))
                .ForMember(p => p.VehiclesBrandId, act => act.MapFrom(src => src.VehicleModel.VehiclesBrandId))
                .ForMember(p => p.MaintenancePlanId, act => act.MapFrom(src => src.ServiceCare.MaintananceSchedule.MaintenancePlanId))
                .ForMember(p => p.MaintenancePlanName, act => act.MapFrom(src => src.ServiceCare.MaintananceSchedule.MaintenancePlan.MaintenancePlanName))
                .ReverseMap();
            #endregion

            #region MaintenanceInformation
            CreateMap<CreateMaintenanceInformation, MaintenanceInformation>()
            .ReverseMap();

            CreateMap<MaintenanceInformation, ResponseMaintenanceInformation>()
            .ForMember(p => p.ResponseMaintenanceServiceInfos, act => act.MapFrom(src => src.MaintenanceServiceInfos))
            .ForMember(p => p.ResponseMaintenanceSparePartInfos, act => act.MapFrom(src => src.MaintenanceSparePartInfos))
            .ForMember(p => p.ResponseMaintenanceHistoryStatuses, act => act.MapFrom(src => src.MaintenanceHistoryStatuses))
            .ForMember(p => p.ResponseVehicles, act => act.MapFrom(src => src.Booking.Vehicles))
            .ForMember(p => p.DateBooking, act => act.MapFrom(src => src.Booking.BookingDate))

            .ReverseMap();


            CreateMap<CreateMaintenanceInformationHaveItems, MaintenanceInformation>()
            .ForMember(p => p.MaintenanceSparePartInfos, act => act.MapFrom(src => src.CreateMaintenanceSparePartInfos))
            .ForMember(p => p.MaintenanceServiceInfos, act => act.MapFrom(src => src.CreateMaintenanceServiceInfos))
            .ReverseMap();


            CreateMap<CreateMaintenanceInformationHaveItemsByClient, MaintenanceInformation>()
            .ForMember(p => p.MaintenanceSparePartInfos, act => act.MapFrom(src => src.CreateMaintenanceSparePartInfos))
            .ForMember(p => p.MaintenanceServiceInfos, act => act.MapFrom(src => src.CreateMaintenanceServiceInfos))
            .ReverseMap();

            CreateMap<CreateMaintenanceInformationHavePackage, MaintenanceInformation>()
            .ReverseMap();



            #endregion




            #region MaintenanceSparePartInfo
            CreateMap<CreateMaintenanceSparePartInfoHaveItems, MaintenanceSparePartInfo>()
                .ForMember(p => p.SparePartsItemCostId, act => act.MapFrom(src => src.SparePartsItemCostId))
                .ReverseMap();

            CreateMap<CreateMaintenanceSparePartInfo, MaintenanceSparePartInfo>()
                .ForMember(p => p.InformationMaintenanceId, act => act.MapFrom(src => src.MaintenanceInformationId))
                .ForMember(p => p.SparePartsItemCostId, act => act.MapFrom(src => src.SparePartsItemCostId))
                .ReverseMap();

            CreateMap<MaintenanceSparePartInfo, ResponseMaintenanceSparePartInfo>()
                .ForMember(p => p.Image, act => act.MapFrom(src => src.SparePartsItemCost.SparePartsItem.Image))
                .ForMember(p => p.SparePartsItemId, act => act.MapFrom(src => src.SparePartsItemCost.SparePartsItem.SparePartsItemId))
                .ReverseMap();
            #endregion

            #region MaintenanceServiceInfo

            CreateMap<CreateMaintenanceServiceInfoHaveItems, MaintenanceServiceInfo>()
                   //.ForMember(p => p.MaintenanceServiceId, act => act.MapFrom(src => src.MaintenanceServiceId))
                   //.ForMember(p => p.MaintenanceServiceInfoName, act => act.MapFrom(src => src.MaintenanceServiceInfoName))
                   .ReverseMap();

            CreateMap<CreateMaintenanceServiceInfo, MaintenanceServiceInfo>()
                   .ForMember(p => p.InformationMaintenanceId, act => act.MapFrom(src => src.MaintenanceInformationId))
                   .ReverseMap();
            CreateMap<MaintenanceServiceInfo, ResponseMaintenanceServiceInfo>()
                   .ForMember(p => p.Image, act => act.MapFrom(src => src.MaintenanceServiceCost.MaintenanceService.Image))
                   .ForMember(p => p.MaintenanceServiceId, act => act.MapFrom(src => src.MaintenanceServiceCost.MaintenanceService.MaintenanceServiceId))
                   .ReverseMap();
            CreateMap<UpdateMaintenanceServiceInfoHaveItems, MaintenanceServiceInfo>()
                     .ReverseMap();


            #endregion


            #region MaintenanceHistoryStatus
            CreateMap<CreateMaintenanceHistoryStatus, MaintenanceHistoryStatus>()
                   .ReverseMap();

            CreateMap<MaintenanceHistoryStatus, ResponseMaintenanceHistoryStatus>()
                   .ReverseMap();
            #endregion


            #region MaintenanceTechinican
            CreateMap<CreateMaintenanceTechinican, MaintenanceTask>()
                   .ReverseMap();

            CreateMap<MaintenanceTask, ResponseMaintenanceTask>()
                   .ForMember(c => c.ResponseMainTaskSpareParts, act => act.MapFrom(c => c.MaintenanceTaskSparePartInfos))
                   .ForMember(c => c.ResponseMainTaskServices, act => act.MapFrom(c => c.MaintenanceTaskServiceInfos))
                   .ForMember(c => c.ResponseTechnician, act => act.MapFrom(c => c.Technician))

                   .ReverseMap();
            #endregion

            #region Cost
            CreateMap<CreateMaintenanceServiceCost, MaintenanceServiceCost>()
                   .ReverseMap();

            CreateMap<MaintenanceServiceCost, ResponseMaintenanceServiceCost>()
                   .ForMember(c => c.MaintenanceServiceName, act => act.MapFrom(c => c.MaintenanceService.MaintenanceServiceName))
                   .ForMember(c => c.MaintenanceServiceId, act => act.MapFrom(c => c.MaintenanceServiceId))
                   .ForMember(c => c.Image, act => act.MapFrom(c => c.MaintenanceService.Image))
                   .ForMember(c => c.VehicleModelName, act => act.MapFrom(c => c.MaintenanceService.VehicleModel.VehicleModelName))
                   .ForMember(c => c.VehiclesBrandName, act => act.MapFrom(c => c.MaintenanceService.VehicleModel.VehiclesBrand.VehiclesBrandName))
                   .ForMember(c => c.MaintananceScheduleName, act => act.MapFrom(c => c.MaintenanceService.ServiceCare.MaintananceSchedule.MaintananceScheduleName))
                   .ForMember(c => c.Boolean, act => act.MapFrom(c => c.MaintenanceService.Boolean))
                   .ForMember(c => c.VehicleModelId, act => act.MapFrom(c => c.MaintenanceService.VehicleModelId))
                   .ForMember(c => c.VehiclesBrandId, act => act.MapFrom(c => c.MaintenanceService.VehicleModel.VehiclesBrandId))

                   .ReverseMap();

            CreateMap<CreateSparePartsItemCost, SparePartsItemCost>()
                   .ReverseMap();

            CreateMap<SparePartsItemCost, ResponseSparePartsItemCost>()
                   .ForMember(c => c.SparePartsItemName, act => act.MapFrom(c => c.SparePartsItem.SparePartsItemName))
                   .ForMember(c => c.SparePartsItemId, act => act.MapFrom(c => c.SparePartsItemId))
                   .ForMember(c => c.Image, act => act.MapFrom(c => c.SparePartsItem.Image))
                   .ForPath(c => c.VehicleModelName, act => act.MapFrom(c => c.SparePartsItem.SpareParts.VehicleModel.VehicleModelName))
                   .ForPath(c => c.VehiclesBrandName, act => act.MapFrom(c => c.SparePartsItem.SpareParts.VehicleModel.VehiclesBrand.VehiclesBrandName))
                   .ForPath(c => c.VehicleModelId, act => act.MapFrom(c => c.SparePartsItem.SpareParts.VehicleModel.VehicleModelId))
                   .ForPath(c => c.VehiclesBrandId, act => act.MapFrom(c => c.SparePartsItem.SpareParts.VehicleModel.VehiclesBrandId))
                   //.ForPath(c => c.MaintananceScheduleName, act => act.MapFrom(c => c.SparePartsItem.SpareParts.MaintananceSchedule.MaintananceScheduleName))

                   .ReverseMap();
            #endregion


            #region OdoHistory
            CreateMap<CreateOdoHistory, OdoHistory>()
                   .ReverseMap();
            CreateMap<UpdateOdo, OdoHistory>()
                  .ReverseMap();
            CreateMap<OdoHistory, ResponseOdoHistory>()
                   .ReverseMap();
            #endregion


            #region UpdateAccount
            CreateMap<UpdateClient, Client>()
                   .ReverseMap();
            CreateMap<UpdateCustomerCare, CustomerCare>()
                  .ReverseMap();
            CreateMap<UpdateTechi, Technician>()
                   .ReverseMap();
            CreateMap<UpdateCenter, MaintenanceCenter>()
                   .ReverseMap();
            #endregion


            #region Receipt
            CreateMap<CreateReceipt, Receipt>()
                   .ReverseMap();
            CreateMap<Receipt, ResponseReceipts>()
                  .ForMember(p => p.ResponseMaintenanceInformation, act => act.MapFrom(src => src.InformationMaintenance))
                                    .ForMember(p => p.MaintenanceCenterId, act => act.MapFrom(src => src.InformationMaintenance.Booking.MaintenanceCenterId))

                  .ReverseMap();


            //CreateMap<UpdateTechi, Technician>()
            //       .ReverseMap();
            //CreateMap<UpdateCenter, MaintenanceCenter>()
            //       .ReverseMap();
            #endregion
            #region MainTaskItems
            CreateMap<CreateMaintenanceTaskServiceInfo, MaintenanceTaskServiceInfo>()
                .ReverseMap();
            CreateMap<CreateMaintenanceTaskSparePartInfo, MaintenanceTaskSparePartInfo>()
                .ReverseMap();


            CreateMap<MaintenanceTaskServiceInfo, ResponseMainTaskService>()
                 .ForMember(c => c.Image, act => act.MapFrom(c => c.MaintenanceServiceInfo.MaintenanceServiceCost.MaintenanceService.Image))
                 .ForMember(c => c.Name, act => act.MapFrom(c => c.MaintenanceServiceInfo.MaintenanceServiceInfoName))
                 .ReverseMap();
            CreateMap<MaintenanceTaskSparePartInfo, ResponseMainTaskSparePart>()
                 .ForMember(c => c.Image, act => act.MapFrom(c => c.MaintenanceSparePartInfo.SparePartsItemCost.SparePartsItem.Image))
                 .ForMember(c => c.Name, act => act.MapFrom(c => c.MaintenanceSparePartInfo.MaintenanceSparePartInfoName))
                 .ReverseMap();
            #endregion

            #region FeedBack
            CreateMap<CreateFeedBack, FeedBack>()
                .ReverseMap();

            CreateMap<FeedBack, ResponseFeedback>()
                .ForMember(c => c.ResponseReceipts, act => act.MapFrom(c => c.Receipt))
                .ForMember(c => c.ResponseCenter, act => act.MapFrom(c => c.MaintenanceCenter))
                .ForMember(c => c.ResponseClient, act => act.MapFrom(c => c.Receipt.InformationMaintenance.Booking.Client))
                .ReverseMap();
            #endregion
            CreateMap<UpdateVehicle, Vehicles>()

                .ReverseMap();

            CreateMap<VehiclesMaintenance, ResponseVehiclesMaintenance>()
                 .ForMember(c => c.ResponseCenter, act => act.MapFrom(c => c.MaintenanceCenter))
                .ForMember(c => c.ResponseBrand, act => act.MapFrom(c => c.VehiclesBrand))
                .ReverseMap();
            CreateMap<VehiclesBrand, ResponseBrand>()
    //.ForMember(c => c.ResponseCenter, act => act.MapFrom(c => c.MaintenanceCenter))
    //.ForMember(c => c.VehiclesBrand, act => act.MapFrom(c => c.VehiclesBrand))
    .ReverseMap();
            #region Brand
            CreateMap<CreateBrand, VehiclesBrand>()
                .ReverseMap();
            #endregion


            CreateMap<Notification, ResponseNotification>()
               .ReverseMap();



            #region Plan


            CreateMap<CreateMaintanancePlan, MaintenancePlan>()
           .ReverseMap();

            CreateMap<MaintenancePlan, ResponseMaintenancePlan>()
           .ForMember(c => c.ReponseVehicleModels, act => act.MapFrom(c => c.VehicleModel))

           .ReverseMap();


            #endregion


            #region MVD


            CreateMap<CreateMainVehicleDetail, MaintenanceVehiclesDetail>()
           .ReverseMap();

            CreateMap<MaintenanceVehiclesDetail, ResponseMaintenanceVehicleDetail>()
           .ForMember(c => c.ResponseMaintenanceSchedules, act => act.MapFrom(c => c.MaintananceSchedule))
           .ForMember(c => c.ResponseVehicles, act => act.MapFrom(c => c.Vehicle))
                      .ForMember(c => c.ResponseCenter, act => act.MapFrom(c => c.MaintenanceCenter))

           .ReverseMap();


            #endregion



            CreateMap<Transactions, ResponseTransaction>()

                .ForMember(p => p.ResponseMaintenancePlan, act => act.MapFrom(src => src.MaintenancePlan))
                .ForMember(p => p.ResponseCenter, act => act.MapFrom(src => src.MaintenanceCenter))
                .ForMember(p => p.ResponseVehicles, act => act.MapFrom(src => src.Vehicles))
                .ForMember(p => p.ResponseClient, act => act.MapFrom(src => src.Vehicles.Client))
                .ReverseMap();
        }
    }
}
