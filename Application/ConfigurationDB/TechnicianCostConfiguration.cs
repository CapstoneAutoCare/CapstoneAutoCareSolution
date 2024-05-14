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
    public class TechnicianCostConfiguration : IEntityTypeConfiguration<TechnicianCost>
    {
        public void Configure(EntityTypeBuilder<TechnicianCost> builder)
        {
            builder.HasKey(c => c.TechnicialCostId);
            builder.Property(e => e.TechnicialCostId)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime");
           

            builder.HasOne(d => d.InformationMaintenance)
                    .WithMany(d => d.TechnicianCost)
                    .HasForeignKey(d => d.InformationMaintenanceId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
