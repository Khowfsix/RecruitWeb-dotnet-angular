using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Service.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

/*
FLOW:
user login in => return
{
    accessToken:...
    refreshToken:...
    expiration: ...
}

*/

namespace Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public TokenService(
            IRefreshTokenRepository refreshTokenRepository,
            IConfiguration configuration,
            IMapper mapper)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        // Check if the refresh token is valid based on its properties and return a boolean value.
        private static bool IsRefreshTokenValid(RefreshToken existingToken)
        {
            // Is token already revoked, then return false
            //if (existingToken.RevokedByIp != null &&
            //    existingToken.RevokedOn != DateTime.MinValue)
            //{
            //    return false;
            //}

            // Token already expired, then return false
            if (existingToken.ExpiryOn <= DateTime.UtcNow)
            {
                return false;
            }
            return true;
        }
        public Task<RefreshToken> GetValidRefreshToken(string token, WebUser identityUser)
        {
            if (identityUser == null)
            {
                return null!;
            }

            var existingToken = identityUser.RefreshTokens.Where(x => x.Token == token).ToList();
            foreach (var rfToken in existingToken)
            {
                if (IsRefreshTokenValid(rfToken))
                    return Task.FromResult(rfToken);
            }
            return null!;
        }

        public Task<string> GenerateAccessToken(IEnumerable<Claim> authClaims)
        {
            var authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT: ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddSeconds(10),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256)
                );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Task.FromResult(accessToken);
        }

        public async Task<RefreshToken> GenerateRefreshToken(int expiryByDays, WebUser webUser)
        {
            var Buff = new byte[64];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(Buff);
            }

            var newRFTokenModel = new RefreshTokenModel
            {
                Token = Convert.ToBase64String(Buff),
                UserId = webUser.Id,
                CreatedOn = DateTime.UtcNow,
                ExpiryOn = DateTime.UtcNow.AddDays(expiryByDays),
            };

            return await _refreshTokenRepository.CreateRefreshToken(
                _mapper.Map<RefreshToken>(newRFTokenModel)
            );
        }

        public async Task<AuthenticationToken> GetAuthenticationToken(IEnumerable<Claim> claims, WebUser webUser)
        {

            var accessToken = await GenerateAccessToken(claims);
            var refreshToken = await GenerateRefreshToken(expiryByDays: 7, webUser: webUser);

            AuthenticationToken newAuthenticationToken = new()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token,
                ExpirationDate = refreshToken.ExpiryOn,
            };
            return newAuthenticationToken;
        }

        //private bool RevokeRefreshToken(string token = null!)
        //// Revokes the refresh token for the given user.
        //// If no token is provided, the token from the HttpContext.Request.Cookies["refreshToken"] is used.
        //// Returns true if the token is successfully revoked, otherwise false.
        //{
        //    token = token == null! ? HttpContext.Request.Cookies["refreshToken"]! : token!;
        //    var identityUser = _dbContext.Users.Include(x => x.RefreshTokens)
        //        .FirstOrDefault(x => x.RefreshTokens.Any(y => y.Token == token && y.UserId == x.Id));
        //    if (identityUser == null)
        //    {
        //        return false;
        //    }

        //    // Revoke Refresh token
        //    var existingToken = identityUser.RefreshTokens.FirstOrDefault(x => x.Token == token);
        //    existingToken!.RevokedByIp = HttpContext.Connection.RemoteIpAddress!.ToString();
        //    existingToken!.RevokedOn = DateTime.UtcNow;
        //    _dbContext.Update(identityUser);
        //    _dbContext.SaveChanges();
        //    return true;
        //}
    }
}
