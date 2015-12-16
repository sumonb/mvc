using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Mvc.Boilerplate.Common.Helper
{
    //http://www.splinter.com.au/httpcontext-vs-httpcontextbase-vs-httpcontext/

    public static class MvcHelper
    {
        private static readonly HttpContextWrapper _httpContext;

        static MvcHelper()
        {
            _httpContext =
                new HttpContextWrapper(System.Web.HttpContext.Current);
        }

        public static string RequestedControllerName
        {
            get { return _httpContext.Request.RequestContext.RouteData.Values["controller"].ToString().ToLower(); }
        }

        public static string RequestedActionName
        {
            get { return _httpContext.Request.RequestContext.RouteData.Values["action"].ToString().ToLower(); }
        }

        public static List<MvcHelperCustomerAttributeInfo> GetCustomAttributeInfo<T>()
        {
            var retInfo = new List<MvcHelperCustomerAttributeInfo>();

            var assembly = System.Reflection.Assembly.GetCallingAssembly();
            foreach (var type in assembly.GetTypes())
            {

                if (!type.IsSubclassOf(typeof(Controller)))
                {
                    continue;
                }


                var retActionAttr = type.GetCustomAttributes(typeof(T), true) as T[];
                if (retActionAttr == null || !retActionAttr.Any())
                {
                    continue;
                }

                retInfo.AddRange(retActionAttr.Select(i => new MvcHelperCustomerAttributeInfo() {ControllerName = type.Name, AttributeObject = i}));

                //now process all the action methods
                foreach (var method in type.GetMethods())
                {
                                   
                    var retActionAttrM = method.GetCustomAttributes(typeof(T), false);

                    if (!retActionAttrM.Any())
                    {
                        continue;
                    }

                    retInfo.AddRange(retActionAttrM.Select(i => new MvcHelperCustomerAttributeInfo() {ControllerName = type.Name, ActionName = method.Name, AttributeObject = i}));
                }
            }

            return retInfo;
        }
    }


    public class MvcHelperCustomerAttributeInfo
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public object AttributeObject { get; set; }

    }
}
