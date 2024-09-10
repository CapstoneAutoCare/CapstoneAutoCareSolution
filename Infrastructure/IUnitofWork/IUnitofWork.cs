using Application.IRepository;
using Microsoft.Extensions.Configuration;
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
        IBookingRepository Booking { get; }
        IClientRepository Client { get; }
        ICustomerCareRepository CustomerCare { get; }
        IFeedBackRepository FeedBack { get; }
        IInformationMaintenanceRepository InformationMaintenance { get; }
        IMaintananceScheduleRepository MaintenanceSchedule { get; }
        IMaintenanceCenterRepository MaintenanceCenter { get; }
        IMaintenanceHistoryStatusesRepository MaintenanceHistoryStatuses { get; }
        IMaintenanceSparePartInfoRepository MaintenanceSparePartInfo { get; }
        IMaintenanceServiceRepository MaintenanceService { get; }
        IMaintenanceServiceCostRepository MaintenanceServiceCost { get; }
        ISparePartsItemCostRepository SparePartsItemCost { get; }
        IOdoHistoryRepository OdoHistory { get; }
        IReceiptRepository ReceiptRepository { get; }
        IServiceCareRepository ServiceCare { get; }
        ISparePartsItemRepository SparePartsItem { get; }
        ISparePartsRepository SparePartsRepository { get; }
        ITechicianRepository Techician { get; }
        IMaintenanceTaskRepository MaintenanceTask { get; }
        IVehicleModelRepository VehicleModel { get; }
        IVehiclesBrandRepository VehiclesBrand { get; }
        IVehiclesMaintenanceRepository VehiclesMaintenance { get; }
        IVehiclesRepository Vehicles { get; }
        IMaintenanceServiceInfoRepository MaintenanceServiceInfo { get; }
        IMaintenanceTaskServiceInfoRepository MaintenanceTaskServiceInfo { get; }
        IMaintenanceTaskSparePartInfoRepository MaintenanceTaskSparePartInfo { get; }
        INotificationRepository NotificationRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        IPackageRepository PackageRepository { get; }
        IPackageCenterRepository PackageCenterRepository { get; }
        IMaintenanceVehiclesDetailRepository MaintenanceVehiclesDetailRepository { get; }
        IMaintenancePlanRepository MaintenancePlanRepository { get; }
        Task Commit();

    }
}
