using Application.ConfigurationDB;
using Application.SeedingData;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public partial class AppDBContext : DbContext
    {
        public AppDBContext() { }
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<CustomerCare> CustomerCares { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<MaintenanceInformation> MaintenanceInformations { get; set; }
        public virtual DbSet<MaintananceSchedule> MaintananceSchedules { get; set; }
        public virtual DbSet<MaintenanceCenter> MaintenanceCenters { get; set; }
        public virtual DbSet<MaintenanceHistoryStatus> MaintenanceHistoryStatuses { get; set; }
        public virtual DbSet<MaintenanceSparePartInfo> MaintenanceSparePartInfos { get; set; }
        public virtual DbSet<MaintenanceServiceInfo> MaintenanceServiceInfos { get; set; }
        public virtual DbSet<MaintenanceService> MaintenanceServices { get; set; }
        public virtual DbSet<OdoHistory> OdoHistories { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<ServiceCares> ServiceCares { get; set; }
        public virtual DbSet<SpareParts> SpareParts { get; set; }
        public virtual DbSet<SparePartsItem> SparePartsItem { get; set; }
        public virtual DbSet<Technician> Technicians { get; set; }
        public virtual DbSet<MaintenanceTask> MaintenanceTasks { get; set; }
        public virtual DbSet<VehicleModel> VehicleModel { get; set; }
        public virtual DbSet<Vehicles> Vehicles { get; set; }
        public virtual DbSet<VehiclesBrand> VehiclesBrand { get; set; }
        public virtual DbSet<VehiclesMaintenance> VehiclesMaintenances { get; set; }
        public virtual DbSet<ImageRepairReceipt> ImageRepairReceipts { get; set; }
        public virtual DbSet<SparePartsItemCost> SparePartsItemCosts { get; set; }
        public virtual DbSet<MaintenanceServiceCost> MaintenanceServiceCosts { get; set; }
        public virtual DbSet<MaintenanceTaskServiceInfo> MaintenanceTaskServiceInfos { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<MaintenanceVehiclesDetail> MaintenanceVehiclesDetails { get; set; }
        public virtual DbSet<MaintenancePlan> MaintenancePlans { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=db7867.public.databaseasp.net; Database=db7867; User Id=db7867; Password=3g-XnQ9+6b!T; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
                //optionsBuilder.UseSqlServer("Server=LAPTOP-O5LECEEK; Database=AutoCare; User Id=sa;Password=12345;TrustServerCertificate=True;MultipleActiveResultSets=true");
                optionsBuilder.UseSqlServer("Server=mssql-183453-0.cloudclusters.net,10069; Database =AutoCare; User Id=duy;Password=0363423742Duy;TrustServerCertificate=True;MultipleActiveResultSets=true");
                //optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region AddConfiguration
            modelBuilder.ApplyConfiguration(new AccountConfiguration());

            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new FeedBackConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceInformationConfiguration());
            modelBuilder.ApplyConfiguration(new MaintananceScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceCenterConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceSparePartInfoConfiguration());
            modelBuilder.ApplyConfiguration(new OdoHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiptConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceCaresConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceServiceConfiguration());
            modelBuilder.ApplyConfiguration(new SparePartsConfiguration());
            modelBuilder.ApplyConfiguration(new SparePartsItemConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceTaskConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerCareConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleModelConfiguration());
            modelBuilder.ApplyConfiguration(new VehiclesBrandConfiguration());
            modelBuilder.ApplyConfiguration(new VehiclesConfiguration());
            modelBuilder.ApplyConfiguration(new TechnicianConfiguration());
            modelBuilder.ApplyConfiguration(new VehiclesMaintenanceConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceHistoryStatusConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceServiceInfoConfiguration());
            modelBuilder.ApplyConfiguration(new ImageRepairReceiptConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceServiceCostConfiguration());
            modelBuilder.ApplyConfiguration(new SparePartsItemConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceTaskServiceInfosConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceTaskSparePartInfosConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionsConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenancePlanConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceVehiclesDetailConfiguration());
            #endregion

            var vehicleBrands = SeedingDataVehiclesBrand.Get();
            modelBuilder.Entity<VehiclesBrand>().HasData(vehicleBrands);
            var vehiclemodel = SeedingDataVehicleModel.ServiceSeedingDataVehicleModel(vehicleBrands);
            modelBuilder.Entity<VehicleModel>().HasData(vehiclemodel);
            var plan = SeedingDataMaintanancePlan.Get(vehiclemodel);
            modelBuilder.Entity<MaintenancePlan>().HasData(plan);



            var schedule = SeedingDataMaintananceSchedule.Get(plan);
            modelBuilder.Entity<MaintananceSchedule>().HasData(schedule);

            var spareParts = SeedingDataSparePart.GetSpareParts(vehiclemodel);
            modelBuilder.Entity<SpareParts>().HasData(spareParts);


            var serviceCares = SeedingDataServicesItem.GetServicesItem(schedule);
            modelBuilder.Entity<ServiceCares>().HasData(serviceCares);
            //------------------------------------------------------------------
            //var center = SeedingDataCenter.ServiceSeedingDataCenter(modelBuilder);

            //var sparepartitems = SeedingDataSparePartsItem.GetSparePartsItems(center, spareParts);
            //modelBuilder.Entity<SparePartsItem>().HasData(sparepartitems);

            //var maintenanceServices = SeedingDataMaintenanceService.GetMaintenanceServices(center, serviceCares, vehiclemodel);
            //modelBuilder.Entity<MaintenanceService>().HasData(maintenanceServices);

            //var sparePartsItemCosts = SeedingDataSparePartsItemCost.GetSparePartsItemsCost(sparepartitems);
            //modelBuilder.Entity<SparePartsItemCost>().HasData(sparePartsItemCosts);

            //var maintenanceServiceCosts = SeedingDataMaintenanceServiceCost.GetMaintenanceServiceCost(maintenanceServices);
            //modelBuilder.Entity<MaintenanceServiceCost>().HasData(maintenanceServiceCosts);


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
