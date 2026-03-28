using FeedbackBoard.Core.Entities;

namespace FeedbackBoard.Core.Interfaces;
public interface IIdeaRepository
{
    Task<Idea?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<Idea>> GetAllAsync();
    Task<IReadOnlyList<Idea>> GetByUserIdAsync(Guid userId);
    Task<IReadOnlyList<Idea>> GetAllIdeasByCategoryIdAsync(Guid categoryId);
    Task AddAsync(Idea idea);
    Task UpdateAsync(Idea idea);
    Task DeleteAsync(Idea idea);
}