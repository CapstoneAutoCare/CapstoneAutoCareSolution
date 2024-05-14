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
    public class MaintenanceCenterConfiguration : IEntityTypeConfiguration<MaintenanceCenter>
    {
        public void Configure(EntityTypeBuilder<MaintenanceCenter> builder)
        {
            builder.HasKey(c => c.MaintenanceCenterId);
            builder.Property(e => e.MaintenanceCenterId)
                    .ValueGeneratedOnAdd();
            builder.HasOne(d => d.Account)
                    .WithOne(d => d.MaintenanceCenter)
                    .HasForeignKey<Account>(d => d.AccountID)
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
