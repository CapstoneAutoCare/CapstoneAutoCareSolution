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
            builder.HasKey(c => c.MaintenanceServiceId);
            builder.Property(e => e.MaintenanceServiceId)
                    .ValueGeneratedOnAdd();

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
