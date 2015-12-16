using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Boilerplate.Web.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class HelloAttrAttribute : Attribute
    {
        //custom attribute to attach meta data
        public string HelloText { get; set; }
        public string SNo { get; set; }
    }
}