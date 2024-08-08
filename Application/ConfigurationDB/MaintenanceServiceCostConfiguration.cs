using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ConfigurationDB
{
    public class MaintenanceServiceCostConfiguration : IEntityTypeConfiguration<MaintenanceServiceCost>
    {
        public void Configure(EntityTypeBuilder<MaintenanceServiceCost> builder)
        {
            builder.HasKey(c => c.MaintenanceServiceCostId);
            builder.Property(e => e.MaintenanceServiceCostId)
                    .ValueGeneratedOnAdd();

            builder.HasOne(d => d.MaintenanceService)
                     .WithMany(d => d.MaintenanceServiceCosts)
                     .HasForeignKey(d => d.MaintenanceServiceId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}