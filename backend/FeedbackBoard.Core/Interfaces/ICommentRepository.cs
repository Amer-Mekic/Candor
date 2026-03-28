namespace FeedbackBoard.Core.Interfaces;

using FeedbackBoard.Core.Entities;

public interface ICommentRepository
{
    Task<Comment?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<Comment>> GetByIdeaIdAsync(Guid ideaId);
    Task<IReadOnlyList<Comment>> GetByUserIdAsync(Guid userId);
    Task<IReadOnlyList<Comment>> GetByParentCommentIdAsync(Guid parentCommentId);
    Task AddAsync(Comment comment);
    Task UpdateAsync(Comment comment);
    Task DeleteAsync(Comment comment);
}