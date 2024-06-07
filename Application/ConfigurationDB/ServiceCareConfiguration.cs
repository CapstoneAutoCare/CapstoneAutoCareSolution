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
    public class ServiceCareConfiguration : IEntityTypeConfiguration<ServiceCare>
    {
        public void Configure(EntityTypeBuilder<ServiceCare> builder)
        {
            builder.HasKey(c => c.ServiceCareId);
            builder.Property(e => e.ServiceCareId)
                    .ValueGeneratedOnAdd();
            builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime");
            builder.HasOne(d => d.MaintananceSchedule)
                    .WithMany(d => d.ServiceCares)
                    .HasForeignKey(d => d.MaintananceScheduleId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
