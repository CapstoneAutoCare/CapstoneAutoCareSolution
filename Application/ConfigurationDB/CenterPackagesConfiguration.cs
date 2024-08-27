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
    public class CenterPackagesConfiguration : IEntityTypeConfiguration<CenterPackages>
    {
        public void Configure(EntityTypeBuilder<CenterPackages> builder)
        {
            builder.HasKey(c => c.CenterPackagesId);
            builder.Property(e => e.CenterPackagesId)
                    .ValueGeneratedOnAdd();
            builder.HasOne(d => d.Package)
        .WithMany(d => d.CenterPackages)
        .HasForeignKey(d => d.PackageId)
        .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.MaintenanceCenter)
        .WithMany(d => d.CenterPackages)
        .HasForeignKey(d => d.MaintenanceCenterId)
        .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
