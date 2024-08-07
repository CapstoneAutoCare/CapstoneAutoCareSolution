﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ConfigurationDB
{
    public class SparePartsItemConfiguration : IEntityTypeConfiguration<SparePartsItem>
    {
        public void Configure(EntityTypeBuilder<SparePartsItem> builder)
        {
            builder.HasKey(c => c.SparePartsItemId);

            builder.Property(e => e.SparePartsItemId)
                    .ValueGeneratedOnAdd();
            builder.HasIndex(e => new {  e.SparePartsId, e.MaintenanceCenterId }).IsUnique();

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
