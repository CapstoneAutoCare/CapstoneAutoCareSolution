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
    public class StaffCareConfiguration : IEntityTypeConfiguration<StaffCare>
    {
        public void Configure(EntityTypeBuilder<StaffCare> builder)
        {
            builder.HasKey(c => c.StaffCareId);
            builder.Property(e => e.StaffCareId)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.Birthday)
                .HasColumnType("datetime");

            builder.HasOne(d => d.Account)
                    .WithOne(d => d.StaffCare)
                    .HasForeignKey<Account>(d => d.AccountID)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.MaintenanceCenter)
                    .WithMany(d => d.StaffCares)
                    .HasForeignKey(d => d.CenterId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
