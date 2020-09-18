using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilliconPower.Backend.Domain.Entities;
using SilliconPower.Backend.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Infrastructure.Persistence.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Date)
                .IsRequired();

            builder
                .HasOne(b => b.Activity)
                .WithMany(a => a.Bookings)
                .HasForeignKey(b => b.ActivityId);

            builder
                .HasOne(b => (ApplicationUser)b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);
        }
    }
}
