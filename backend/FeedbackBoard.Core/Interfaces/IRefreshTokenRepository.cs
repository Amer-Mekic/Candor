namespace FeedbackBoard.Core.Interfaces;

using FeedbackBoard.Core.Entities;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetByIdAsync(Guid id);
    Task<RefreshToken?> GetByUserIdAsync(Guid userId);
    Task AddAsync(RefreshToken refreshToken);
    Task UpdateAsync(RefreshToken refreshToken);
    Task DeleteAsync(RefreshToken refreshToken);
}