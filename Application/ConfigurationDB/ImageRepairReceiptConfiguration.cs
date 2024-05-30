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
    public class ImageRepairReceiptConfiguration : IEntityTypeConfiguration<ImageRepairReceipt>
    {
        public void Configure(EntityTypeBuilder<ImageRepairReceipt> builder)
        {
            builder.HasKey(c => c.ImageRepairReceiptId);
            builder.Property(e => e.ImageRepairReceiptId)
                    .ValueGeneratedOnAdd();
            builder.HasOne(d => d.Vehicle)
                    .WithMany(d => d.ImageRepairReceipts)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.MaintenanceCenter)
                    .WithMany(d => d.ImageRepairReceipts)
                    .HasForeignKey(d => d.MaintenanceCenterId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
