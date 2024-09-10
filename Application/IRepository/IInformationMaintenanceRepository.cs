using Application.Dashboard;
using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IInformationMaintenanceRepository : IGenericRepository<MaintenanceInformation>
    {
        Task<MaintenanceInformation> GetById(Guid id);
        Task<List<MaintenanceInformation>> GetAll();
        Task<List<MaintenanceInformation>> GetListByClient(Guid id);
        Task<List<MaintenanceInformation>> GetListByCenter(Guid id);
        Task<(List<MaintenanceInformation> Costs, float TotalCost, int Count)> TotalGetListByCenter(Guid id);
        Task<List<MaintenanceInformation>> GetListByCenterAndStatus(Guid id, string status);
        Task<List<MaintenanceInformation>> GetListByCenterAndStatusCheckinAndTaskInactive(Guid id);
        Task<List<MonthlyRevenue>> GetMonthlyRevenue(int year,Guid id);
        Task<List<MonthlyBookingSummary>> GetInforPAIDByMonthInYearByCenterId(Guid centerId, int year);


        Task<MaintenanceInformation> GetByBookingId(Guid id);
        Task<List<MaintenanceInformation>> GetListByBookingId(Guid id);
    }
}
