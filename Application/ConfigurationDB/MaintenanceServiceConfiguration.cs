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
    public class MaintenanceServiceConfiguration : IEntityTypeConfiguration<MaintenanceService>
    {
        public void Configure(EntityTypeBuilder<MaintenanceService> builder)
        {
            builder.HasKey(c => c.MaintenanceServiceId);
            builder.Property(e => e.MaintenanceServiceId)
                    .ValueGeneratedOnAdd();
            builder.HasIndex(e => new { e.ServiceCareId, e.VehicleModelId, e.MaintenanceCenterId }).IsUnique();

            builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime");

            builder.HasOne(d => d.ServiceCare)
                    .WithMany(d => d.MaintenanceServices)
                    .HasForeignKey(d => d.ServiceCareId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.MaintenanceCenter)
                    .WithMany(d => d.MaintenanceServices)
                    .HasForeignKey(d => d.MaintenanceCenterId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.VehicleModel)
                    .WithMany(d => d.MaintenanceServices)
                    .HasForeignKey(d => d.VehicleModelId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
