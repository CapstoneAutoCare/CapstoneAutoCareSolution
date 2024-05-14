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
    public class SparePartsCostConfiguration : IEntityTypeConfiguration<SparePartsCost>
    {
        public void Configure(EntityTypeBuilder<SparePartsCost> builder)
        {
            builder.HasKey(c => c.SparePartsCostId);

            builder.Property(e => e.SparePartsCostId)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime");


            builder.HasOne(d => d.SpareParts)
                    .WithOne(d => d.SparePartsCost)
                    .HasForeignKey<SpareParts>(d => d.SparePartId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.MaintenanceCenter)
                    .WithMany(d => d.SparePartsCosts)
                    .HasForeignKey(d => d.MaintenanceCenterId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
