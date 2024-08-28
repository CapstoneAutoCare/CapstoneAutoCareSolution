using Application.Dashboard;
using Domain.Enum;
using Infrastructure.Common.Request.RequestMaintenanceInformation;
using Infrastructure.Common.Response.ResponseBooking;
using Infrastructure.Common.Response.ResponseMainInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IMaintenanceInformationService
    {
        Task<ResponseMaintenanceInformation> GetById(Guid id);
        Task<List<ResponseMaintenanceInformation>> GetListByClient();
        Task<List<ResponseMaintenanceInformation>> GetListByCenter();
        Task<List<ResponseMaintenanceInformation>> GetListByCenterId(Guid id);
        Task<List<ResponseMaintenanceInformation>> GetListByCenterAnd(string status);
        Task<ResponseMaintenanceInformation> GetByBookingId(Guid id);
        Task<ResponseMaintenanceInformation> Create(CreateMaintenanceInformation create);
        Task<ResponseMaintenanceInformation> CreateHaveItems(CreateMaintenanceInformationHaveItems create);
        Task<List<ResponseMaintenanceInformation>> GetAll();
        Task<List<ResponseMaintenanceInformation>> GetListByCenterAndStatusCheckinAndTaskInactive(Guid id);
        Task<ResponseMaintenanceInformation> ChangeStatus (Guid id, string status);
        Task<ResponseMaintenanceInformation> ChangeStatusBackUp (Guid id, string status);
        Task<List<MonthlyRevenue>> GetMonthlyRevenue(int year, Guid id);
        Task<List<MonthlyBookingSummary>> GetMonthlyRevenuePAID(int year, Guid id);

        Task Remove (Guid id);
    }
}
