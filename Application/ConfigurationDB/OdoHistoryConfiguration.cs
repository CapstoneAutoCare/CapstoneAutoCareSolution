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
    public class OdoHistoryConfiguration : IEntityTypeConfiguration<OdoHistory>
    {
        public void Configure(EntityTypeBuilder<OdoHistory> builder)
        {
            builder.HasKey(c => c.OdoHistoryId);
            builder.Property(e => e.OdoHistoryId)
                    .ValueGeneratedOnAdd();
            builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime");
            builder.HasOne(d => d.Vehicles)
                    .WithMany(d => d.OdoHistories)
                    .HasForeignKey(d => d.VehiclesId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.MaintenanceInformation)
                    .WithOne(d => d.OdoHistory)
                    .HasForeignKey<MaintenanceInformation>(d => d.InformationMaintenanceId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
