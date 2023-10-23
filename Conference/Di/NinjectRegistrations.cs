using AutoMapper;
using Conference.Auth;
using Conference.Data;
using Conferency.Data;
using Conferency.Data.Db;
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
            Bind<IUserRepository>().To<UserRepository>().InScope(ctx => ctx.Request);
        }
    }
}