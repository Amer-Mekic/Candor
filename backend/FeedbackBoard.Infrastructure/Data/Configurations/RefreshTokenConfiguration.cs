using FeedbackBoard.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeedbackBoard.Infrastructure.Data.Configurations;
public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder.Property(r => r.Token)
            .IsRequired();
        
        builder.Property(r => r.CreatedAt)
            .IsRequired();
        
        builder.Property(r => r.ExpiresAt)
            .IsRequired();
        
        builder.Property(r => r.IsRevoked)
            .IsRequired()
            .HasDefaultValue(false);

        builder.HasOne(r => r.User)
            .WithMany(u => u.Tokens)
            .HasForeignKey(r => r.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}