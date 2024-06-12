using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ConfigurationDB
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(c => c.NotificationId);
            builder.Property(e => e.NotificationId)
                    .ValueGeneratedOnAdd();
            builder.HasOne(d => d.Account)
                    .WithMany(d => d.Notifications)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
