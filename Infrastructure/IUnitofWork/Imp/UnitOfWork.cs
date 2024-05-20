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
        private readonly IMaintenanceItemRepository _MaintenanceItem;
        private readonly IMaintenancePlanRepository _MaintenancePlan;
        private readonly IMaintenanceServiceRepository _MaintenanceService;
        private readonly IOdoHistoryRepository _OdoHistory;
        private readonly IReceiptRepository _ReceiptRepository;
        private readonly IServiceCareRepository _ServiceCare;
        private readonly ISparePartsItemRepository _SparePartsItem;
        private readonly ISparePartsRepository _SparePartsRepository;
        private readonly IStaffCareRepository _StaffCare;
        private readonly ITechnicianRepository _Technician;
        private readonly IVehicleModelRepository _VehicleModel;
        private readonly IVehiclesBrandRepository _VehiclesBrand;
        private readonly IVehiclesMaintenanceRepository _VehiclesMaintenance;
        private readonly IVehiclesRepository _Vehicles;

        public UnitOfWork(AppDBContext context)
        {
            _context = context;
            _Account = new AccountRepositoryImp(_context);
            _Admin = new AdminRepositoryImp(_context);
            //_Booking = new BookingRepositoryImp(_context);
            _Client = new ClientRepositoryImp(_context);
            //_CustomerCare = new CustomerCareRepositoryImp(_context);
            //_FeedBack = new FeedBackRepositoryImp(_context);
            //_InformationMaintenance = new InformationMaintenanceRepositoryImp(_context);
            //_MaintenanceSchedule = new MaintananceScheduleRepositoryImp(_context);
            //_MaintenanceCenter = new MaintenanceCenterRepositoryImp(_context);
            //_MaintenanceHistoryStatuses = new MaintenanceHistoryStatusesRepositoryImp(_context);
            //_MaintenanceItem = new MaintenanceItemRepositoryImp(_context);
            //_MaintenancePlan = new MaintenancePlanRepositoryImp(_context);
            //_MaintenanceService = new ServiceCareCostRepositoryImp(_context);
            //_OdoHistory = new OdoHistoryRepositoryImp(_context);
            //_ReceiptRepository = new ReceiptRepositoryImp(_context);
            //_ServiceCare = new ServiceCareRepositoryImp(_context);
            //_SparePartsItem = new SparePartsCostRepositoryImp(_context);
            //_SparePartsRepository = new SparePartsRepositoryImp(_context);
            //_StaffCare = new StaffCareRepositoryImp(_context);
            //_Technician = new TechnicianCostRepositoryImp(_context);
            //_VehicleModel = new VehicleModelRepositoryImp(_context);
            //_VehiclesBrand = new VehiclesBrandRepositoryImp(_context);
            //_VehiclesMaintenance = new VehiclesMaintenanceRepositoryImp(_context);
            //_Vehicles = new VehiclesRepositoryImp(_context);
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

        public IMaintenanceItemRepository MaintenanceItem => _MaintenanceItem;

        public IMaintenancePlanRepository MaintenancePlan => _MaintenancePlan;

        public IMaintenanceServiceRepository MaintenanceService => _MaintenanceService;

        public IOdoHistoryRepository OdoHistory => _OdoHistory;

        public IReceiptRepository ReceiptRepository => _ReceiptRepository;

        public IServiceCareRepository ServiceCare => _ServiceCare;

        public ISparePartsItemRepository SparePartsItem => _SparePartsItem;

        public ISparePartsRepository SparePartsRepository => _SparePartsRepository;

        public IStaffCareRepository StaffCare => _StaffCare;

        public ITechnicianRepository Technician => _Technician;

        public IVehicleModelRepository VehicleModel => _VehicleModel;

        public IVehiclesBrandRepository VehiclesBrand => _VehiclesBrand;

        public IVehiclesMaintenanceRepository VehiclesMaintenance => _VehiclesMaintenance;

        public IVehiclesRepository Vehicles => _Vehicles;

        public async Task Commit() => await _context.SaveChangesAsync();

    }
}
