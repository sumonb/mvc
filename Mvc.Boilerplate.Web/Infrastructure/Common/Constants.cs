using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Mvc.Boilerplate.Web.Infrastructure.Common
{
    public class Constants
    {
        public struct SampleConnectionInfo
        {
            public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["SampleConnectionInfo"].ConnectionString;
        }

        public struct WebConfigInfo
        {
            public const string SampleConfig = "~/App_Data/sampleconfig.xml";

        }
    }
}