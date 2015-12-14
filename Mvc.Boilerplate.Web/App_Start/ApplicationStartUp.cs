using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc.Boilerplate.Web.Infrastructure.Mapping;

namespace Mvc.Boilerplate.Web
{
    public class ApplicationStartUp
    {
        public static void Execute()
        {
            AutoMapperConfig.Init();
        }
    }
}