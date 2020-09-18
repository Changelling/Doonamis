using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilliconPower.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired();

            builder
                .HasMany(c => c.Activities)
                .WithOne(a => a.Category)
                .HasForeignKey(c => c.CategoryId);
        }
    }
}
