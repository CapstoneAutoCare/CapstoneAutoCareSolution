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
    public class TechnicianConfiguration : IEntityTypeConfiguration<Technician>
    {
        public void Configure(EntityTypeBuilder<Technician> builder)
        {
            builder.HasKey(c => c.TechnicianId);
            builder.Property(e => e.TechnicianId)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime");


            builder.HasOne(d => d.InformationMaintenance)
                    .WithMany(d => d.Technicians)
                    .HasForeignKey(d => d.InformationMaintenanceId)
                    .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(d => d.StaffCare)
                    .WithOne(d => d.Technician)
                    .HasForeignKey<StaffCare>(d => d.StaffCareId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
