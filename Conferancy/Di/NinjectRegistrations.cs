using AutoMapper;
using Conferancy.AutoMapper;
using Conference.Data;
using Conference.Data.Db;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conference.Di
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<AppDbContext>().To<AppDbContext>();
            Bind<IConferanceRepository>().To<ConferanceRepository>();           
        }
    }
}