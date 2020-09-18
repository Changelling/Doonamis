using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilliconPower.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Infrastructure.Persistence.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Url)
                .IsRequired();
            builder
                .HasOne(i => i.Activity)
                .WithMany(a => a.Images)
                .HasForeignKey(i => i.ActivityId);
        }
    }
}
