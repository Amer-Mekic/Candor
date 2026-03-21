using FeedbackBoard.Core.Interfaces;

namespace FeedbackBoard.Core.Entities;
public class Idea: IHasTimestamps
{
    public Guid Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Slug { get; set; } = "";
    public IdeaStatus Status { get; set; } = IdeaStatus.Open;
    public bool IsPinned { get; set; }
    public bool IsDeleted { get; set; }
    public int VoteCount { get; set; }
    public Guid AuthorId { get; set; }
    public User Author { get; set; } = null!;
    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }
    public string? AdminNote { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<Vote> Votes { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];
}

public enum IdeaStatus
{
    Open, UnderReview, Planned, InProgress, Done, Declined
}