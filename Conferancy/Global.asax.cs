using Conferancy.AutoMapper;
using Conference.Di;
using FluentValidation.Attributes;
using FluentValidation.Mvc;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Conference
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //var fluentValidationModelValidatorProvider = new FluentValidationModelValidatorProvider(new AttributedValidatorFactory());
            //ModelValidatorProviders.Providers.Add(fluentValidationModelValidatorProvider);
            //DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            //fluentValidationModelValidatorProvider.AddImplicitRequiredValidator = false;


            AutoMapper.Mapper.Initialize(config => config.AddProfile(new AppAutoMapperProfile()));

            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
