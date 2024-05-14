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
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(c => c.AdminId);
            builder.Property(e => e.AdminId)
                    .ValueGeneratedOnAdd();
            builder.HasOne(d => d.Account)
                    .WithOne(d => d.Admin)
                    .HasForeignKey<Account>(d => d.AccountID)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
