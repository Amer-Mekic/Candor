using FeedbackBoard.Core.Interfaces;

namespace FeedbackBoard.Core.Entities;

public class Comment : IHasTimestamps
{
    public Guid Id {get; set;}
    public string Body {get; set;} = "";
    public Guid IdeaId { get; set; }
    public Idea Idea {get; set;} = null!;
    public Guid AuthorId { get; set; }
    public User Author {get; set;} = null!;
    public Guid ParentCommentId { get; set; }
    public Comment? ParentComment {get; set;} = null;
    public bool IsDeleted {get; set;} = false;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}