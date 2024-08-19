using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Infrastructure.Common;
using Infrastructure.Common.ModelSecurity;

namespace Infrastructure.ISecurity.Imp
{
    public class TokensHandler : ITokensHandler
    {
        private readonly JWToken _JWToken;
        private readonly IMemoryCache _memoryCache;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokensHandler(JWToken jWToken, IMemoryCache memoryCache, IHttpContextAccessor httpContextAccessor)
        {
            _JWToken = jWToken;
            _memoryCache = memoryCache;
            _httpContextAccessor = httpContextAccessor;
        }
        private static IEnumerable<Claim> GetClaimsFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            return jwtToken.Claims;
        }
        //public string ClaimsFromToken(string token)
        //{
        //    var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
        //    if (string.IsNullOrWhiteSpace(authorizationHeader))
        //    {
        //        throw new Exception("Authorization header is missing");
        //    }
        //    var tokens = authorizationHeader.Replace("Bearer ", "");
        //    var claims = GetClaimsFromToken(token);
        //    var username = claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;
        //    return username;
        //}
        public  string GetRoleFromJwt()
        {
            var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrWhiteSpace(authorizationHeader))
            {
                throw new Exception("Authorization header is missing");
            }

            var token = authorizationHeader.Replace("Bearer ", "");

            var claims = GetClaimsFromToken(token);

            // Tìm tuyên bố có tên là role
            var roleClaim = claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");

            return roleClaim?.Value;
        }
        public string ClaimsFromToken()
        {
            var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrWhiteSpace(authorizationHeader))
            {
                throw new Exception("Authorization header is missing");
            }

            var token = authorizationHeader.Replace("Bearer ", "");

            var claims = GetClaimsFromToken(token);

            var email = claims.FirstOrDefault(c => c.Type == "email")?.Value;

            return email;
        }
        public AccessToken CreateAccessToken(Account account)
        {
            var refresh = GenerateRefreshToken();
            var cacheKey = GetCacheKey(refresh.Token, account.Email);
            _memoryCache.Set(cacheKey, refresh, TimeSpan.FromDays(_JWToken.RefreshTokenExpiration));
            return BuildAccessToken(account, refresh);
        }
        private AccessToken BuildAccessToken(Account account, RefreshToken refreshToken)
        {
            var accessTokenExpiration = DateTime.UtcNow.AddDays(_JWToken.AccessTokenExpiration);

            var secretKeyBytes = Encoding.UTF8.GetBytes(_JWToken.JWTSecretKey);

            var securityToken = new JwtSecurityToken
            (
                issuer: _JWToken.Issuer,
                audience: _JWToken.Audience,
                claims: GetClaims(account),
                expires: accessTokenExpiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256)
            );

            var handler = new JwtSecurityTokenHandler();
            var accessToken = handler.WriteToken(securityToken);

            return new AccessToken(accessToken, accessTokenExpiration.Ticks, refreshToken);
        }
        private IEnumerable<Claim> GetClaims(Account account)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, account.AccountID.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, account.Email),
                new Claim(ClaimTypes.Role, account.Role)
            };

            return claims;
        }
        private RefreshToken GenerateRefreshToken()
        {

            var refreshToken = new RefreshToken
            {
                Token = Guid.NewGuid().ToString(),
                Expiration = DateTime.UtcNow.AddDays(_JWToken.RefreshTokenExpiration)
            };

            return refreshToken;
        }
        private string GetCacheKey(string token, string userName)
        {
            return $"RefreshToken:{userName}:{token}";
        }
        public void RevokeRefreshToken(string token, string userName)
        {
            throw new NotImplementedException();
        }

        public RefreshToken TakeRefreshToken(string token, string userName)
        {
            throw new NotImplementedException();
        }
    }
}