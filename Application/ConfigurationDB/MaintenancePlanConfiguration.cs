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
    public class MaintenancePlanConfiguration : IEntityTypeConfiguration<MaintenancePlan>
    {
        public void Configure(EntityTypeBuilder<MaintenancePlan> builder)
        {
            builder.HasKey(c => c.MaintenancePlanId);
            builder.Property(e => e.MaintenancePlanId)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.DateTime)
               .HasColumnType("datetime");

            builder.HasOne(d => d.VehicleModel)
                    .WithMany(d => d.MaintenancePlans)
                    .HasForeignKey(d => d.VehicleModelId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
