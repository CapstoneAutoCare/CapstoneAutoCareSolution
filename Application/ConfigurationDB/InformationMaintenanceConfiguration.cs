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
    public class InformationMaintenanceConfiguration : IEntityTypeConfiguration<InformationMaintenance>
    {
        public void Configure(EntityTypeBuilder<InformationMaintenance> builder)
        {
            builder.HasKey(c => c.InformationMaintenanceId);
            builder.Property(e => e.InformationMaintenanceId)
                    .ValueGeneratedOnAdd();
            builder.Property(e => e.CreatedDate)
               .HasColumnType("datetime");
            builder.Property(e => e.FinishedDate)
                .HasColumnType("datetime");
            builder.HasOne(d => d.StaffCare)
                    .WithMany(d => d.InformationMaintenances)
                    .HasForeignKey(d => d.StaffCareId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
