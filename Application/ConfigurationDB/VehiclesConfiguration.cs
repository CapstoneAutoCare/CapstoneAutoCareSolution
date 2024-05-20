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
    public class VehiclesConfiguration : IEntityTypeConfiguration<Vehicles>
    {
        public void Configure(EntityTypeBuilder<Vehicles> builder)
        {
            builder.HasKey(c => c.VehiclesId);
            builder.Property(e => e.VehiclesId)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime");


            builder.HasOne(d => d.VehicleModel)
                    .WithMany(d => d.Vehicles)
                    .HasForeignKey(d => d.VehicleModelId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Client)
                    .WithMany(d => d.Vehicles)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
