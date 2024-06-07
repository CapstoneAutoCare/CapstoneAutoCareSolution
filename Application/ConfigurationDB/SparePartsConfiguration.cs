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
    public class SparePartsConfiguration : IEntityTypeConfiguration<SpareParts>
    {
        public void Configure(EntityTypeBuilder<SpareParts> builder)
        {
            builder.HasKey(c => c.SparePartId);
            builder.Property(e => e.SparePartId)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime");

            builder.HasOne(d => d.MaintananceSchedule)
                    .WithMany(d => d.Parts)
                    .HasForeignKey(d => d.MaintananceScheduleId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
