using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using Pylon.BL.Ninject;
using Pylon.Website.Ninject;
using Rocket.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Pylon.Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MapperConfig.Initialize();
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule orderModule = new UiModule();
            NinjectModule serviceModule = new BlModule();
            var kernel = new StandardKernel(orderModule, serviceModule);
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
