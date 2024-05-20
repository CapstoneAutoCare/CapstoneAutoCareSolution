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
    public class CustomerCareConfiguration : IEntityTypeConfiguration<CustomerCare>
    {
        public void Configure(EntityTypeBuilder<CustomerCare> builder)
        {
            builder.HasKey(c => c.CustomerCareId);
            builder.Property(e => e.CustomerCareId)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.Birthday)
                .HasColumnType("datetime");
            builder.HasIndex(e => e.AccountId).IsUnique();

            //builder.HasOne(d => d.Account)
            //        .WithOne(d => d.CustomerCare)
            //        .HasForeignKey<Account>(d => d.AccountID)
            //        .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.MaintenanceCenter)
                    .WithMany(d => d.CustomerCares)
                    .HasForeignKey(d => d.CenterId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
