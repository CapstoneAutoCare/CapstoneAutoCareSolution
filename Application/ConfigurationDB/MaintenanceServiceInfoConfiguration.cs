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
    public class MaintenanceServiceInfoConfiguration : IEntityTypeConfiguration<MaintenanceServiceInfo>
    {
        public void Configure(EntityTypeBuilder<MaintenanceServiceInfo> builder)
        {
            builder.HasKey(c => c. MaintenanceServiceInfoId);
            builder.Property(e => e.MaintenanceServiceInfoId)
                    .ValueGeneratedOnAdd();

            builder.HasIndex(e => new { e.InformationMaintenanceId, e.MaintenanceServiceId })
                .IsUnique();

            builder.HasOne(d => d.MaintenanceService)
                    .WithMany(d => d.MaintenanceServiceInfos)
                    .HasForeignKey(d => d.MaintenanceServiceId)
                    .OnDelete(DeleteBehavior.Restrict);
            

            builder.HasOne(d => d.InformationMaintenance)
                    .WithMany(d => d.MaintenanceServiceInfos)
                    .HasForeignKey(d => d.InformationMaintenanceId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
