using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Otc.SessionContext.Abstractions;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Otc.SessionContext.AspNetCore.Jwt
{
    public class SessionSerializer<TSessionData> : ISessionSerializer<TSessionData>
        where TSessionData : ISessionData
    {
        private readonly JwtConfiguration jwtConfiguration;
        private readonly JwtSecurityTokenHandler tokenHandler;

        public SessionSerializer(JwtConfiguration jwtConfiguration)
        {
            this.jwtConfiguration = jwtConfiguration ?? throw new ArgumentNullException(nameof(jwtConfiguration));
            tokenHandler = new JwtSecurityTokenHandler();
        }

        public string Serialize(TSessionData sessionData)
        {
            return tokenHandler.WriteToken(GenerateJwtSecurityToken(sessionData));
        }

        private JwtSecurityToken GenerateJwtSecurityToken(TSessionData sessionData)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, sessionData.UserId),
                new Claim(JwtConfiguration.SessionDataJwtTypeName, JsonConvert.SerializeObject(sessionData))
            };

            return new JwtSecurityToken(
                issuer: jwtConfiguration.Issuer,
                audience: jwtConfiguration.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(jwtConfiguration.ExpiresMinutes),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.SecretKey)),
                    SecurityAlgorithms.HmacSha256)
            );
        }
    }
}
