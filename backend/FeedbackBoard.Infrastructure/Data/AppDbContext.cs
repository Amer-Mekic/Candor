using Microsoft.EntityFrameworkCore;
using FeedbackBoard.Core.Entities;
using FeedbackBoard.Core.Interfaces;

namespace FeedbackBoard.Infrastructure.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Idea> Ideas => Set<Idea>();
    public DbSet<Vote> Votes => Set<Vote>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Vote>()
         .HasIndex(v => new { v.IdeaId, v.UserId })
         .IsUnique();

        b.Entity<Idea>()
         .HasQueryFilter(i => !i.IsDeleted);

        b.Entity<Idea>()
         .Property(i => i.Status)
         .HasConversion<string>();

        b.Entity<User>()
         .Property(u => u.Role)
         .HasConversion<string>();
    }

    public override Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        foreach (var entry in ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Modified))
        {
            if (entry.Entity is IHasTimestamps entity)
                entity.UpdatedAt = DateTime.UtcNow;
        }
        return base.SaveChangesAsync(ct);
    }
}