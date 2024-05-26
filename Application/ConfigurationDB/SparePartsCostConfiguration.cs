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
    public class SparePartsCostConfiguration : IEntityTypeConfiguration<SparePartsItem>
    {
        public void Configure(EntityTypeBuilder<SparePartsItem> builder)
        {
            builder.HasKey(c => c.SparePartsItemtId);

            builder.Property(e => e.SparePartsItemtId)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime");


            builder.HasOne(d => d.SpareParts)
                    .WithMany(d => d.SparePartsItems)
                    .HasForeignKey(d => d.SparePartsId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.MaintenanceCenter)
                    .WithMany(d => d.SparePartsItems)
                    .HasForeignKey(d => d.MaintenanceCenterId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
