using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ConfigurationDB
{
    public class MaintenanceVehiclesDetailConfiguration : IEntityTypeConfiguration<MaintenanceVehiclesDetail>
    {
        public void Configure(EntityTypeBuilder<MaintenanceVehiclesDetail> builder)
        {
            builder.HasKey(c => new
            {
                c.MaintananceScheduleId,
                c.VehiclesId,
                c.MaintenanceCenterId
            });

            builder.HasOne(d => d.Vehicle)
                    .WithMany(d => d.MaintenanceVehiclesDetails)
                    .HasForeignKey(d => d.VehiclesId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.MaintananceSchedule)
                    .WithMany(d => d.MaintenanceVehiclesDetails)
                    .HasForeignKey(d => d.MaintananceScheduleId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.MaintenanceCenter)
                    .WithMany(d => d.MaintenanceVehiclesDetails)
                    .HasForeignKey(d => d.MaintenanceCenterId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
