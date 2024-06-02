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
        public virtual DbSet<Admin> Admins { get; set; }
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
        public virtual DbSet<MaintenancePlan> MaintenancePlans { get; set; }
        public virtual DbSet<MaintenanceService> MaintenanceServices { get; set; }
        public virtual DbSet<OdoHistory> OdoHistories { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<ServiceCare> ServiceCares { get; set; }
        public virtual DbSet<SpareParts> SpareParts { get; set; }
        public virtual DbSet<SparePartsItem> SparePartsItem { get; set; }
        public virtual DbSet<StaffCare> StaffCares { get; set; }
        public virtual DbSet<Technician> Technician { get; set; }
        public virtual DbSet<VehicleModel> VehicleModel { get; set; }
        public virtual DbSet<Vehicles> Vehicles { get; set; }
        public virtual DbSet<VehiclesBrand> VehiclesBrand { get; set; }
        public virtual DbSet<VehiclesMaintenance> VehiclesMaintenances { get; set; }
        public virtual DbSet<ImageRepairReceipt> ImageRepairReceipts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(local);Database=AutoCare;User ID=sa;Password=12345;TrustServerCertificate=True;MultipleActiveResultSets=true");
                //optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new FeedBackConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceInformationConfiguration());
            modelBuilder.ApplyConfiguration(new MaintananceScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceCenterConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceSparePartInfoConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenancePlanConfiguration());
            modelBuilder.ApplyConfiguration(new OdoHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiptConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceCareConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceServiceConfiguration());
            modelBuilder.ApplyConfiguration(new SparePartsConfiguration());
            modelBuilder.ApplyConfiguration(new SparePartsCostConfiguration());
            modelBuilder.ApplyConfiguration(new TechnicianConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerCareConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleModelConfiguration());
            modelBuilder.ApplyConfiguration(new VehiclesBrandConfiguration());
            modelBuilder.ApplyConfiguration(new VehiclesConfiguration());
            modelBuilder.ApplyConfiguration(new StaffCareConfiguration());
            modelBuilder.ApplyConfiguration(new VehiclesMaintenanceConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceHistoryStatusConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceServiceInfoConfiguration());
            modelBuilder.ApplyConfiguration(new ImageRepairReceiptConfiguration());


            var vehicleBrands = SeedingDataVehiclesBrand.Get();
            modelBuilder.Entity<VehiclesBrand>().HasData(vehicleBrands);

            foreach (var brand in vehicleBrands)
            {
                var vehicleModels = new List<VehicleModel>();
                switch (brand.VehiclesBrandName)
                {
                    case "BMW":
                        vehicleModels = SeedingDataVehicleModel.GetBMW(brand);
                        break;
                    case "MEC":
                        vehicleModels = SeedingDataVehicleModel.GetMEC(brand);
                        break;
                    case "AUDI":
                        vehicleModels = SeedingDataVehicleModel.GetAUDI(brand);
                        break;
                    case "TOYOTA":
                        vehicleModels = SeedingDataVehicleModel.GetTOYOTA(brand);
                        break;
                    case "HONDA":
                        vehicleModels = SeedingDataVehicleModel.GetHONDA(brand);
                        break;
                }

                foreach (var vehicleModel in vehicleModels)
                {
                    modelBuilder.Entity<VehicleModel>().HasData(vehicleModel);
                    var schedule = SeedingDataMaintananceSchedule.Get(vehicleModel);
                    //modelBuilder.Entity<MaintananceSchedule>().HasData(SeedingDataMaintananceSchedule.Get(vehicleModel));

                    foreach (var scheduleModel in schedule)
                    {
                        modelBuilder.Entity<MaintananceSchedule>().HasData(scheduleModel);
                        modelBuilder.Entity<MaintenancePlan>().HasData(SeedingDataMaintenancePlan.Get(scheduleModel));

                    }

                }
            }


            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }

}
