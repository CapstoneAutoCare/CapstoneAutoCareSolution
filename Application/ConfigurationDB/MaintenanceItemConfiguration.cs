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
    public class MaintenanceItemConfiguration : IEntityTypeConfiguration<MaintenanceItem>
    {
        public void Configure(EntityTypeBuilder<MaintenanceItem> builder)
        {
            builder.HasKey(c => c.MaintenanceItemId);
            builder.Property(e => e.MaintenanceItemId)
                    .ValueGeneratedOnAdd();
            builder.HasOne(d => d.SparePartsCost)
                    .WithMany(d => d.MaintenanceItems)
                    .HasForeignKey(d => d.SparePartsCostId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.ServiceCareCost)
                    .WithMany(d => d.MaintenanceItems)
                    .HasForeignKey(d => d.ServiceCareCostId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.InformationMaintenance)
                    .WithMany(d => d.MaintenanceItems)
                    .HasForeignKey(d => d.InformationMaintenanceId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
