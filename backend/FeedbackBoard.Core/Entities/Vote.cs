namespace FeedbackBoard.Core.Entities;

public class Vote
{
    public Guid Id {get; set;}
    public Guid IdeaId { get; set; }
    public Idea Idea {get; set;} = null!;
    public Guid UserId { get; set; }
    public User User {get; set;} = null!;
    public DateTime CreatedAt { get; set; }
}