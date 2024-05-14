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
    public class VehiclesBrandConfiguration : IEntityTypeConfiguration<VehiclesBrand>
    {
        public void Configure(EntityTypeBuilder<VehiclesBrand> builder)
        {
            builder.HasKey(c => c.VehiclesBrandId);
            builder.Property(e => e.VehiclesBrandId)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime");

        }
    }
}
