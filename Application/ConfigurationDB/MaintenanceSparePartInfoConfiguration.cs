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
    public class MaintenanceSparePartInfoConfiguration : IEntityTypeConfiguration<MaintenanceSparePartInfo>
    {
        public void Configure(EntityTypeBuilder<MaintenanceSparePartInfo> builder)
        {
            builder.HasKey(c => c.MaintenanceSparePartInfoId);
            builder.Property(e => e.MaintenanceSparePartInfoId)
                    .ValueGeneratedOnAdd();


            builder.HasIndex(e => new { e.InformationMaintenanceId, e.SparePartsItemCostId })
                .IsUnique();


            builder.HasOne(d => d.SparePartsItemCost)
                    .WithMany(d => d.MaintenanceSparePartInfos)
                    .HasForeignKey(d => d.SparePartsItemCostId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.InformationMaintenance)
                    .WithMany(d => d.MaintenanceSparePartInfos)
                    .HasForeignKey(d => d.InformationMaintenanceId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
