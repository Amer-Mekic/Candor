using FeedbackBoard.Core.Entities;

namespace FeedbackBoard.Core.Interfaces;

public interface IVoteRepository
{
    Task<Vote?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<Vote>> GetByIdeaIdAsync(Guid ideaId);
    Task<Vote?> GetByUserIdAndIdeaIdAsync(Guid userId, Guid ideaId);
    Task<IReadOnlyList<Vote>> GetByUserIdAsync(Guid userId);
    Task AddAsync(Vote vote);
    Task DeleteAsync(Vote vote);
}