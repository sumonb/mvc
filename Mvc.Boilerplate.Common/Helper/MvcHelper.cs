using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Mvc.Boilerplate.Common.Helper
{
    //http://www.splinter.com.au/httpcontext-vs-httpcontextbase-vs-httpcontext/

    public class MvcHelper
    {
        private readonly HttpContextWrapper _httpContext;

        public MvcHelper()
        {
            _httpContext =
                new HttpContextWrapper(System.Web.HttpContext.Current);
        }

        public string RequestedControllerName
        {
            get { return _httpContext.Request.RequestContext.RouteData.Values["controller"].ToString().ToLower(); }
        }

        public string RequestedActionName
        {
            get { return _httpContext.Request.RequestContext.RouteData.Values["action"].ToString().ToLower(); }
        }
    }
}
