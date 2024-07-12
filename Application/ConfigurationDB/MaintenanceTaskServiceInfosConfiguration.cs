using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Application.ConfigurationDB
{
    public class MaintenanceTaskServiceInfosConfiguration : IEntityTypeConfiguration<MaintenanceTaskServiceInfo>
    {
        public void Configure(EntityTypeBuilder<MaintenanceTaskServiceInfo> builder)
        {
            builder.HasKey(c => c.MaintenanceTaskServiceInfoId);
            builder.Property(e => e.MaintenanceTaskServiceInfoId)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime");


            builder.HasOne(d => d.MaintenanceTask)
                    .WithMany(d => d.MaintenanceTaskServiceInfos)
                    .HasForeignKey(d => d.MaintenanceTaskId)
                    .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
