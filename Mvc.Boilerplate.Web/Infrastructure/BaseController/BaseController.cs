using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Boilerplate.Web.Infrastructure.BaseController
{
    public abstract partial class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           //this can be moved to custom filter
            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //this can be moved to custom filter
            base.OnActionExecuted(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {

            //stop if the exception is already handled
            if (filterContext.ExceptionHandled)
                return;

            //============Error Recording Section ===========================
            

            //===============================================================


            //Make sure that we mark the exception as handled
            filterContext.ExceptionHandled = true;
            //NOTE: Also make sure that no exception is thrown in this method or it will escalated to Application_Error.


        }
    }
}