using Data.Entities;
using System.Security.Claims;

namespace Service.Interfaces
{
    public interface ITokenService
    {
        Task<AuthenticationToken> GetAuthenticationToken(IEnumerable<Claim> claims, WebUser webUser);

        Task<string> GenerateAccessToken(IEnumerable<Claim> authClaims);

        Task<RefreshToken> GenerateRefreshToken(int expiryByDays, WebUser webUser);

        Task<RefreshToken> GetValidRefreshToken(string token, WebUser identityUser);

        //Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
        //Task<bool> RevokeRefreshToken(string token);
    }

    public class AuthenticationToken
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime? ExpirationDate { get; set; } = DateTime.MinValue;
    }
}