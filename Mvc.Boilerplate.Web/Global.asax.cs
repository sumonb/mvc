using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Mvc.Boilerplate.Common.Helper;

namespace Mvc.Boilerplate.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //we are only going to use RazorVieEngine
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());


            //Start --- Custom active theme
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ActiveTheme"]))
            {
                var activeTheme = ConfigurationManager.AppSettings["ActiveTheme"];
                ViewEngines.Engines.Insert(0, new ThemeViewEngineHelper(activeTheme));
            };
            //End --- Custom active theme

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Execute code during application startup
            ApplicationStartUp.Execute();
            
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            Server.ClearError();
            ///////////////Response.Redirect("/Home/Error");
        }
    }
}
