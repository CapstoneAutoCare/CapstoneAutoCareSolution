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
    public class MaintenanceTaskSparePartInfosConfiguration : IEntityTypeConfiguration<MaintenanceTaskSparePartInfo>
    {
        public void Configure(EntityTypeBuilder<MaintenanceTaskSparePartInfo> builder)
        {
            builder.HasKey(c => c.MaintenanceTaskSparePartInfoId);
            builder.Property(e => e.MaintenanceTaskSparePartInfoId)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime");


            builder.HasOne(d => d.MaintenanceTask)
                    .WithMany(d => d.MaintenanceTaskSparePartInfos)
                    .HasForeignKey(d => d.MaintenanceTaskId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
