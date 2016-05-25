using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mvc.Boilerplate.Api.Controllers
{
    [Route("home")]
    public class HomeController : ApiController
    {
   
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Inside the Default Web API Controller...");
        }
    }
}
