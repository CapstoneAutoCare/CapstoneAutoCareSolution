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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.ClientId);
            builder.Property(e => e.ClientId)
                    .ValueGeneratedOnAdd();
            builder.HasOne(d => d.Account)
                   .WithOne(d => d.Client)
                   .HasForeignKey<Account>(d => d.AccountID)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
