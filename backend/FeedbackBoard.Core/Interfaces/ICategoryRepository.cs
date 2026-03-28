using FeedbackBoard.Core.Entities;

namespace FeedbackBoard.Core.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<Category>> GetAllAsync();
    Task<Category?> GetByIdeaIdAsync(Guid ideaId);
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(Category category);
}