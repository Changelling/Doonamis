using SilliconPower.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SilliconPower.Backend.Infrastructure.Persistence.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
            builder.OwnsOne(b => b.Price);

            builder
                .HasOne(a => a.Location)
                .WithMany(l => l.Activities)
                .HasForeignKey(a => a.LocationId);

            builder
                .HasOne(a => a.Category)
                .WithMany(c => c.Activities)
                .HasForeignKey(a => a.CategoryId);

            builder
                .HasMany(a => a.Assessments)
                .WithOne(a => a.Activity)
                .HasForeignKey(a => a.ActivityId);

            builder
                .HasMany(a => a.Images)
                .WithOne(i => i.Activity)
                .HasForeignKey(i => i.ActivityId);

            builder
                .HasMany(a => a.Bookings)
                .WithOne(b => b.Activity)
                .HasForeignKey(b => b.ActivityId);
        }
    }
}
