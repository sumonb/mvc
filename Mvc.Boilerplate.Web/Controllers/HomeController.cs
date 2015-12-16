using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Boilerplate.Entities;
using Mvc.Boilerplate.Web.Infrastructure.Attributes;
using Mvc.Boilerplate.Web.Infrastructure.BaseController;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Mvc.Boilerplate.Common.Helper;
using Mvc.Boilerplate.Web.ViewModels;

namespace Mvc.Boilerplate.Web.Controllers
{
     [HelloAttr(HelloText = "this is controller")]
    public class HomeController : BaseController
    {
       [HelloAttr(HelloText = "Hello Text")]
       public ActionResult Index()
       {
           List<HomeInfo> dt = new List<HomeInfo>()
           {
               new HomeInfo(){HomeInfoId = 1, Description = "a", Amount = 10},
               new HomeInfo(){HomeInfoId = 2, Description = "b", Amount = 10}
           };
           
           var ee = dt.AsQueryable();
           var example1 = ee.ProjectTo<HelloCustomInfoViewModel>();
           var example2 = Mapper.Map<List<HomeInfoViewModel>>(dt);

           //HelloAttr
           var mc = MvcHelper.RequestedControllerName;
           var ma = MvcHelper.RequestedActionName;
           var rrr = MvcHelper.GetCustomAttributeInfo<HelloAttrAttribute>();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}