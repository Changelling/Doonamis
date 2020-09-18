
using SilliconPower.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SilliconPower.Backend.Infrastructure.Identity;

namespace SilliconPower.Backend.Infrastructure.Persistence.Configurations
{
    public class AssessmentConfiguration : IEntityTypeConfiguration<Assessment>
    {
        public void Configure(EntityTypeBuilder<Assessment> builder)
        {
            builder.HasKey(assessment => assessment.Id);
            builder.OwnsOne(b => b.Rating);
            builder
                .HasOne(assessment => assessment.Activity)
                .WithMany(activity => activity.Assessments)
                .HasForeignKey(assessment => assessment.ActivityId);
            builder                
                .HasOne(assessment => (ApplicationUser)assessment.User)
                .WithMany(u => u.Assessments)
                .HasForeignKey(assessment => assessment.UserId);
        }
    }
}
