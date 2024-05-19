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
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.HasKey(c => c.ReceiptId);
            builder.Property(e => e.ReceiptId)
                    .ValueGeneratedOnAdd();
            builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime");
            builder.HasOne(d => d.InformationMaintenance)
                    .WithOne(d => d.Receipt)
                    .HasForeignKey<MaintenanceInformation>(d => d.InformationMaintenanceId)
                    .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
