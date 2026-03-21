namespace FeedbackBoard.Core.Entities;

public class Category
{
    public Guid Id {get; set;}
    public string Name {get; set;} = "";
    public string Slug { get; set; } = "";
    public string Color { get; set; } = "";
    public int SortOrder { get; set; } = 0;
    public DateTime CreatedAt { get; set; }
    public ICollection<Idea> Comments { get; set; } = [];
}