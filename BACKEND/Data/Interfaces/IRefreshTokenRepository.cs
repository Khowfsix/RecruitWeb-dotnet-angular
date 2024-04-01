using Data.Entities;

namespace Data.Interfaces
{
    public interface IRefreshTokenRepository
    {
        public Task<RefreshToken> CreateRefreshToken(RefreshToken refreshToken);

        public Task<RefreshToken> GetRefreshToken(string refreshToken);

        public Task<RefreshToken> UpdateRefreshToken(RefreshToken refreshToken, int refreshTokenId);
    }
}