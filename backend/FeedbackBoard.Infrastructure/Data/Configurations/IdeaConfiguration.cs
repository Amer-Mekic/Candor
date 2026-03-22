using FeedbackBoard.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeedbackBoard.Infrastructure.Data.Configurations;
public class IdeaConfiguration : IEntityTypeConfiguration<Idea>
{
    public void Configure(EntityTypeBuilder<Idea> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(i => i.Slug)
            .IsRequired()
            .HasMaxLength(220);

        builder.Property(i => i.Description)
            .IsRequired();

        builder.Property(i => i.Status)
            .HasConversion<string>()
            .HasMaxLength(15)
            .IsRequired();
        
        builder.Property(i => i.AdminNote)
            .HasMaxLength(1000);

        builder.Property(i => i.VoteCount)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(i => i.IsPinned)
            .IsRequired()
            .HasDefaultValue(false);

        builder.HasOne(i => i.Author)
               .WithMany(u => u.Ideas)
               .HasForeignKey(i => i.AuthorId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(i => i.Category)
                .WithMany(c => c.Ideas)
                .HasForeignKey(i => i.CategoryId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        
        builder.Property(i => i.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(i => i.CreatedAt)
            .IsRequired();

        builder.Property(i => i.UpdatedAt)
            .IsRequired();

        builder.HasIndex(i => i.Slug)
            .IsUnique();

        // Always adds this query to any other, to exclude soft-deleted ideas
        // Use .IgnoreQueryFilters() on a specific query to bypass.
        builder.HasQueryFilter(i => !i.IsDeleted);
    }
}