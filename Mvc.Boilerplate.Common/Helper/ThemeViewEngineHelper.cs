using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mvc.Boilerplate.Common.Helper
{
    public class ThemeViewEngineHelper : RazorViewEngine
    {
        //1.Add the following into the MVC web project in order to support custom Theme
        //////////protected void Application_Start()
        //////////{
        //////////    if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ActiveTheme"]))
        //////////    {
        //////////        var activeTheme = ConfigurationManager.AppSettings["ActiveTheme"];
        //////////        ViewEngines.Engines.Insert(0, new ThemeViewEngine(activeTheme));
        //////////    };
        //////////}
      
        public ThemeViewEngineHelper(string activeThemeName)
        {
            ViewLocationFormats = new[]
            {
                "~/Views/Themes/" + activeThemeName + "/{1}/{0}.cshtml",
                "~/Views/Themes/" + activeThemeName + "/Shared/{0}.cshtml"
            };

            PartialViewLocationFormats = new[]
            {
                "~/Views/Themes/" + activeThemeName + "/{1}/{0}.cshtml",
                "~/Views/Themes/" + activeThemeName + "/Shared/{0}.cshtml"
            };

            AreaViewLocationFormats = new[]
            {
                "~Areas/{2}/Views/Themes/" + activeThemeName + "/{1}/{0}.cshtml",
                "~Areas/{2}/Views/Themes/" + activeThemeName + "/Shared/{0}.cshtml"
            };

            AreaPartialViewLocationFormats = new[]
            {
                "~Areas/{2}/Views/Themes/" + activeThemeName + "/{1}/{0}.cshtml",
                "~Areas/{2}/Views/Themes/" + activeThemeName + "/Shared/{0}.cshtml"
            };
        }
    }
}
