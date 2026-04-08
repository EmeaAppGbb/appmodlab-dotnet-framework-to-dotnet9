using System;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NorthwindTechUniversity.Web.App_Start;
using NorthwindTechUniversity.Web.Data;
using NorthwindTechUniversity.Web.Mappings;

namespace NorthwindTechUniversity.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            // Unity DI container
            UnityConfig.RegisterComponents();
            
            // Legacy: Static AutoMapper initialization (should use DI in modern apps)
            AutoMapperConfig.Configure();
            
            // EF6 database initializer
            Database.SetInitializer(new NorthwindTechDbInitializer());
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // TODO: Implement proper error logging
            var exception = Server.GetLastError();
            System.Diagnostics.Trace.WriteLine($"Unhandled exception: {exception?.Message}");
        }
    }
}
