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
    public class MaintananceScheduleConfiguration : IEntityTypeConfiguration<MaintananceSchedule>
    {
        public void Configure(EntityTypeBuilder<MaintananceSchedule> builder)
        {
            builder.HasKey(c => c.MaintananceScheduleId);
            builder.Property(e => e.MaintananceScheduleId)
                    .ValueGeneratedOnAdd();
            builder.Property(e => e.CreateDate)
               .HasColumnType("datetime");
            builder.HasOne(d => d.VehicleModel)
                    .WithMany(d => d.MaintenanceSchedules)
                    .HasForeignKey(d => d.VehicleModelId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
