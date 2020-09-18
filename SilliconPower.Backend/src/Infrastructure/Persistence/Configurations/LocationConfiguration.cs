using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilliconPower.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Infrastructure.Persistence.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.Id);
            builder.OwnsOne(b => b.Coordinate);
            builder.Property(c => c.Name)
                .IsRequired();            
            builder
                .HasMany(l => l.Activities)
                .WithOne(a => a.Location)
                .HasForeignKey(a => a.LocationId);
        }
    }
}
