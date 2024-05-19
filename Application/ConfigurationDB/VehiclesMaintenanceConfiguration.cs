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
    public class VehiclesMaintenanceConfiguration : IEntityTypeConfiguration<VehiclesMaintenance>
    {
        public void Configure(EntityTypeBuilder<VehiclesMaintenance> builder)
        {
            builder.HasKey(c => new
            {
                c.MaintenanceCenterId,
                c.VehiclesBrandId
            });

            builder.HasOne(d => d.MaintenanceCenter)
                    .WithMany(d => d.VehiclesMaintenance)
                    .HasForeignKey(d => d.MaintenanceCenterId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.VehiclesBrand)
                    .WithMany(d => d.VehiclesMaintenance)
                    .HasForeignKey(d => d.VehiclesBrandId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
