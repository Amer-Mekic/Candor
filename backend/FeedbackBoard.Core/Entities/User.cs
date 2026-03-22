using FeedbackBoard.Core.Interfaces;

namespace FeedbackBoard.Core.Entities;
public class User : IHasTimestamps
{
    public Guid Id { get; set; }
    public string Email { get; set; } = "";
    public string DisplayName { get; set; } = "";
    public string? PasswordHash { get; set; }
    public string? AvatarUrl { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<Idea> Ideas { get; set; } = [];
    public ICollection<Vote> Votes { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];
    public ICollection<RefreshToken> Tokens { get; set; } = [];
}

public enum UserRole { User, Admin }