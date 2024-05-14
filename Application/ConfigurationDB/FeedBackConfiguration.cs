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
    public class FeedBackConfiguration : IEntityTypeConfiguration<FeedBack>
    {
        public void Configure(EntityTypeBuilder<FeedBack> builder)
        {
            builder.HasKey(c => c.FeedBackId);
            builder.Property(e => e.FeedBackId)
                    .ValueGeneratedOnAdd();
            builder.HasOne(d => d.MaintenanceCenter)
                    .WithMany(d => d.FeedBacks)
                    .HasForeignKey(d => d.MaintenanceCenterId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.Receipt)
                    .WithOne(d => d.FeedBack)
                    .HasForeignKey<Receipt>(d => d.ReceiptId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
