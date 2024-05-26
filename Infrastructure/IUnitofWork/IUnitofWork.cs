using Application.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IUnitofWork
{
    public interface IUnitOfWork
    {
        IAccountRepository Account { get; }
        IAdminRepository Admin { get; }
        IBookingRepository Booking { get; }
        IClientRepository Client { get; }
        ICustomerCareRepository CustomerCare { get; }
        IFeedBackRepository FeedBack { get; }
        IInformationMaintenanceRepository InformationMaintenance { get; }
        IMaintananceScheduleRepository MaintenanceSchedule { get; }
        IMaintenanceCenterRepository MaintenanceCenter { get; }
        IMaintenanceHistoryStatusesRepository MaintenanceHistoryStatuses { get; }
        IMaintenanceSparePartInfoRepository MaintenanceSparePartInfo { get; }
        IMaintenancePlanRepository MaintenancePlan { get; }
        IMaintenanceServiceRepository MaintenanceService { get; }
        IOdoHistoryRepository OdoHistory { get; }
        IReceiptRepository ReceiptRepository { get; }
        IServiceCareRepository ServiceCare { get; }
        ISparePartsItemRepository SparePartsItem { get; }
        ISparePartsRepository SparePartsRepository { get; }
        IStaffCareRepository StaffCare { get; }
        ITechnicianRepository Technician { get; }
        IVehicleModelRepository VehicleModel { get; }
        IVehiclesBrandRepository VehiclesBrand { get; }
        IVehiclesMaintenanceRepository VehiclesMaintenance { get; }
        IVehiclesRepository Vehicles { get; }
        IMaintenanceServiceInfoRepository MaintenanceServiceInfo { get; }
        Task Commit();

    }
}
