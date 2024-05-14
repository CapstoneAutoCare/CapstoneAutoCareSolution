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
    public class ServiceCareCostConfiguration : IEntityTypeConfiguration<ServiceCareCost>
    {
        public void Configure(EntityTypeBuilder<ServiceCareCost> builder)
        {
            builder.HasKey(c => c.ServiceCareCostId);
            builder.Property(e => e.ServiceCareId)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime");

            builder.HasOne(d => d.ServiceCare)
                    .WithOne(d => d.ServiceCareCost)
                    .HasForeignKey<ServiceCare>(d => d.ServiceCareId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.MaintenanceCenter)
                    .WithMany(d => d.ServiceCareCosts)
                    .HasForeignKey(d => d.MaintenanceCenterId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
