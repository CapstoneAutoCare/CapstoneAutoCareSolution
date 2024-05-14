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
    public class VehicleModelConfiguration : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.HasKey(c => c.VehicleModelId);
            builder.Property(e => e.VehicleModelId)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime");


            builder.HasOne(d => d.VehiclesBrand)
                    .WithMany(d => d.VehicleModels)
                    .HasForeignKey(d => d.VehiclesBrandId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
