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
    public class MaintenanceHistoryStatusConfiguration : IEntityTypeConfiguration<MaintenanceHistoryStatus>
    {
        public void Configure(EntityTypeBuilder<MaintenanceHistoryStatus> builder)
        {
            builder.HasKey(c => c.MaintenanceHistoryStatusId);
            builder.Property(e => e.MaintenanceHistoryStatusId)
                    .ValueGeneratedOnAdd();
            builder.HasOne(d => d.MaintenanceInformation)
                    .WithMany(d => d.MaintenanceHistoryStatuses)
                    .HasForeignKey(d => d.MaintenanceInformationId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
