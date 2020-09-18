using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilliconPower.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Infrastructure.Persistence.Configurations
{
    public class AvailabilityConfiguration : IEntityTypeConfiguration<Availability>
    {
        public void Configure(EntityTypeBuilder<Availability> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Date)
                .IsRequired();
            builder
                .HasOne(i => i.Activity)
                .WithMany(a => a.Availabilities)
                .HasForeignKey(i => i.ActivityId);
        }
    }
}
