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
    public class TechnicianConfiguration : IEntityTypeConfiguration<Technician>
    {
        public void Configure(EntityTypeBuilder<Technician> builder)
        {
            builder.HasKey(c => c.TechnicianId);
            builder.Property(e => e.TechnicianId)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.Birthday)
                .HasColumnType("datetime");
            builder.HasIndex(e => e.AccountId).IsUnique();

       

            builder.HasOne(d => d.MaintenanceCenter)
                    .WithMany(d => d.Technicians)
                    .HasForeignKey(d => d.CenterId)
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}