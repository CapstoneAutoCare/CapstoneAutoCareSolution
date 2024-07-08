using Application;
using Application.IRepository;
using Application.IRepository.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IUnitofWork.Imp
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _context;

        private readonly IAccountRepository _Account;
        private readonly IAdminRepository _Admin;
        private readonly IBookingRepository _Booking;
        private readonly IClientRepository _Client;
        private readonly ICustomerCareRepository _CustomerCare;
        private readonly IFeedBackRepository _FeedBack;
        private readonly IInformationMaintenanceRepository _InformationMaintenance;
        private readonly IMaintananceScheduleRepository _MaintenanceSchedule;
        private readonly IMaintenanceCenterRepository _MaintenanceCenter;
        private readonly IMaintenanceHistoryStatusesRepository _MaintenanceHistoryStatuses;
        private readonly IMaintenanceSparePartInfoRepository _MaintenanceSparePartInfo;
        private readonly IMaintenanceServiceRepository _MaintenanceService;
        private readonly IOdoHistoryRepository _OdoHistory;
        private readonly IReceiptRepository _ReceiptRepository;
        private readonly IServiceCareRepository _ServiceCare;
        private readonly ISparePartsItemRepository _SparePartsItem;
        private readonly ISparePartsRepository _SparePartsRepository;
        private readonly ITechicianRepository _Techician;
        private readonly IMaintenanceTaskRepository _MaintenanceTask;
        private readonly IVehicleModelRepository _VehicleModel;
        private readonly IVehiclesBrandRepository _VehiclesBrand;
        private readonly IVehiclesMaintenanceRepository _VehiclesMaintenance;
        private readonly IVehiclesRepository _Vehicles;
        private readonly IMaintenanceServiceInfoRepository _MaintenanceServiceInfo;
        private readonly IMaintenanceServiceCostRepository _MaintenanceServiceCost;
        private ISparePartsItemCostRepository _SparePartsItemCost;
        public UnitOfWork(AppDBContext context)
        {
            _context = context;
            _Account = new AccountRepositoryImp(_context);
            _Admin = new AdminRepositoryImp(_context);
            _Booking = new BookingRepositoryImp(_context);
            _Client = new ClientRepositoryImp(_context);
            _CustomerCare = new CustomerCareRepositoryImp(_context);
            //_FeedBack = new FeedBackRepositoryImp(_context);
            _InformationMaintenance = new InformationMaintenanceRepositoryImp(_context);
            _MaintenanceSchedule = new MaintananceScheduleRepositoryImp(_context);
            _MaintenanceCenter = new MaintenanceCenterRepositoryImp(_context);
            _MaintenanceHistoryStatuses = new MaintenanceHistoryStatusesRepositoryImp(_context);
            _MaintenanceSparePartInfo = new MaintenanceSparePartInfoRepositoryImp(_context);
            _MaintenanceService = new ServiceCareCostRepositoryImp(_context);
            _OdoHistory = new OdoHistoryRepositoryImp(_context);
            _ReceiptRepository = new ReceiptRepositoryImp(_context);
            _ServiceCare = new ServiceCareRepositoryImp(_context);
            _SparePartsItem = new SparePartsItemRepositoryImp(_context);
            _SparePartsRepository = new SparePartsRepositoryImp(_context);
            _Techician = new TechnicianRepositoryImp(_context);
            _MaintenanceTask = new MaintenanceTaskRepositoryImp(_context);
            _VehicleModel = new VehicleModelRepositoryImp(_context);
            _VehiclesBrand = new VehiclesBrandRepositoryImp(_context);
            //_VehiclesMaintenance = new VehiclesMaintenanceRepositoryImp(_context);
            _Vehicles = new VehiclesRepositoryImp(_context);
            _MaintenanceServiceInfo = new MaintenanceServiceInfoRepositoryImp(_context);
            _SparePartsItemCost = new SparePartsItemCostRepositoryImp(_context);
            _MaintenanceServiceCost = new MaintenanceServiceCostRepositoryImp(_context);
        }

        public IAccountRepository Account => _Account;

        public IAdminRepository Admin => _Admin;

        public IBookingRepository Booking => _Booking;

        public IClientRepository Client => _Client;

        public ICustomerCareRepository CustomerCare => _CustomerCare;

        public IFeedBackRepository FeedBack => _FeedBack;

        public IInformationMaintenanceRepository InformationMaintenance => _InformationMaintenance;

        public IMaintananceScheduleRepository MaintenanceSchedule => _MaintenanceSchedule;

        public IMaintenanceCenterRepository MaintenanceCenter => _MaintenanceCenter;

        public IMaintenanceHistoryStatusesRepository MaintenanceHistoryStatuses => _MaintenanceHistoryStatuses;

        public IMaintenanceSparePartInfoRepository MaintenanceSparePartInfo => _MaintenanceSparePartInfo;


        public IMaintenanceServiceRepository MaintenanceService => _MaintenanceService;

        public IOdoHistoryRepository OdoHistory => _OdoHistory;

        public IReceiptRepository ReceiptRepository => _ReceiptRepository;

        public IServiceCareRepository ServiceCare => _ServiceCare;

        public ISparePartsItemRepository SparePartsItem => _SparePartsItem;

        public ISparePartsRepository SparePartsRepository => _SparePartsRepository;

        public ITechicianRepository Techician => _Techician;

        public IMaintenanceTaskRepository MaintenanceTask => _MaintenanceTask;

        public IVehicleModelRepository VehicleModel => _VehicleModel;

        public IVehiclesBrandRepository VehiclesBrand => _VehiclesBrand;

        public IVehiclesMaintenanceRepository VehiclesMaintenance => _VehiclesMaintenance;

        public IVehiclesRepository Vehicles => _Vehicles;


        public IMaintenanceServiceInfoRepository MaintenanceServiceInfo => _MaintenanceServiceInfo;

        public IMaintenanceServiceCostRepository MaintenanceServiceCost => _MaintenanceServiceCost;
        public ISparePartsItemCostRepository SparePartsItemCost => _SparePartsItemCost;

        public async Task Commit() => await _context.SaveChangesAsync();

    }
}
