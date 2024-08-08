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
    public class MaintenanceTaskConfiguration : IEntityTypeConfiguration<MaintenanceTask>
    {
        public void Configure(EntityTypeBuilder<MaintenanceTask> builder)
        {
            builder.HasKey(c => c.MaintenanceTaskId);
            builder.Property(e => e.MaintenanceTaskId)
                    .ValueGeneratedOnAdd();

            //builder.HasKey(tim => new { tim.TechnicianId, tim.InformationMaintenanceId });

            builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime");


            builder.HasOne(d => d.Technician)
                   .WithMany(d => d.MaintenanceTasks)
                   .HasForeignKey(d => d.TechnicianId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.InformationMaintenance)
                   .WithMany(d => d.MaintenanceTasks)
                   .HasForeignKey(d => d.InformationMaintenanceId)
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
