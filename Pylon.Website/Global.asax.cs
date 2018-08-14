using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using NLog;
using Pylon.BL.Ninject;
using Pylon.Website.Controllers;
using Pylon.Website.Ninject;
using Rocket.Web;
using System;
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

		protected void Application_Error(Object sender, EventArgs e)
		{
			Logger logger = LogManager.GetCurrentClassLogger();
			var httpContext = ((MvcApplication)sender).Context;
			var currentController = string.Empty;
			var currentAction = string.Empty;
			var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));

			if (currentRouteData != null)
			{
				if (!string.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
				{
					currentController = currentRouteData.Values["controller"].ToString();
				}

				if (!string.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
				{
					currentAction = currentRouteData.Values["action"].ToString();
				}
			}
			var ex = Server.GetLastError();
			logger.Error($"{User.Identity.Name} : {((HttpException)ex).GetHttpCode()} : {ex.Message} ");
			var controller = new ErrorController();
			var routeData = new RouteData();
			var action = "Index";

			if (ex is HttpException)
			{
				switch (((HttpException)ex).GetHttpCode())
				{
					case 404:
						action = "NotFound";						
						break;
					default:
						action = "HttpError";
						break;
				}
			}

			httpContext.ClearError();
			httpContext.Response.Clear();
			httpContext.Response.StatusCode = ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500;
			httpContext.Response.TrySkipIisCustomErrors = true;

			routeData.Values["controller"] = "Error";
			routeData.Values["action"] = action;

			controller.ViewData.Model = new HandleErrorInfo(ex, currentController, currentAction);
			((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
		}
	}
}
