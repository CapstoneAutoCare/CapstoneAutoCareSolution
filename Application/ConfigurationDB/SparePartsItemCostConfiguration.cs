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
    public class SparePartsItemCostConfiguration : IEntityTypeConfiguration<SparePartsItemCost>
    {
        public void Configure(EntityTypeBuilder<SparePartsItemCost> builder)
        {
            builder.HasKey(c => c.SparePartsItemCostId);
            builder.Property(e => e.SparePartsItemCostId)
                    .ValueGeneratedOnAdd();

            builder.HasOne(d => d.SparePartsItem)
                     .WithMany(d => d.SparePartsItemCost)
                     .HasForeignKey(d => d.SparePartsItemId)
                     .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
