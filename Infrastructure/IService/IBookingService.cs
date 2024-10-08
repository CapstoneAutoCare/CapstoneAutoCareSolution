﻿using Application.Dashboard;
using Domain.Enum;
using Infrastructure.Common.Request.RequestBooking;
using Infrastructure.Common.Response.ResponseBooking;
using Infrastructure.Common.Response.ResponseCustomerCare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IBookingService
    {
        Task<List<ResponseBooking>> GetAll();
        //Task<ResponseBooking> Create(RequestBooking create);
        Task<ResponseBooking> CreateHaveItemsByClient(RequestBookingHaveItems create);
        //Task<ResponseBooking> CreatePackageByClient(CreateBookingPackage create);
        Task<ResponseBooking> CreateMaintenanceByClient(CreateMaintenanceBooking create);

        Task<ResponseBooking> GetById(Guid id);
        Task<List<ResponseBooking>> GetListByClient();
        Task<List<ResponseBooking>> GetListByCenterAndClient(Guid centerid, Guid clientId);
        Task<ResponseBooking> UpdateStatus(Guid? customercareId, Guid bookingId, string status);

        Task<List<ResponseBooking>> GetListByCenter();
        Task<List<ResponseBooking>> GetListByCenterId(Guid id);
        Task<List<MonthlyBookingSummary>> GetBookingsByMonthByCenterId(Guid id);
        Task<List<MonthlyBookingSummary>> GetBookingsByMonthInYearByCenterId(Guid id, int year);
        Task<List<ResponseBooking>> GetListBookingCancelledInformationAndAcceptBooking(Guid centerId);

    }
}
