using AutoMapper;
using Conference.Data.Db;
using Conference.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conferancy.AutoMapper
{
    public class AppAutoMapperProfile : Profile
    {
        public AppAutoMapperProfile()
        {
            CreateMap<RegistrationViewModel, User>();
            
        }
    }
}