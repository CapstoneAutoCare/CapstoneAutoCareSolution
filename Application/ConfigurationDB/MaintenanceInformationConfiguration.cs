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
    public class MaintenanceInformationConfiguration : IEntityTypeConfiguration<MaintenanceInformation>
    {
        public void Configure(EntityTypeBuilder<MaintenanceInformation> builder)
        {
            builder.HasKey(c => c.InformationMaintenanceId);
            builder.Property(e => e.InformationMaintenanceId)
                    .ValueGeneratedOnAdd();

            builder.HasIndex(e => new { e.MaintenanceVehiclesDetailId, e.BookingId, e.CustomerCareId })
           .IsUnique();

            builder.Property(e => e.CreatedDate)
               .HasColumnType("datetime");
            builder.Property(e => e.FinishedDate)
                .HasColumnType("datetime");
            //builder.HasIndex(e => e.BookingId).IsUnique();

            builder.HasOne(d => d.CustomerCare)
                    .WithMany(d => d.InformationMaintenances)
                    .HasForeignKey(d => d.CustomerCareId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Booking)
                    .WithMany(d => d.MaintenanceInformations)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.MaintenanceVehiclesDetail)
                    .WithMany(d => d.MaintenanceInformations)
                    .HasForeignKey(d => d.MaintenanceVehiclesDetailId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
