using AutoMapper;
using Conferancy.Auth;
using Conferancy.AutoMapper;
using Conference.Data;
using Conference.Data.Db;
using Microsoft.IdentityModel.Tokens;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;

namespace Conference.Di
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<AppDbContext>().To<AppDbContext>().InScope(ctx => ctx.Request);
            Bind<IConferanceRepository>().To<ConferanceRepository>().InScope(ctx => ctx.Request);

            var jwtValidationParameters = new TokenValidationParameters
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
        }
    }
}