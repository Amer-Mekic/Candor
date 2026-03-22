using FeedbackBoard.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeedbackBoard.Infrastructure.Data.Configurations;
public class VoteConfiguration : IEntityTypeConfiguration<Vote>
{
    public void Configure(EntityTypeBuilder<Vote> builder)
    {
        builder.HasKey(v => v.Id);
        
        builder.Property(v => v.CreatedAt)
            .IsRequired();

        builder.HasOne(v => v.User)
            .WithMany(u => u.Votes)
            .HasForeignKey(v => v.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasIndex(v => new { v.IdeaId, v.UserId })
            .IsUnique();
        
        builder.HasOne(v => v.Idea)
            .WithMany(i => i.Votes)
            .HasForeignKey(v => v.IdeaId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}