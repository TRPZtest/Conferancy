using Conferency.Data.Db;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Conference.Auth
{
    public class AuthService
    {
    
        public string GenerateJwt(User user)
        {
            var claims = new List<Claim>
            {
                    new Claim("UserId", user.Id.ToString())                  
            };

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        public long ValidateJwt(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();

            var options = new TokenValidationParameters
            {
                // укзывает, будет ли валидироваться издатель при валидации токена
                ValidateIssuer = true,
                // строка, представляющая издателя
                ValidIssuer = AuthOptions.ISSUER,

                // будет ли валидироваться потребитель токена
                ValidateAudience = true,
                // установка потребителя токена
                ValidAudience = AuthOptions.AUDIENCE,
                // будет ли валидироваться время существования
                ValidateLifetime = true,

                // установка ключа безопасности
                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                // валидация ключа безопасности
                ValidateIssuerSigningKey = true,
            };
                       
            try
            {
                Microsoft.IdentityModel.Tokens.SecurityToken token = new JsonWebToken(jwt);
                var result = handler.ValidateToken(jwt, options, out token);

                if (token != null)
                {
                    var userIdClaim = result.Claims.FirstOrDefault(x => x.Type == "UserId");

                    long.TryParse(userIdClaim.Value, out long id);

                    if (id == 0)
                        throw new Exception("User id parsing error");

                    return id;                  
                }

                return 0;
            }
            catch
            {
                return 0;
            }                   
        }
    }
}